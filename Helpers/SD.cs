namespace TaskMaster.Helpers
{
  //Static details
  public static class SD
  {
    public const string TODO = "To-do";
    public const string ONGOING = "Ongoing";
    public const string BLOCKED = "Blocked";
    public const string DONE = "Done";

    public static readonly string[] STATES = { TODO, ONGOING, BLOCKED, DONE };

    public const string COLOR_TODO = "#3A6968";
    public const string COLOR_ONGOING = "#857D44";
    public const string COLOR_BLOCKED = "#7B4941";
    public const string COLOR_DONE = "#4A634A";
    public const string COLOR_DEFAULT = "#635E74";

    public const string EVENT = "Event";
    public const string DEADLINE = "Deadline";
    public const string APPOINTMENT = "Appointment";
    public const string MEETING = "Meeting";
    public const string ERRAND = "Errand";
    public const string CALL = "Call";
    public const string FOLLOW_UP = "Follow-up";
    public const string REMINDER = "Reminder";
    public const string WORK = "Work";
    public const string STUDY = "Study";
    public const string SHOPPING = "Shopping";
    public const string HOUSEHOLD = "Household";

    public static readonly string[] TYPES = new string[]
{
    EVENT,
    DEADLINE,
    APPOINTMENT,
    MEETING,
    ERRAND,
    CALL,
    FOLLOW_UP,
    REMINDER,
    WORK,
    STUDY,
    SHOPPING,
    HOUSEHOLD
};

    public static readonly string[] COLORS = { COLOR_TODO, COLOR_ONGOING, COLOR_BLOCKED, COLOR_DONE, COLOR_DEFAULT };

    public static string SetColor(string state)
    {
      return state switch
      {
        SD.TODO => SD.COLOR_TODO,
        SD.ONGOING => SD.COLOR_ONGOING,
        SD.BLOCKED => SD.COLOR_BLOCKED,
        SD.DONE => SD.COLOR_DONE,
        _ => SD.COLOR_DEFAULT
      };
    }

  }
}
