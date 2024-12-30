using System.Numerics;
using Microsoft.Maui.Graphics.Text;

namespace MauiCanvas;

public class FakeCanvas : ICanvas
{
    public float DisplayScale { get; set; }
    public float StrokeSize { get; set; }
    public float MiterLimit { get; set; }
    public Color StrokeColor { get; set; }
    public LineCap StrokeLineCap { get; set; }
    public LineJoin StrokeLineJoin { get; set; }
    public float[] StrokeDashPattern { get; set; }
    public float StrokeDashOffset { get; set; }
    public Color FillColor { get; set; }
    public Color FontColor { get; set; }
    public IFont Font { get; set; }
    public float FontSize { get; set; }
    public float Alpha { get; set; }
    public bool Antialias { get; set; }
    public BlendMode BlendMode { get; set; }

    public void ClipPath(PathF path, WindingMode windingMode = WindingMode.NonZero)
    {
    }

    public void ClipRectangle(float x, float y, float width, float height)
    {
    }

    public void ConcatenateTransform(Matrix3x2 transform)
    {
    }

    public void DrawArc(float x, float y, float width, float height, float startAngle, float endAngle, bool clockwise, bool closed)
    {
    }

    public void DrawEllipse(float x, float y, float width, float height)
    {
    }

    public void DrawImage(Microsoft.Maui.Graphics.IImage image, float x, float y, float width, float height)
    {
    }

    public void DrawLine(float x1, float y1, float x2, float y2)
    {
    }

    public void DrawPath(PathF path)
    {
    }

    public void DrawRectangle(float x, float y, float width, float height)
    {
    }

    public void DrawRoundedRectangle(float x, float y, float width, float height, float cornerRadius)
    {
    }

    public void DrawString(string value, float x, float y, HorizontalAlignment horizontalAlignment)
    {
    }

    public void DrawString(string value, float x, float y, float width, float height, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, TextFlow textFlow = TextFlow.ClipBounds, float lineSpacingAdjustment = 0)
    {
    }

    public void DrawText(IAttributedText value, float x, float y, float width, float height)
    {
    }

    public void FillArc(float x, float y, float width, float height, float startAngle, float endAngle, bool clockwise)
    {
    }

    public void FillEllipse(float x, float y, float width, float height)
    {
    }

    public void FillPath(PathF path, WindingMode windingMode)
    {
    }

    public void FillRectangle(float x, float y, float width, float height)
    {
    }

    public void FillRoundedRectangle(float x, float y, float width, float height, float cornerRadius)
    {
    }

    public SizeF GetStringSize(string value, IFont font, float fontSize)
    {
        return default;
    }

    public SizeF GetStringSize(string value, IFont font, float fontSize, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
    {
        return default;
    }

    public void ResetState()
    {
    }

    public bool RestoreState()
    {
        return true;
    }

    public void Rotate(float degrees, float x, float y)
    {
    }

    public void Rotate(float degrees)
    {
    }

    public void SaveState()
    {
    }

    public void Scale(float sx, float sy)
    {
    }

    public void SetFillPaint(Paint paint, RectF rectangle)
    {
    }

    public void SetShadow(SizeF offset, float blur, Color color)
    {
    }

    public void SubtractFromClip(float x, float y, float width, float height)
    {
    }

    public void Translate(float tx, float ty)
    {
    }
}
