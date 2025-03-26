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
    protected double MaxLoad { get; }


    public Container(double height, double depth, double containerWeight, double maxLoad)
    {
        if (height <= 0 || depth <= 0 || containerWeight <= 0 || maxLoad <= 0)
            throw new ArgumentException("All parameters must be grater than zero.");
        
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

    public virtual string GetContainerInfo()
    {
        return GetType().Name + 
               " - Serial number: " + SerialNumber + 
               ", Max load: " + MaxLoad + 
               " kg, Container weight: " + ContainerWeight + " kg";
    }
}