using CommunityToolkit.Mvvm.Input;
using ok.Models;
using System.Windows.Input;

namespace ok.ViewModels;

public partial class AddBookPageViewModel : BaseBookViewModel {
  public ICommand OnSubmitCommand { get; }
  public ICommand OnCancelCommand { get; }

  public AddBookPageViewModel()
  {
      Book = new Book();
      OnSubmitCommand = new Command(async () => await OnSubmit());
      OnCancelCommand = new Command(async () => await OnCancel());
  }

  public async Task OnSubmit()
  {
    try
    {
      var book = Book;
      await App.BookService.AddUpdateBookAsync(book);
      await Shell.Current.DisplayAlert("Success", "Successfully added!", "OK");
      await Shell.Current.GoToAsync("..");
    }
    catch (Exception e)
    {
      await Shell.Current.DisplayAlert("Error", e.Message, "OK");
    }
   
  }

  public async Task OnCancel()
  {
    await Shell.Current.GoToAsync("..");
  }

  public void onAppearing() {
    IsBusy = true;
  }
}
