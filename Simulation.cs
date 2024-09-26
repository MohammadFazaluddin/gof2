namespace GameOfLife;

public class Simulation
{
    private readonly ISimulationRules _rules;
    private readonly Grid _grid;
    private readonly IDisplay _display;

    public Simulation(ISimulationRules rules, Grid grid, IDisplay display)
    {
        _rules = rules;
        _grid = grid;
        _display = display;
    }

    public void Start()
    {
        _grid.UpdateNextGeneration();

        Console.WriteLine("Output: ");
        _display.Display(_grid);
    }

}

