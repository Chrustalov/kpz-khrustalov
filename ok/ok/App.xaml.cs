using ok.Services.BookService;

namespace ok;

public partial class App : Application
{

  public static BookService _bookService;

  public static BookService BookService {
    get
    {
      if (_bookService == null) {
        _bookService = new BookService();
      }

      return _bookService;
    }
  }

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
