namespace GameOfLife;

internal class Program
{
    static void Main(string[] args)
    {

        InputParser userInput = new();
        var initialSeed = userInput.ParseInput();

        var rules = new SimulationRules();
        var grid = new Grid(initialSeed, rules);
        var gridDisplay = new GridDisplay();
        Simulation simulation = new(rules, grid, gridDisplay);


        simulation.Start();
    }
}

