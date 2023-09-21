using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewPopup { get; set; }


    }
}
