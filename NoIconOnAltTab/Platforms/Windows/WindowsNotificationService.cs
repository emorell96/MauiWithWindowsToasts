using Microsoft.Extensions.Logging;
using System.Web;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Microsoft.Toolkit.Uwp.Notifications;
using NoIconOnAltTab.Platforms.Windows;
using Windows.ApplicationModel.Background;

namespace OpenStockApp.Core.Maui.Platforms.Windows
{
    public class WindowsNotificationService : IDisposable
    {
        

        public async static void OnActivated(ToastNotificationActivatedEventArgsCompat toastArgs)
        {
            Console.WriteLine("Activated");

            try
            {
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
                if (args.TryGetValue("url", out var url))
                {
                    await Browser.OpenAsync(HttpUtility.UrlDecode(url));
                }
            }
            catch { }
        }
        public static void SendNotification()
        {
            //ToastNotificationManagerCompat.OnActivated += (args) => OnActivated(args);
            Application.Current?.Dispatcher.Dispatch(() =>
            {
                ShowPlatform();
            });
          
        }
        /// <summary>
        /// This didn't work.
        /// </summary>
        /// <returns></returns>
        protected static async Task RegisterBackgroundTask()
        {
            const string taskName = "ToastBackgroundTask";

            // If background task is already registered, do nothing
            if (BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals(taskName)))
                return;

            // Otherwise request access
            BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();

            // Create the background task
            BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
            {
                Name = taskName
            };

            // Assign the toast action trigger
            builder.SetTrigger(new ToastNotificationActionTrigger());

            // And register the task
            BackgroundTaskRegistration registration = builder.Register();
        }

        protected static async void ShowPlatform()
        {
            try
            {
                var builder = new NotificationBuilder();
                builder.WithResult();
                var toastContentBuilder = builder.Build();
                toastContentBuilder.SetBackgroundActivation();
               // await RegisterBackgroundTask();

                toastContentBuilder.Show();
                
                //var toastContent = toastContentBuilder.GetToastContent();
                //toastContent.ActivationType = ToastActivationType.Background;


                //var xmlDocument = new XmlDocument();
                //xmlDocument.LoadXml(toastContent.GetContent());
                //var nativeToast = new ToastNotification(xmlDocument);
                ////nativeToast.Activated += OnActivated;
                //////nativeToast.
                ////nativeToast.Failed += OnFailed;
                ////nativeToast.Dismissed += OnDismissed;
                //nativeToast.ExpirationTime = DateTimeOffset.Now;
                //toastNotifications.Add(nativeToast);

                //var notifier = ToastNotificationManager.CreateToastNotifier();

                //notifier.Show(nativeToast);
            }
            catch(Exception ex)
            {
                
            }
            
        }

       
        public void Dispose()
        {
            toastNotifications.Clear();
        }
    }
}
