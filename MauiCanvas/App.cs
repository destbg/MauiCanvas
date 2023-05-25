namespace MauiCanvas;

public class App : Application
{
	public App()
	{
		UserAppTheme = AppTheme.Dark;

		MainPage = new MainPage();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

		window.Title = "Canvas";
		window.Width = 1600;
		window.Height = 950;
		window.MinimumHeight = 200;
		window.MinimumWidth = 200;

		return window;
    }
}
