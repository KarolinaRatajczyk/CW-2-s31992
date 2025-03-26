namespace CW2.Classes;

public class Ship
{
    public List<Container> Containers { get; } = new ();
    public double MaxSpeed { get; }
    public double MaxLoadTons { get; }
    public int MaxContainerCount { get; }

    public Ship(double maxSpeed, double maxLoadTons, int maxContainerCount)
    {
        MaxSpeed = maxSpeed;
        MaxLoadTons = maxLoadTons;
        MaxContainerCount = maxContainerCount;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
            throw new InvalidOperationException("Too many containers");
        
        double currentWeight = container.ContainerWeight + container.CurrentLoadWeight + TotalWeight();
        if (currentWeight > MaxLoadTons * 1000)
            throw new InvalidOperationException("It would exceed allowed max load on ship.");
        
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException("No container on ship with that serial number");
        Containers.Remove(container);
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
            throw new InvalidOperationException("No container on ship with that serial number");
        
        double newTotalWeight = TotalWeight() - 
                                (Containers[index].CurrentLoadWeight + Containers[index].ContainerWeight) + 
                                newContainer.ContainerWeight + newContainer.CurrentLoadWeight;
        if (newTotalWeight > MaxLoadTons * 1000)
            throw new InvalidOperationException("It would exceed allowed max load on ship.");
        
        Containers[index] = newContainer;
    }

    public void TransferContainer(string serialNumber, Ship targetShip)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new InvalidOperationException("No container on ship with that serial number");
        
        targetShip.LoadContainer(container);
        Containers.Remove(container);
    }
    
    public double TotalWeight()
    {
        return Containers.Sum(c => c.ContainerWeight + c.CurrentLoadWeight);
    }

    public override string ToString()
    {
        string shipInfo = "Ship speed: " + MaxSpeed + 
                          " knots, max containers number: " + MaxContainerCount + 
                          " max load: " + MaxLoadTons + " tons\n" + 
                          "Current containers: " + Containers.Count + 
                          " Total weight: " + TotalWeight()/1000 + " tons\n";
        string containersInfo = string.Join("\n", Containers.Select(c => 
            $"- {c.SerialNumber}: {c.GetType().Name}, Weight: {c.ContainerWeight + c.CurrentLoadWeight} kg"));
        
        return shipInfo + containersInfo;
    }
}