using CW2.Exceptions;
using CW2.Interfaces;

namespace CW2.Classes;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double height, double depth, double containerWeight, double maxLoad, double pressure)
        : base(height, depth, containerWeight, maxLoad)
    {
        Pressure = pressure;
    }
    
    public override void UnLoad()
    {
        CurrentLoadWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard ALERT: " + message + " - Container: " + SerialNumber);
    }
    
    public override string GetContainerInfo()
    {
        return $"{base.GetContainerInfo()}, Pressure: {Pressure} atm";
    }
}