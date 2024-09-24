namespace GameOfLife;

public class SimulationRules
{
    public bool CheckCellState(bool isAlive, int liveNeighbour)
    {
        // Any live cell with fewer than two live neighbours dies,
        // as if by loneliness.
        if (liveNeighbour < 2)
        {
            return false;
        }

        // Any live cell with more than three live neighbours dies, 
        // as if by overcrowding
        if (liveNeighbour >= 4)
        {
            return false;
        }

        // Any dead cell with exactly three live neighbours comes to life.
        if (liveNeighbour == 3)
        {
            return true;
        }

        return isAlive;
    }
}

