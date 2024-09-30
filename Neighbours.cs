namespace GameOfLife;

public class Neighbours : INeighbour
{
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

