namespace MauiCanvas.Pages.PendulumWave;

public class PendulumWavePage : GraphicsPage
{
    private readonly PendulumWaveDrawable drawable;

    public PendulumWavePage()
    {
        drawable = new PendulumWaveDrawable();

        Graphics.Drawable = drawable;

        Slider slider = new()
        {
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.End,
            WidthRequest = 100,
            Margin = new Thickness(0, 0, 10, 0)
        };

        slider.ValueChanged += OnSliderValueChanged;

        Content = new Grid
        {
            new Image
            {
                Source = "background.png",
                Aspect = Aspect.AspectFill,
                IsOpaque = true,
                Opacity = .5,
            },
            Graphics,
            slider
        };
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        drawable.VolumeChanged(e.NewValue / 20);
    }
}
