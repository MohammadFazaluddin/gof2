namespace GameOfLife;

public class Grid
{
    private List<Coordinate> _liveCells;
    private SimulationRules _rules;

    public Grid(List<Coordinate> initial, SimulationRules rules)
    {
        _liveCells = new(initial);

        _rules = rules;
    }

    public void GetNextGeneration()
    {
        _liveCells = NextGeneration(_liveCells);
    }

    public void DisplayLiveCells()
    {
        foreach (var cell in _liveCells)
            Console.WriteLine($"{cell.X}, {cell.Y}");
    }

    public List<Coordinate> GetAllLiveCells()
    {
        return _liveCells;
    }

    // should be pure function
    public List<Coordinate> NextGeneration(List<Coordinate> currentLiveCells)
    {
        var newLiveCells = new List<Coordinate>();
        var neighbourCells = new List<Coordinate>();

        foreach (var cell in currentLiveCells)
        {
            neighbourCells.Add(cell);
            foreach (var neighbour in GetNeighbours(cell))
            {
                neighbourCells.Add(neighbour);
            }
        }

        foreach (var cell in neighbourCells)
        {
            var liveNeighbours = GetLiveNeighborCount(cell, currentLiveCells);
            bool isAlive = currentLiveCells.Contains(cell);

            bool nextState = _rules.CheckCellState(isAlive, liveNeighbours);

            if (nextState &&
                    !newLiveCells.Any(o => o.X == cell.X && o.Y == cell.Y))
            {
                newLiveCells.Add(cell);
            }
        }

        return newLiveCells;
    }

    private IEnumerable<Coordinate> GetNeighbours(Coordinate cell)
    {
        int[] offsets = { -1, 0, 1 };
        foreach (int dx in offsets)
        {
            foreach (int dy in offsets)
            {
                if (cell.X + dx < 0 || cell.Y + dy < 0) continue;
                if (dx == 0 && dy == 0) continue;
                yield return new Coordinate(cell.X + dx, cell.Y + dy);
            }
        }
    }

    private int GetLiveNeighborCount(Coordinate cell, List<Coordinate> liveCells)
    {
        int liveCount = 0;

        foreach (var neighbour in GetNeighbours(cell))
            if (liveCells.Any(o => o.X == neighbour.X && o.Y == neighbour.Y))
                liveCount++;

        return liveCount;
    }

}

