namespace GameOfLife
{
    public class Simulation
    {
        private Grid _grid;

        public Simulation(int height, int width)
        {
            _grid = new(height, width);
        }

        public List<Cordinates> GetNextGenerationCells(List<Cordinates> seed)
        {
            foreach (var cords in seed)
            {
                _grid.SetCellValue(cords.YCord, cords.XCord, true);
            }

            _grid = NextGeneration(_grid);

            return _grid.GetLiveCells();
        }

        public Grid NextGeneration(Grid current)
        {
            int height = current.Height;
            int width = current.Width;
            Grid outState = new Grid(height, width);

            for (int row = 0; row < height; ++row)
            {
                for (int col = 0; col < width; ++col)
                {
                    outState.SetCellValue(row, col, current.GetCellValue(row, col));
                    int count = GetLiveNeighboursCount(current, row, col);

                    // Any live cell with fewer than two live neighbours dies,
                    // as if by loneliness.
                    if (count < 2)
                    {
                        outState.SetCellValue(row, col, false);
                    }

                    // Any live cell with more than three live neighbours dies, 
                    // as if by overcrowding
                    if (count >= 4)
                    {
                        outState.SetCellValue(row, col, false);
                    }

                    // Any dead cell with exactly three live neighbours comes to life.
                    if (count == 3)
                    {
                        outState.SetCellValue(row, col, true);
                    }
                }
            }

            return outState;
        }

        private short GetLiveNeighboursCount(Grid current, int y, int x)
        {
            // X(-1, -1)    X(-1, 0)    X(-1, 1)
            // X(0, -1)     (y, x)      X(0, 1)
            // X(1, -1)     X(1, 0)     X(1, 1)

            int[,] neighbours = {
                {-1, -1},
                {0, -1},
                {1, -1},
                {1, 0},
                {1, 1},
                {0, 1},
                {-1, 1},
                {-1, 0},
            };

            short count = 0;

            for (int i = 0; i < neighbours.GetLength(0); ++i)
            {
                int row = y + neighbours[i, 0];
                int col = x + neighbours[i, 1];

                if (current.GetCellValue(row, col))
                    count++;
            }

            return count;
        }
    }
}

