using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components
{
    public partial class QuickViewPopup
    {
        [Parameter]
        public Employee? SelectedEmployee { get; set; }

        private  Employee? _employee;

        protected override void OnParametersSet()
        {
            _employee = SelectedEmployee;
        }

        public void Close()
        {
            _employee = null;
        }

    }
}
