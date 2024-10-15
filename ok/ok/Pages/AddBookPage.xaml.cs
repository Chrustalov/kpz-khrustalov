using ok.Models;
using ok.ViewModels;

namespace ok.Views;

public partial class AddBookPage : ContentPage 
{
  public Book Book { get; set; }
  AddBookPageViewModel addBookPageViewModel;

  public AddBookPage() 
  {
    InitializeComponent();
    this.BindingContext = addBookPageViewModel = new AddBookPageViewModel();
  }

  protected async override void OnAppearing()
  {
    var items = await App.BookService.getBooksAsync();
    BooksCounter.Count = items.Count();
  }
}
