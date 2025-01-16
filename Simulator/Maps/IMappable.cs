namespace Simulator.Maps;

public interface IMappable
{

    void AssignMap(Map map, Point startPosition);
    string Go(Direction direction);

    public char Symbol { get; } 
    public string ToString();
    

}

