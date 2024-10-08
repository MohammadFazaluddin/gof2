namespace GameOfLife;

public class Cell : IEquatable<Cell>
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

    // this will help using Contains method which will use this method 
    // (documentation said so)
    public bool Equals(Cell? other)
    {
        if (other is null)
            return false;

        return this.Position.Equals(other.Position);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
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

