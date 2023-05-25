using Timer = System.Timers.Timer;

namespace MauiCanvas;

public class MainPage : ContentPage
{
    private readonly GraphicsView graphicsView;
    private readonly MainDrawing mainDrawing;
    private Timer timer;

    public MainPage()
    {
        DeviceDisplay.Current.MainDisplayInfoChanged += OnDisplayInfoChanged;

        mainDrawing = new MainDrawing();

        graphicsView = new()
        {
            Drawable = mainDrawing,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill
        };

        Content = graphicsView;
    }

    protected override async void OnAppearing()
    {
        await Task.Delay(100);

        float refreshRate = DeviceDisplay.MainDisplayInfo.RefreshRate;

        mainDrawing.RefreshRate = refreshRate;
        timer = new Timer(1000 / refreshRate);
        timer.Start();
        timer.Elapsed += OnTimerElapsed;
    }

    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        graphicsView.Invalidate();
    }

    private void OnDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        mainDrawing.RefreshRate = e.DisplayInfo.RefreshRate;
        timer.Interval = 1000 / e.DisplayInfo.RefreshRate;
        timer.Start();
    }
}
