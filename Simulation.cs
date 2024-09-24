namespace GameOfLife;

public class Simulation
{
    public void StartSimulation(List<Coordinate> initialCells)
    {
        var rules = new SimulationRules();
        var grid = new Grid(initialCells, rules);

        grid.GetNextGeneration();

        Console.WriteLine("Output: ");
        grid.DisplayLiveCells();
    }

}

