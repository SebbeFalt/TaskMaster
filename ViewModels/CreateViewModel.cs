using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskMaster.Helpers;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.ViewModels
{
  [QueryProperty("State", "State")]
  public partial class CreateViewModel : BaseViewModel
  {
    private readonly JSONStorageService _storageService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(BackgroundColor))]
    string state;

    [ObservableProperty]
    ToDo newToDo = new();
    public string BackgroundColor => SD.SetColor(State);

    public CreateViewModel(JSONStorageService storageService)
    {
      _storageService = storageService;
      Title = "Create a new Task";
    }
    
    [RelayCommand]
    public async Task SaveAsync()
    {
      NewToDo.State = State;
      NewToDo.Color = SD.SetColor(NewToDo.State);
      await _storageService.SaveAsync(NewToDo);
      await Shell.Current.GoToAsync($"..?SelectedState={NewToDo.State}", true);
    }
    [RelayCommand]
    public static async Task GoBackAsync()
    {
      await Shell.Current.GoToAsync("..", true);
    }

    
  }
}
