namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MAX_HEIGHT = 30;
            int MAX_WIDTH = 30;

            Simulation simulation = new(MAX_HEIGHT, MAX_WIDTH);

            Console.WriteLine("Enter the number of cells you want to seed");
            string? seedStr = Console.ReadLine();
            int seedCells = 0;

            var convert = Int32.TryParse(seedStr, out seedCells);

            List<Cordinates> cordsList = new();
            Cordinates cords;

            Console.WriteLine("\nEnter cell co-ordinates");
            for (int i = 0; i < seedCells; ++i)
            {
                // considering input will be valid every time
                var inputCells = Console.ReadLine();
                int outValue;
                cords = new();
                Int32.TryParse(inputCells!.Substring(0, 1), out outValue);
                cords.XCord = outValue;

                Int32.TryParse(inputCells!.Substring(3, 1), out outValue);
                cords.YCord = outValue;

                cordsList.Add(cords);
            }

            var nextGenCords = simulation.GetNextGenerationCells(cordsList);

            Console.WriteLine("\nOutput: ");
            foreach (var live in nextGenCords)
            {
                Console.WriteLine($"{live.XCord}, {live.YCord}");
            }

        }

    }
}

