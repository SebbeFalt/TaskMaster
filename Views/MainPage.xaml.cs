
using TaskMaster.Services;
using TaskMaster.ViewModels;

namespace TaskMaster.Views
{
  public partial class MainPage : ContentPage
  {
    MainPageViewModel _mainPageViewModel;
    public MainPage(MainPageViewModel mainPageViewModel)
    {
      InitializeComponent();
      _mainPageViewModel = mainPageViewModel;
      BindingContext = _mainPageViewModel;
    }
    protected async override void OnAppearing()
    {
      base.OnAppearing();
      await _mainPageViewModel.InitializeAsync(); 
    }
  }

}
