namespace GameOfLife;

public interface ISimulationRules
{
    public bool CheckCellState(bool isAlive, int liveNeighbour);
}

