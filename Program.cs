namespace GameOfLife;

internal class Program
{
    static void Main(string[] args)
    {

        InputParser userInput = new();
        var initialSeed = userInput.ParseInput();

        ISimulationRules rules = new SimulationRules();
        INeighbour neighbour = new Neighbours();

        IGrid grid = new Grid(initialSeed, rules, neighbour);

        IDisplay gridDisplay = new GridDisplay();

        Simulation simulation = new(rules, grid, gridDisplay);

        simulation.Start();
    }
}

