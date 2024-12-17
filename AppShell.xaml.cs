using TaskMaster.Views;

namespace TaskMaster
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();
      Routing.RegisterRoute(nameof(Create), typeof(Create));
      Routing.RegisterRoute(nameof(Details), typeof(Details));
      Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
  }
}
