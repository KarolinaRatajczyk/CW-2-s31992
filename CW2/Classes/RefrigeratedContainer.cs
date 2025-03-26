using CW2.Interfaces;

namespace CW2.Classes;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }
    private static Dictionary<string, double> _productTemperatures = new()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    public RefrigeratedContainer(double height, double depth, double containerWeight, double maxLoad, string productType, double temperature)
        : base(height, depth, containerWeight, maxLoad)
    {
        if(!_productTemperatures.ContainsKey(productType))
            throw new ArgumentException("Invalid product type.");
        if(temperature < _productTemperatures[productType])
            throw new ArgumentException("Temperature too low for " + productType);
        
        ProductType = productType;
        Temperature = temperature;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazard ALERT: " + message + " - Container: " + SerialNumber);
    }

    public override string GetContainerInfo()
    {
        return $"{base.GetContainerInfo()}, Product type: {ProductType}, Temperature: {Temperature} Celsius";
    }
}