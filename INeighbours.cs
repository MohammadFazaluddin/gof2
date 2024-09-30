namespace GameOfLife;

public interface INeighbour
{
    HashSet<Cell> GenerateNeighbours(HashSet<Cell> initialLiveCells);

    int GetLiveNeighborCount(Cell cell, HashSet<Cell> liveCells, HashSet<Cell> currentCells);
}

