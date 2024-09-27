namespace GameOfLife;

public class Grid : IGrid
{
    private HashSet<Cell> _liveCells;
    private ISimulationRules _rules;

    public Grid(List<Cell> initial, ISimulationRules rules)
    {
        _liveCells = new(initial);

        _rules = rules;
    }

    public void UpdateNextGeneration()
    {
        _liveCells = NextGeneration(_liveCells, _rules);
    }

    public HashSet<Cell> GetLiveCells()
    {
        return _liveCells;
    }

    // should be pure function
    private HashSet<Cell> NextGeneration(HashSet<Cell> currentLiveCells, ISimulationRules rules)
    {
        var newLiveCells = new HashSet<Cell>();
        var neighbourCells = new HashSet<Cell>();

        foreach (var cell in currentLiveCells)
        {
            neighbourCells.Add(cell);
            foreach (var neighbour in GetNeighbours(cell))
            {
                if (!neighbourCells.Any(c => c.Equals(neighbour)))
                    neighbourCells.Add(neighbour);

            }
        }

        foreach (var cell in neighbourCells)
        {
            var liveNeighbours = GetLiveNeighborCount(cell, currentLiveCells);
            bool isAlive = currentLiveCells.Contains(cell);

            bool nextState = rules.CheckCellState(isAlive, liveNeighbours);

            if (nextState)
            {
                newLiveCells.Add(cell);
            }
        }

        return newLiveCells;
    }

    private IEnumerable<Cell> GetNeighbours(Cell cell)
    {
        int[] offsets = { -1, 0, 1 };
        foreach (int dx in offsets)
        {
            foreach (int dy in offsets)
            {
                if (cell.Position.X + dx < 0 || cell.Position.Y + dy < 0) continue;
                if (dx == 0 && dy == 0) continue;
                yield return new Cell(cell.Position.X + dx, cell.Position.Y + dy, false);
            }
        }
    }

    private int GetLiveNeighborCount(Cell cell, HashSet<Cell> liveCells)
    {
        int liveCount = 0;

        foreach (var neighbour in GetNeighbours(cell))
            if (liveCells.Any(c => c.Position.Equals(neighbour.Position)))
                liveCount++;

        return liveCount;
    }

}

