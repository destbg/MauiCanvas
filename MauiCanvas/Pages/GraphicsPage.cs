using Timer = System.Timers.Timer;

namespace MauiCanvas.Pages;

public abstract class GraphicsPage : ContentPage
{
    private Timer timer;

    protected readonly GraphicsView Graphics;

    protected GraphicsPage()
    {
        Shell.SetNavBarIsVisible(this, false);
        BackgroundColor = Colors.Black;

        Graphics = new GraphicsView();

        Appearing += OnGraphicsPageAppearing;
        Disappearing += GraphicsPageDisappearing;
    }

    private async void OnGraphicsPageAppearing(object sender, EventArgs e)
    {
        await Task.Delay(100);

        float refreshRate = DeviceDisplay.MainDisplayInfo.RefreshRate;

        timer = new Timer(1000 / refreshRate);
        timer.Start();
        timer.Elapsed += OnTimerElapsed;

        DeviceDisplay.Current.MainDisplayInfoChanged += OnDisplayInfoChanged;
    }

    private void GraphicsPageDisappearing(object sender, EventArgs e)
    {
        DeviceDisplay.Current.MainDisplayInfoChanged -= OnDisplayInfoChanged;

        if (timer != null)
        {
            timer.Stop();
            timer = null;
        }
    }

    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Graphics.Invalidate();
    }

    private void OnDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        timer.Interval = 1000 / e.DisplayInfo.RefreshRate;
        timer.Start();
    }
}
