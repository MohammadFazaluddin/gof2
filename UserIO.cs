namespace GameOfLife;

public class InputParser
{
    public List<Cell> ParseInput()
    {
        var initialCells = new List<Coordinate>();

        Console.WriteLine("Enter the number of cells you want to seed");
        string? seedStr = Console.ReadLine();
        int seedCells = 0;

        var convert = Int32.TryParse(seedStr, out seedCells);

        List<Cell> cordsList = new();

        Console.WriteLine("\nEnter cell co-ordinates");
        for (int i = 0; i < seedCells; ++i)
        {
            // considering input will be valid every time
            var inputCells = Console.ReadLine();

            if (!inputCells!.Contains(','))
            {
                Console.WriteLine("Invalid input format, enter comma separated values");
                --i;
                continue;
            }

            Int32.TryParse(inputCells!.Split(',')[0], out int x);

            Int32.TryParse(inputCells!.Split(',')[1], out int y);

            cordsList.Add(new Cell(x, y, true));
        }

        return cordsList;
    }
}

