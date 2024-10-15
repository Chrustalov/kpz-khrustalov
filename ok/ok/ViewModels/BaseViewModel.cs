namespace ok.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class BaseViewModel : ObservableObject
{
  [ObservableProperty]
  public bool isBusy;
  [ObservableProperty]
  public bool title;
   
}
