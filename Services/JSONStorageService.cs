using System.Text.Json;
using TaskMaster.Models;

namespace TaskMaster.Services
{
  public class JSONStorageService(string? filePath = null)
  {
    private readonly string _filePath = filePath ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todos.json");


    public async Task RemoveAsync(ToDo toDo)
    {
      var allTasks = await FetchAllAsync();
      var taskToRemove = allTasks.FirstOrDefault(t => t.Id == toDo.Id);

      if (taskToRemove is null)
        return; 

      allTasks.Remove(taskToRemove);
      await SaveAllAsync(allTasks);
    }
    // -- Saving methods
    public async Task SaveAllAsync(IEnumerable<ToDo> todos)
    {
      var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
      await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task SaveAsync(ToDo todo)
    {
      var todos = await FetchAllAsync();

      var existing = todos.FirstOrDefault(t => t.Id == todo.Id);
      if (existing != null)
      {
        var index = todos.IndexOf(existing);
        todos[index] = todo;
      }
      else
      {
        todos.Add(todo);
      }

      await SaveAllAsync(todos);
    }

    // -- End of saving methods

    // -- Fetching methods
    public async Task<List<ToDo>> FetchAllAsync()
    {
      if (!File.Exists(_filePath))
        return new List<ToDo>();

      var json = await File.ReadAllTextAsync(_filePath);
      return JsonSerializer.Deserialize<List<ToDo>>(json) ?? new List<ToDo>();
    }

    public async Task<ToDo?> FetchByIdAsync(string id)
    {
      var todos = await FetchAllAsync();
      ToDo todo = todos.FirstOrDefault(todo => todo.Id == id);
      //return todos.FirstOrDefault(todo => todo.Id == id);
      return todo;
    }

    public async Task<List<ToDo>> FetchByStateAsync(string state)
    {
      var todos = await FetchAllAsync();
      return todos.Where(todo => todo.State == state).OrderByDescending(todo => todo.LastUpdated).ToList();
    }

    // -- End of fetching methods
  }

}
