namespace CW2.Classes;

public abstract class Container(double cargoWeight, double height, double containerWeight, double depth, double maxLoad)
{
    private static int _nextId = 0;

    public int Id { get; } = _nextId++;
    public double CargoWeight { get; set; } = cargoWeight;
    public double Height { get; set; } = height;
    public double ContainerWeight { get; set; } = containerWeight;
    public double Depth { get; set; } = depth;
    public double MaxLoad { get; set; } = maxLoad;
}