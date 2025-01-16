using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    
    public Map Map { get; }

    
    public List<IMappable> Mappables { get; }

    
    public List<Point> Positions { get; }

    
    public string Moves { get; }

    
    public bool Finished = false;

    
    public IMappable CurrentMappable { get { return Mappables[moveIndex % Mappables.Count]; } }

   
    public string CurrentMoveName { get { return Moves[moveIndex % Moves.Length].ToString().ToLower(); } }

   
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
        {
            throw new ArgumentException("Objects list can't be empty.");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("The number of objects must match the number of positions.");
        }

        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;

        // Assign the map and initial positions to each mappable object
        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].AssignMap(map, positions[i]);
        }
    }

    private int moveIndex = 0;

    /// <summary>
    /// Makes one move of the current object in the current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation has already finished.");
        }

        // Get the direction from the moves list
        var direction = DirectionParser.Parse(CurrentMoveName)[0];

        // Move the current object
        CurrentMappable.Go(direction);

        // If all moves have been performed, finish the simulation
        moveIndex++;
        if (moveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
