using PieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewPopup { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; } = default!;

        public void NavigateToDetails(Employee selectedEmployee)
        {
            NavigationManager.NavigateTo($"/employeedetail/{selectedEmployee.EmployeeId}");
        }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Employee.LastName)) 
            {
                throw new Exception("Last name can't be empty");
            }
        }

    }
}
