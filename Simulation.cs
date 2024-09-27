namespace GameOfLife;

public class Simulation
{
    private readonly ISimulationRules _rules;
    private readonly IGrid _grid;
    private readonly IDisplay _display;

    public Simulation(ISimulationRules rules, IGrid grid, IDisplay display)
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

