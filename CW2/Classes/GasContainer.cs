using CW2.Exceptions;
using CW2.Interfaces;

namespace CW2.Classes;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set;  }

    public GasContainer(double height, double depth, double containerWeight, double maxLoad, double pressure)
        : base(height, depth, containerWeight, maxLoad)
    {
        Pressure = pressure;
    }

    public override void Load(double weight)
    {
        if (CurrentLoadWeight + weight > MaxLoad)
        {
            NotifyHazard("Attempt to overload container.");
            throw new OverfillException(
                "Dangerous situation - load weight is greater than allowed container load weight");
        }
        base.Load(weight);
    }

    public override void UnLoad()
    {
        CurrentLoadWeight = 0.05 * CurrentLoadWeight;
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