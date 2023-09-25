using PieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Models;

namespace PieShopHRM.Pages
{
    public partial class EmployeeDetails
    {
        public Employee? Employee { get; set; } = new Employee();

        [Parameter]
        public string EmployeeId { get; set; } = string.Empty;

        protected override Task OnInitializedAsync()
        {
            Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            return base.OnInitializedAsync();
        }
    }
}
