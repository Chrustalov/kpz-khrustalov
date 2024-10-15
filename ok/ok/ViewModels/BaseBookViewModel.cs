using CommunityToolkit.Mvvm.ComponentModel;
using ok.Models;

namespace ok.ViewModels;

public partial class BaseBookViewModel : BaseViewModel {
  [ObservableProperty]
  private Book _book;
}
