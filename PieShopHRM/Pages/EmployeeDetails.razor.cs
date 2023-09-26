using PieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Models;
using PieShopHRM.Services;

namespace PieShopHRM.Pages
{
    public partial class EmployeeDetails
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        public Employee? Employee { get; set; } = new Employee();

        [Parameter]
        public string EmployeeId { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            // Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            
        }
    }
}
