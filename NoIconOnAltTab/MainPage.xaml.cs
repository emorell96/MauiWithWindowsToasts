using CommunityToolkit.Maui.Alerts;
#if WINDOWS
using OpenStockApp.Core.Maui.Platforms.Windows;
#endif
namespace NoIconOnAltTab;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";

		//var snackBar = new Snackbar
		//{
		//	Action = () => Console.WriteLine("Test"),
		//	ActionButtonText = "Test",
		//	Text = "Test",

		//};
		//snackBar.Show();
#if WINDOWS
		WindowsNotificationService.SendNotification();
#endif

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

