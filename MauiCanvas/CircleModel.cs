using System.Diagnostics;
using Plugin.Maui.Audio;

namespace MauiCanvas;

public class CircleModel
{
    public const float StrokeCircleSize = 4;

    private const double AnimationDuration = 2;
    private const float DefaultHue = .2528f;
    private const float DefaultSaturation = .33f;
    private const float DefaultValue = .2f;
    private const float VelocityModifier = .8f;

    private readonly Stopwatch stopwatch;
    private readonly IAudioPlayer audioPlayer;
    private readonly float dis;
    private readonly int index;
    private readonly Color defaultColor;

    private float prevCircleY;
    private TimeSpan? hitTime;

    public CircleModel(Stopwatch stopwatch, IAudioPlayer audioPlayer, float dis, int index)
    {
        this.stopwatch = stopwatch;
        this.audioPlayer = audioPlayer;
        this.dis = dis;
        this.index = index;

        defaultColor = Color.FromHsv(DefaultHue, DefaultSaturation, DefaultValue);
    }

    public void VolumeChanged(double value)
    {
        audioPlayer.Volume = value;
    }

    public void Draw(ICanvas canvas, float halfWidth, float halfHeight, bool overMax)
    {
        Color color;

        if (hitTime != null)
        {
            double leftTime = (stopwatch.Elapsed - hitTime.Value).TotalSeconds;

            if (leftTime > AnimationDuration)
            {
                hitTime = null;
                color = defaultColor;
            }
            else
            {
                double percent = leftTime / AnimationDuration;
                float dp = (float)percent * 2;

                color = Color.FromHsv(DefaultHue, DefaultSaturation, (percent > .5 ? (2 - dp) : dp) + DefaultValue);
            }
        }
        else
        {
            color = defaultColor;
        }

        canvas.FillColor = color;
        canvas.StrokeColor = color;

        float distance = dis * 2;
        float offset = (float)Math.PI * 5 / (index + 1);

        canvas.DrawArc(halfWidth - dis, halfHeight - dis, distance, distance, offset, 180 - offset, false, false);
        canvas.DrawArc(halfWidth - dis, halfHeight - dis, distance, distance, 180 + offset, 360 - offset, false, false);

        canvas.FillCircle((dis * (float)Math.Cos(Math.PI)) + halfWidth, halfHeight, 3);
        canvas.FillCircle((dis * (float)Math.Cos(Math.PI * 2)) + halfWidth, halfHeight, 3);

        double velocity = VelocityModifier - (VelocityModifier / 2 * ((index + 1d) / MainDrawing.Max));
        double angle = Math.PI + (stopwatch.Elapsed.TotalSeconds * velocity % (Math.PI * 2));

        float circleX = (dis * (float)Math.Cos(angle)) + halfWidth;
        float circleY = (dis * (float)Math.Sin(angle)) + halfHeight;

        canvas.FillColor = Color.FromHsv(DefaultHue, DefaultSaturation, .65f);

        canvas.FillCircle(circleX, circleY, StrokeCircleSize);

        if (prevCircleY != default && ((prevCircleY < halfHeight && circleY > halfHeight) || (prevCircleY > halfHeight && circleY < halfHeight)))
        {
            hitTime = stopwatch.Elapsed;

            if (!overMax)
            {
                audioPlayer.Play();
            }
        }

        prevCircleY = circleY;
    }
}
