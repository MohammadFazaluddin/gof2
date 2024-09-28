namespace GameOfLife;

public class InputParser
{
    public List<Cell> ParseInput()
    {
        var initialCells = new List<Coordinate>();

        List<Cell> cordsList = new();

        Console.WriteLine("Input: ");

        var inputCells = Console.ReadLine();
        do
        {
            // considering input will be valid every time
            if (!inputCells!.Contains(','))
            {
                Console.WriteLine("Invalid input format, enter comma separated values");
                continue;
            }

            Int32.TryParse(inputCells!.Split(',')[0], out int x);

            Int32.TryParse(inputCells!.Split(',')[1], out int y);

            cordsList.Add(new Cell(x, y, true));

            inputCells = Console.ReadLine();
        }
        while (!string.IsNullOrWhiteSpace(inputCells));

        return cordsList;
    }
}

