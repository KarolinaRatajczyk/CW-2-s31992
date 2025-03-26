using CW2.Exceptions;

namespace CW2.Classes;

public abstract class Container
{  
    private static int _idCounter = 1;
    
    public string SerialNumber { get; private set; }
    public double CurrentLoadWeight { get; protected set; } = 0;
    public double Height { get; private set; }
    public double Depth { get; private set; }
    public double ContainerWeight { get; private set; }
    public double MaxLoad { get; private set;  }


    public Container(double height, double depth, double containerWeight, double maxLoad)
    {
        SerialNumber = GenerateSerialNumber();
        Height = height;
        Depth = depth;
        ContainerWeight = containerWeight;
        MaxLoad = maxLoad;
    }
    
    
    private string GenerateSerialNumber()
    {
        return "KON-" + GetType().Name[0] + "-" + (_idCounter++);
    }
    
    public virtual void UnLoad()
    {
        CurrentLoadWeight = 0;
    }

    public virtual void Load(double weight)
    {
        if (CurrentLoadWeight + weight > MaxLoad)
            throw new OverfillException("Load weight is greater than maximum container load weight");
        CurrentLoadWeight += weight;
    }
}