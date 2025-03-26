namespace CW2.Classes;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; set; }

    public RefrigeratedContainer(double height, double depth, double containerWeight, double maxLoad,
        double temperature)
        : base(height, depth, containerWeight, maxLoad)
    {
        Temperature = temperature;
    }
}