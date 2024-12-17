using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskMaster.ViewModels
{
  public partial class BaseViewModel : ObservableObject
  {
    [ObservableProperty]
    string title = string.Empty;
  }
}
