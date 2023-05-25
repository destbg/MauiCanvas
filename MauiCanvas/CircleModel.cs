using System.Diagnostics;

namespace MauiCanvas;

public class CircleModel
{
    public const float StrokeCircleSize = 4;

    private const double AnimationDuration = 3;
    private const byte DefaultColor = 0;

    private readonly Stopwatch stopwatch;
    private readonly float dis;
    private readonly int index;

    private float prevCircleY;
    private TimeSpan? hitTime;

    public CircleModel(Stopwatch stopwatch, float dis, int index)
    {
        this.stopwatch = stopwatch;
        this.dis = dis;
        this.index = index;
    }

    public void Draw(ICanvas canvas, float halfWidth, float halfHeight)
    {
        Color color;

        if (hitTime != null)
        {
            double leftTime = (stopwatch.Elapsed - hitTime.Value).TotalSeconds;

            if (leftTime > AnimationDuration)
            {
                hitTime = null;
                color = Color.FromRgb(DefaultColor, DefaultColor, DefaultColor);
            }
            else
            {
                double percent = leftTime / AnimationDuration;
                double dp = percent * 2;

                byte b = (byte)Math.Floor(percent > .5 ? (255 * (2 - dp)) : (255 * dp));
                color = Color.FromRgb(b, b, b);
            }
        }
        else
        {
            color = Color.FromRgb(DefaultColor, DefaultColor, DefaultColor);
        }

        canvas.FillColor = color;
        canvas.StrokeColor = color;

        float distance = dis * 2;
        float offset = (float)Math.PI * 5 / (index + 1);

        canvas.DrawArc(halfWidth - dis, halfHeight - dis, distance, distance, offset, 180 - offset, false, false);
        canvas.DrawArc(halfWidth - dis, halfHeight - dis, distance, distance, 180 + offset, 360 - offset, false, false);

        canvas.FillCircle((dis * (float)Math.Cos(Math.PI)) + halfWidth, halfHeight, 3);
        canvas.FillCircle((dis * (float)Math.Cos(Math.PI * 2)) + halfWidth, halfHeight, 3);

        double velocity = 0.5 - (index * 0.01);
        double angle = Math.PI + (stopwatch.Elapsed.TotalSeconds * velocity % (Math.PI * 2));

        float circleX = (dis * (float)Math.Cos(angle)) + halfWidth;
        float circleY = (dis * (float)Math.Sin(angle)) + halfHeight;

        canvas.FillColor = Colors.White;

        canvas.FillCircle(circleX, circleY, StrokeCircleSize);

        if (prevCircleY != default && ((prevCircleY < halfHeight && circleY > halfHeight) || (prevCircleY > halfHeight && circleY < halfHeight)))
        {
            hitTime = stopwatch.Elapsed;
        }

        prevCircleY = circleY;
    }
}
