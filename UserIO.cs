namespace GameOfLife;

public class UserIO
{
    public List<Coordinate> GetInitialSetup()
    {
        var initialCells = new List<Coordinate>();

        Console.WriteLine("Enter the number of cells you want to seed");
        string? seedStr = Console.ReadLine();
        int seedCells = 0;

        var convert = Int32.TryParse(seedStr, out seedCells);

        List<Coordinate> cordsList = new();

        Console.WriteLine("\nEnter cell co-ordinates");
        for (int i = 0; i < seedCells; ++i)
        {
            // considering input will be valid every time
            var inputCells = Console.ReadLine();

            Int32.TryParse(inputCells!.Substring(0, 1), out int x);

            Int32.TryParse(inputCells!.Substring(3, 1), out int y);

            cordsList.Add(new Coordinate(x, y));
        }

        return cordsList;
    }
}

