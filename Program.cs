namespace GameOfLife;

internal class Program
{
    static void Main(string[] args)
    {

        InputParser userInput = new();
        var initialSeed = userInput.ParseInput();

        ISimulationRules rules = new SimulationRules();
        IGrid grid = new Grid(initialSeed, rules);
        IDisplay gridDisplay = new GridDisplay();
        Simulation simulation = new(rules, grid, gridDisplay);

        simulation.Start();
    }
}

