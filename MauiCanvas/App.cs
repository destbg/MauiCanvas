using MauiCanvas.Pages.PendulumWave;
using MauiCanvas.Pages.Snake;

namespace MauiCanvas;

public partial class App : Application
{
    public App()
    {
        UserAppTheme = AppTheme.Dark;
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return new Window
        {
            Page = new Shell
            {
                Items =
                {
                    new ShellContent
                    {
                        Title = "Pendulum Wave",
                        ContentTemplate = new DataTemplate(typeof(PendulumWavePage)),
                    },
                    new ShellContent
                    {
                        Title = "Snake",
                        ContentTemplate = new DataTemplate(typeof(SnakePage)),
                    }
                }
            },
            Title = "Canvas",
            Width = 900,
            Height = 900,
            MinimumHeight = 200,
            MinimumWidth = 200
        };
    }
}
