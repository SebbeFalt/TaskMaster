using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskMaster.Helpers;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.ViewModels
{
  [QueryProperty("ToDo", "ToDo")]
  [QueryProperty("State", "State")]
  public partial class DetailsViewModel : BaseViewModel
  {
    JSONStorageService _storageService;
    public DetailsViewModel(JSONStorageService storageService)
    {
      _storageService = storageService;
      Title = "Details";
    }
    [ObservableProperty]
    ToDo toDo;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(BackgroundColor))]
    string state;
    public string BackgroundColor => SD.SetColor(State);

    [RelayCommand]
    public async Task SaveAsync()
    {
      ToDo.State = State;
      ToDo.Color = SD.SetColor(State);
      await _storageService.SaveAsync(ToDo);
      await Shell.Current.GoToAsync($"..?SelectedState={ToDo.State}", true);
    }

    [RelayCommand]
    public async Task RemoveAsync()
    {
      bool isConfirmed = await Shell.Current.DisplayAlert(
        "Confirm Deletion",
        "Are you sure you want to delete this task?",
        "Confirm",
        "Cancel");

      if (isConfirmed)
      {
        await _storageService.RemoveAsync(ToDo);
        await Shell.Current.GoToAsync("..", true);
      }
    }

    [RelayCommand]
    public static async Task GoBackAsync()
    {
      await Shell.Current.GoToAsync("..", true);
    }

  }
}
