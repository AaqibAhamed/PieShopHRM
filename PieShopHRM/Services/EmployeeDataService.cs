﻿using Blazored.LocalStorage;
using PieShopHRM.Helper;
using PieShopHRM.Shared.Domain;
using System.Text.Json;

namespace PieShopHRM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public EmployeeDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired = false)
        {
            if (refreshRequired)
            {
                bool employeeExpirationExist = await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListExpirationKey);
                if (employeeExpirationExist)
                {
                    DateTime employeeListExpirationTime = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.EmployeesListExpirationKey);

                    if (employeeListExpirationTime > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListKey))
                        {
                            return await _localStorageService.GetItemAsync<List<Employee>>(LocalStorageConstants.EmployeesListKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                    (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;

        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                 (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
                 new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}