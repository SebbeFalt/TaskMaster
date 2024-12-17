using Microsoft.Extensions.Logging;
using TaskMaster.Services;
using TaskMaster.ViewModels;

namespace TaskMaster
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
          .UseMauiApp<App>()
          .ConfigureFonts(fonts =>
          {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
          });

      builder.Services.AddSingleton<JSONStorageService>();
      builder.Services.AddTransient<MainPageViewModel>();
      builder.Services.AddTransient<DetailsViewModel>();
      builder.Services.AddTransient<CreateViewModel>();

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
