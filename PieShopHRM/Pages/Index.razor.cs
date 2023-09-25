using PieShopHRM.Components.Widgets;

namespace PieShopHRM.Pages
{
    public partial class Index
    {
        List<Type> Widgets { get; set; } = new List<Type>() { typeof (EmployeeCountWidget), typeof(InboxWidget)};
    }
}
