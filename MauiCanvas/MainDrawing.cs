using System.Diagnostics;
using Plugin.Maui.Audio;

namespace MauiCanvas;

public class MainDrawing : IDrawable
{
    public const int Max = 15;

    private const float Increment = 21;

    private readonly Stopwatch stopwatch;
    private readonly CircleModel[] circles;
    private readonly ICanvas fakeCanvas;

    public MainDrawing()
    {
        stopwatch = Stopwatch.StartNew();
        circles = new CircleModel[Max];
        fakeCanvas = new FakeCanvas();

        int x = 0;

        for (float i = Increment; x < Max; i += Increment, x++)
        {
            IAudioPlayer audioPlayer = AudioManager.Current.CreatePlayer(
                FileSystem.OpenAppPackageFileAsync($"key-{x}.wav").GetAwaiter().GetResult()
            );

            audioPlayer.Volume = 0;

            circles[x] = new CircleModel(stopwatch, audioPlayer, i, x);
        }
    }

    public float RefreshRate { get; set; }

    public void VolumeChanged(double value)
    {
        for (int i = 0; i < Max; i++)
        {
            circles[i].VolumeChanged(value);
        }
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        const float strokeSize = 1;

        canvas.StrokeSize = strokeSize;

        float size = Math.Min(dirtyRect.Width, dirtyRect.Height);
        float maxSize = (size / 2) - strokeSize - CircleModel.StrokeCircleSize;
        float halfWidth = dirtyRect.Width / 2;
        float halfHeight = dirtyRect.Height / 2;

        int x = 0;

        for (float i = Increment; x < Max; i += Increment, x++)
        {
            bool overMax = i >= maxSize;

            circles[x].Draw(overMax ? fakeCanvas : canvas, halfWidth, halfHeight, overMax);
        }
    }
}
