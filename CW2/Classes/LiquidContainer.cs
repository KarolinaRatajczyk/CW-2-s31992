using CW2.Interfaces;

namespace CW2.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double weight, double depth, double containerWeight, double maxLoad, bool isHazardous)
        : base(weight, depth, containerWeight, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double allowedWeight = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (CurrentLoadWeight + weight > allowedWeight)
            throw new OverflowException("Dangerous situation - load weight is greater than allowed container load weight");
        base.Load(weight);
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard ALERT: " + message + " - Container: " + SerialNumber);
    }
}