namespace GameOfLife;

public class Cell
{
    public bool IsAlive { get; private set; }
    public Coordinate Position { get; }

    public Cell(int x, int y, bool alive)
    {
        IsAlive = alive;
        Position = new(x, y);
    }

    public void SetSatet(bool state)
    {
        IsAlive = state;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Cell other = (Cell)obj;

        return IsAlive == other.IsAlive && Position.Equals(other.Position);
    }

    public override int GetHashCode()
    {
        return Position.GetHashCode();
    }

}

