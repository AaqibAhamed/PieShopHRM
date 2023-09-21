using BethanysPieShopHRM.Shared.Domain;
using PieShopHRM.Models;

namespace PieShopHRM.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee>? Employees { get; set; } = default!;

        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees;
        }
    }
}
