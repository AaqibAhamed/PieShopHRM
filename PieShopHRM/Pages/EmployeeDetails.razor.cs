using PieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Models;
using PieShopHRM.Services;
using PieShopHRM.Shared.Model;

namespace PieShopHRM.Pages
{
    public partial class EmployeeDetails
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        public Employee? Employee { get; set; } = new Employee();

        [Parameter]
        public string EmployeeId { get; set; } = string.Empty;

        public List<Marker> MapMarkers = new();

        protected override async Task OnInitializedAsync()
        {
            // Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            if (Employee.Latitude.HasValue && Employee.Longitude.HasValue)
            {
                MapMarkers = new List<Marker>
                {
                    new Marker
                    {
                         Description = $"{Employee.FirstName} {Employee.LastName}",
                         ShowPopup = false ,
                         X= Employee.Latitude.Value,
                         Y= Employee.Longitude.Value
                    }
                };
            }


        }
    }
}
