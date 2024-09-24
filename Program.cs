namespace GameOfLife;

internal class Program
{
    static void Main(string[] args)
    {
        Simulation simulation = new();
        UserIO userInput = new();

        var initialSeed = userInput.GetInitialSetup();

        simulation.StartSimulation(initialSeed);
    }
}

