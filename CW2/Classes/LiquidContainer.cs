using CW2.Interfaces;
using CW2.Exceptions;

namespace CW2.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(double height, double depth, double containerWeight, double maxLoad, bool isHazardous)
        : base(height, depth, containerWeight, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        var allowedWeight = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (CurrentLoadWeight + weight > allowedWeight)
        {
            NotifyHazard("Attempt to overload container");
            throw new OverfillException("Dangerous situation - load weight is greater than allowed container load weight");
        }

        base.Load(weight);
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard ALERT: " + message + " - Container: " + SerialNumber);
    }
    
    public override string GetContainerInfo()
    {
        return $"{base.GetContainerInfo()}, Type of load: {(IsHazardous ? "Hazardous" : "Normal")}";
    }
}