namespace GameOfLife;

public class Grid : IGrid
{
    private HashSet<Cell> _liveCells;
    private ISimulationRules _rules;
    private INeighbour _neighbour;

    public Grid(List<Cell> initial, ISimulationRules rules, INeighbour neighbour)
    {
        _liveCells = new(initial);

        _rules = rules;

        _neighbour = neighbour;
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

        var neighbourCells = _neighbour.GenerateNeighbours(currentLiveCells);

        foreach (var cell in neighbourCells)
        {
            var liveNeighbours = _neighbour.GetLiveNeighborCount(cell, currentLiveCells, neighbourCells);
            bool isAlive = currentLiveCells.Contains(cell);

            if (rules.CheckCellState(isAlive, liveNeighbours))
            {
                newLiveCells.Add(cell);
            }
        }

        return newLiveCells;
    }

}

