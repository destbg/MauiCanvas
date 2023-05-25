using Microsoft.Extensions.Logging;

namespace MauiCanvas;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        MauiAppBuilder builder = MauiApp.CreateBuilder();

		builder.UseMauiApp<App>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
