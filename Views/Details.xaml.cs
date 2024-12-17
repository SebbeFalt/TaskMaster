using TaskMaster.Services;
using TaskMaster.ViewModels;

namespace TaskMaster.Views;


public partial class Details : ContentPage
{
  private JSONStorageService _storageService;
  public Details(DetailsViewModel detailsViewModel, JSONStorageService storageService)
  {
    InitializeComponent();
    _storageService = storageService;
    BindingContext = detailsViewModel;
  }
}