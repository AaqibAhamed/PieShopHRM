using PieShopHRM.Shared.Domain;
using PieShopHRM.Models;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Services;

namespace PieShopHRM.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        public List<Employee>? Employees { get; set; } = default!;

        private Employee? _selectedEmployee;

        private string Title = "Employee Overview";

        protected override async Task OnInitializedAsync()
        {
            // Employees = MockDataService.Employees;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee parsedEmployee)
        {
            _selectedEmployee = parsedEmployee;
        }

    }
}
