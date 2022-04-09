using Microsoft.Toolkit.Uwp.Notifications;
using System.Web;

namespace NoIconOnAltTab.Platforms.Windows
{
    public class NotificationBuilder
    {

        public NotificationBuilder()
        {
            toastContentBuilder = new ToastContentBuilder();
        }
        private ToastContentBuilder toastContentBuilder;
        public NotificationBuilder WithResult()
        {
            var buttons = GetToastButtons();
            toastContentBuilder.AddToastActivationInfo("", ToastActivationType.Foreground);

            toastContentBuilder.AddText("Test toast");

            foreach (var button in buttons)
            {
                toastContentBuilder.AddButton(button);
            }

            return this;
        }
        public NotificationBuilder WithText(string text)
        {
            toastContentBuilder.AddText(text);
            return this;
        }
        public ToastContentBuilder Build()
        {
            return toastContentBuilder;
        }
        public void Show()
        {
            toastContentBuilder

                .Show();
        }
        private IToastButton[] GetToastButtons()
        {

            var productUrlButton = new ToastButton("add to cart", $"url={HttpUtility.UrlEncodeUnicode("https://bing.com")}");
            productUrlButton.ActivationType = ToastActivationType.Foreground;



            return new IToastButton[] { productUrlButton };
        }
    }
}
