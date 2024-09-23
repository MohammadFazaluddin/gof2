namespace GameOfLife;

public class Grid
{

    private int _rows { get; }
    private int _cols { get; }
    private bool[,] _state { get; set; }

    public int Height { get => _rows; }
    public int Width { get => _cols; }

    public Grid(int height, int width)
    {
        this._rows = height;
        this._cols = width;
        this._state = new bool[height, width];
    }

    private bool IsValidCords(int row, int col)
    {
        return col < Width && col >= 0 && row < Height && row >= 0;
    }


    public void SetCellValue(int row, int col, bool value)
    {
        if (IsValidCords(row, col))
            _state[row, col] = value;

        // might throw an error to inform value was not set,
    }

    public bool GetCellValue(int row, int col)
    {
        if (IsValidCords(row, col))
            return _state[row, col];

        return false;
    }

    public List<Cordinates> GetLiveCells()
    {
        List<Cordinates> cords = new();
        // int[,] cords = new int[
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                if (GetCellValue(i, j))
                    cords.Add(new Cordinates { YCord = i, XCord = j });
            }
        }
        return cords;
    }

}

