namespace GameOfLife;

public interface IGrid
{

    void UpdateNextGeneration();

    HashSet<Cell> GetLiveCells();
}

