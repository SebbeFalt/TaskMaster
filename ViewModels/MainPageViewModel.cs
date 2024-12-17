using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskMaster.Helpers;
using TaskMaster.Models;
using TaskMaster.Services;
using TaskMaster.Views;

namespace TaskMaster.ViewModels
{
  [QueryProperty("SelectedState", "SelectedState")]
  public partial class MainPageViewModel : BaseViewModel
  {
    private readonly JSONStorageService _storageService;
    private readonly DetailsViewModel _detailsViewModel;

    [ObservableProperty]
    bool showEmptyImage;

    [ObservableProperty]
    ObservableCollection<ToDo> toDos = new();

    [ObservableProperty]
    string selectedState = string.Empty;

    public MainPageViewModel(JSONStorageService storageService, DetailsViewModel detailsViewModel)
    {
      _storageService = storageService;
      _detailsViewModel = detailsViewModel;
      Title = "Task Master";
    }

    [RelayCommand]
    public async Task GoToCreateAsync(string selectedState)
    {
      var route = $"{nameof(Create)}?State={selectedState}";
      await Shell.Current.GoToAsync(route, true);
    }

    [RelayCommand]
    public async Task GoToDetailsAsync(ToDo toDo)
    {
      if (toDo is null)
        return;

      await Shell.Current.GoToAsync($"{nameof(Details)}", true, new Dictionary<string, object>
    {
        { "ToDo", toDo },
        { "State", toDo.State }
    });
    }
    [RelayCommand]
    public async Task SortByStateAsync(string state)
    {
      if (string.IsNullOrEmpty(state))
        return;

      SelectedState = state;
      var toDos = await _storageService.FetchByStateAsync(state);
      ToDos = new(toDos);
      ShowEmptyImage = IsEmpty();
    }
    [RelayCommand]
    public async Task RemoveAsync(ToDo toDo)
    {
      bool isConfirmed = await Shell.Current.DisplayAlert(
        "Confirm Deletion",
        "Are you sure you want to delete this task?",
        "Confirm",
        "Cancel");

      if (isConfirmed)
      {
        await _storageService.RemoveAsync(toDo);
        await SortByStateAsync(toDo.State);
      }
    }
    public async Task InitializeAsync()
    {
      ToDos.Clear();
      if (string.IsNullOrEmpty(SelectedState))
        SelectedState = SD.TODO;

      var todos = await _storageService.FetchByStateAsync(SelectedState);

      if (ToDos is null)
      {
        ToDos = new ObservableCollection<ToDo>(todos);
      }
      else
      {
        ToDos.Clear();
        foreach (var task in todos)
        {
          ToDos.Add(task);
        }
      }

      ShowEmptyImage = IsEmpty();
    }

    private bool IsEmpty()
    {
      return ToDos.Count == 0;
    }
  }
}
  
