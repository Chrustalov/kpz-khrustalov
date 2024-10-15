using ok.Models;
using ok.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ok.Services.BookService;

namespace ok.ViewModels;

public partial class BookPageViewModel : BaseBookViewModel {
  public ICommand OnAddBookCommand { get; }
  private readonly BookService bookService;
  public ICommand loadBookCommand { get; }
  public ObservableCollection<Book> BookList { get; set; }
  
  public BookPageViewModel()
  {
    OnAddBookCommand = new Command(async () => await OnAddBook());
    loadBookCommand = new Command(async () => await loadBook());
    BookList = new ObservableCollection<Book>();
    bookService = new BookService();
  }

  private async Task OnAddBook()
  {
    await Shell.Current.GoToAsync(nameof(AddBookPage));
  }

  public void onAppearing() {
    IsBusy = true;
  }

  public async Task loadBook() 
  {
    IsBusy = true;

    try
    {
      BookList.Clear();
      var items = await bookService.getBooksAsync();
      if (items != null)
      {
          foreach (var item in items)
          {
              BookList.Add(item);
          }
      }
    }
    catch (Exception e)
    {
      IsBusy = false;
      await Shell.Current.DisplayAlert("Error", e.Message, "OK");
    }
    finally 
    {
      IsBusy = false;
    }
  }
}
