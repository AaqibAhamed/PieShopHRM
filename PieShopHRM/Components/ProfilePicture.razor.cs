using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components
{
    public  partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }   
    }
}
