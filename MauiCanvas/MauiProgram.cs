using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiCanvas;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        MauiAppBuilder builder = MauiApp.CreateBuilder();

		builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(f =>
			{
				f.AddFont("Font Awesome 6 Free-Regular-400.otf", "FAR");
				f.AddFont("Font Awesome 6 Free-Solid-900.otf", "FA");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
