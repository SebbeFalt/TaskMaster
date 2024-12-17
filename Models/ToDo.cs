using TaskMaster.Helpers;

namespace TaskMaster.Models
{
  public class ToDo
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Type { get; set; } = SD.DEADLINE;

    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public DateTime DeadLine { get; set; } = DateTime.Now.AddDays(1);
    public string DeadLineFormatted => DeadLine.ToString("yyyy-MM-dd");

    public ToDo()
    {
      Color = SD.SetColor(State);
    }
  }
}
