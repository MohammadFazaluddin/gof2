namespace GameOfLife;

public class GridDisplay : IDisplay
{

    public void Display(Grid grid)
    {
        foreach (var cell in grid.GetLiveCells())
            Console.WriteLine($"{cell.Position.X}, {cell.Position.Y}");
    }
}

