namespace MauiCanvas.Pages.Snake;

public class SnakePositionModel : IEquatable<SnakePositionModel>
{
    public SnakePositionModel(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public void Draw(ICanvas canvas, in float boardPieceHeight, in float boardPieceWidth)
    {
        canvas.FillRectangle(X * boardPieceWidth, Y * boardPieceHeight, boardPieceWidth, boardPieceHeight);
    }

    public override bool Equals(object obj)
    {
        return obj is SnakePositionModel other && Equals(other);
    }

    public bool Equals(SnakePositionModel other)
    {
        return other.X == X && other.Y == Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public static bool operator ==(SnakePositionModel r1, SnakePositionModel r2)
    {
        return r1.Equals(r2);
    }

    public static bool operator !=(SnakePositionModel r1, SnakePositionModel r2)
    {
        return !(r1 == r2);
    }
}
