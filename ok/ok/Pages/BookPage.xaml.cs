using ok.ViewModels;

namespace ok.Views;

public partial class BookPage : ContentPage 
{
  BookPageViewModel bookPageViewModel;

  public BookPage() 
  {
    InitializeComponent();
    this.BindingContext = bookPageViewModel = new BookPageViewModel();
  }
  
  protected async override void OnAppearing()
  {
    bookPageViewModel.loadBookCommand.Execute(null);
    var items = await App.BookService.getBooksAsync();
    BooksCounter.Count = items.Count();
  }
}
