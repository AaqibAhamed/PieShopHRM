using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components
{
    public partial class InboxCounter
    {
        private int MessageCount;

        [Inject]
        public AppState? AppState { get; set; }

        protected override void OnInitialized()
        {
            MessageCount = new Random().Next(10);
            AppState.NumberOfMessages = MessageCount;
        }
    }
}
