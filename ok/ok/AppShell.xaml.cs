using ok.Views;

namespace ok;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
    Routing.RegisterRoute(nameof(BookPage), typeof(BookPage));
    Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
	}
}
