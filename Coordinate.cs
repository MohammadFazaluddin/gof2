namespace GameOfLife;

public class Coordinate
{
    public int X { get; }

    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Coordinate coordObj = (Coordinate)obj;
        return coordObj.X == X && coordObj.Y == Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

