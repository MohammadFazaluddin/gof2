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

        var neighbourCells = GenerateNeighbours(currentLiveCells);

        foreach (var cell in neighbourCells)
        {
            var liveNeighbours = GetLiveNeighborCount(cell, currentLiveCells, neighbourCells);
            bool isAlive = currentLiveCells.Contains(cell);

            if (rules.CheckCellState(isAlive, liveNeighbours))
            {
                newLiveCells.Add(cell);
            }
        }

        return newLiveCells;
    }

    public HashSet<Cell> GenerateNeighbours(HashSet<Cell> initialLiveCells)
    {
        var neighbourCells = new HashSet<Cell>();

        foreach (var cell in initialLiveCells)
        {
            neighbourCells.Add(cell);
            foreach (var neighbour in GetNeighbours(cell))
            {
                if (!neighbourCells.Contains(neighbour))
                    neighbourCells.Add(neighbour);

            }
        }

        return neighbourCells;
    }

    private IEnumerable<Cell> GetNeighbours(Cell cell, HashSet<Cell>? currentCells = null)
    {
        int[] offsets = { -1, 0, 1 };
        foreach (int dx in offsets)
        {
            foreach (int dy in offsets)
            {
                int posX = cell.Position.X + dx;
                int posY = cell.Position.Y + dy;
                if (posX < 0 || posY < 0) continue;
                if (dx == 0 && dy == 0) continue;

                if (currentCells is not null)
                {
                    Cell? neighbourCell = currentCells.FirstOrDefault(c => c.Position.Equals(new Coordinate(posX, posY)));

                    if (neighbourCell is not null)
                        yield return neighbourCell;

                    continue;
                }
                else
                    yield return new Cell(posX, posY, false);
            }
        }
    }



    public int GetLiveNeighborCount(Cell cell, HashSet<Cell> liveCells, HashSet<Cell> currentCells)
    {
        int liveCount = 0;

        foreach (var neighbour in GetNeighbours(cell, currentCells))
            if (liveCells.Contains(neighbour))
                liveCount++;

        return liveCount;
    }
}

