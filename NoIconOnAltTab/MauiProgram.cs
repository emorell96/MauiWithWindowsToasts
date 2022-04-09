using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.UI.Xaml;
using OpenStockApp.Core.Maui.Platforms.Windows;
using Windows.ApplicationModel.Activation;

namespace NoIconOnAltTab;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkit()
			
			.UseMauiApp<App>()
			
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.ConfigureLifecycleEvents(configure =>
            {
				configure.AddWindows(c =>
				{
					c.OnLaunched((window, args) =>
					{
						ToastNotificationManagerCompat.OnActivated += WindowsNotificationService.OnActivated;
					});

					//c.AddEvent<WindowsLifecycle.OnActivated>("OnActivated", (w, a) =>
					//{
					//	Console.WriteLine("ACtivated");
					//});
					//c.AddEvent<OnBackgroundActivated>("OnBackgroundActivated", (w, a) =>
					//{
					//	Console.WriteLine("Background");
					//});
					//c.OnActivated((window, args) =>
     //               {
     //                   Console.WriteLine("Launched");
     //               });
                });
            });

		return builder.Build();
	}
}

public delegate void OnBackgroundActivated(Microsoft.UI.Xaml.Window window, IBackgroundActivatedEventArgs backgroundActivatedEventArgs);