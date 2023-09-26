using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components.Widgets
{
    public partial class InboxWidget
    {
        public int MessageCount { get; set; } = 0;

        [Inject]
        public AppState? AppState { get; set; }

        protected override void OnInitialized()
        {
            // MessageCount = new Random().Next(10);

            MessageCount = AppState.NumberOfMessages;
        }
    }
}
