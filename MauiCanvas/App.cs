using MauiCanvas.Pages.PendulumWave;
using MauiCanvas.Pages.Snake;

namespace MauiCanvas;

public class App : Application
{
	public App()
	{
		UserAppTheme = AppTheme.Dark;

		MainPage = new Shell
		{
			Items =
			{
				new ShellContent
				{
					Title = "Snake",
					ContentTemplate = new DataTemplate(typeof(SnakePage)),
				},
                new ShellContent
                {
                    Title = "Pendulum Wave",
                    ContentTemplate = new DataTemplate(typeof(PendulumWavePage)),
                }
            }
		};
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

		window.Title = "Canvas";
		window.Width = 900;
		window.Height = 900;
		window.MinimumHeight = 200;
		window.MinimumWidth = 200;

		return window;
    }
}
