using CW2.Interfaces;

namespace CW2.Classes;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public double Temperature { get; set; }

    public RefrigeratedContainer(double height, double depth, double containerWeight, double maxLoad, double temperature)
        : base(height, depth, containerWeight, maxLoad)
    {
        Temperature = temperature;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard ALERT: " + message + " - Container: " + SerialNumber);
    }
}