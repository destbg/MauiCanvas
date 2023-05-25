using System.Diagnostics;

namespace MauiCanvas;

public class MainDrawing : IDrawable
{
    private readonly Stopwatch stopwatch;
    private readonly List<CircleModel> circles;

    public MainDrawing()
    {
        stopwatch = Stopwatch.StartNew();
        circles = new List<CircleModel>();
    }

    public float RefreshRate { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        const float strokeSize = 1;

        canvas.StrokeSize = strokeSize;

        float size = Math.Min(dirtyRect.Width, dirtyRect.Height);
        float maxSize = (size / 2) - strokeSize - CircleModel.StrokeCircleSize;
        float halfWidth = dirtyRect.Width / 2;
        float halfHeight = dirtyRect.Height / 2;

        int x = 0;

        for (float i = 20; i < maxSize; i += 20, x++)
        {
            if (circles.Count == x)
            {
                circles.Add(new CircleModel(stopwatch, i, x));
            }

            circles[x].Draw(canvas, halfWidth, halfHeight);
        }
    }
}
