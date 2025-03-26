using CW2.Classes;

class Program
{
    public static void Main()
    {
        //w moim kodzie kontener chłodniczy ma numery seryjne z literą R, ponieważ zrobiłam wszystkie nazwy po angielsku
        //(zamiast KON-C-1 jest KON-R-1)
        
        //Stworzenie kontenera danego typu
        LiquidContainer kontenerL1 = new LiquidContainer(350, 200, 80, 450, true);
        GasContainer kontenerG1 = new GasContainer(200, 150, 100, 200, 2.5);
        RefrigeratedContainer kontenerC1 = new RefrigeratedContainer(320, 260, 150, 280, "Butter", 21);
        
        //Załadowanie ładunku do danego kontenera
        kontenerL1.Load(150);
        // kontenerL1.Load(100);
        Console.WriteLine(kontenerL1.GetContainerInfo());
        kontenerG1.Load(190);
        Console.WriteLine(kontenerG1.GetContainerInfo());
        kontenerC1.Load(250);
        Console.WriteLine(kontenerC1.GetContainerInfo());

        //Załadowanie kontenera na statek
        Ship ship1 = new Ship(30, 4000, 20000);
        Ship ship2 = new Ship(25, 100, 225);
        ship1.LoadContainer(kontenerL1);
        Console.WriteLine(ship1.ToString());

        //Załadowanie listy kontenerów na statek
        List<Container> containers = new List<Container> { kontenerL1, kontenerG1, kontenerC1 };
        ship2.LoadContainers(containers);
        Console.WriteLine(ship2.ToString());
        
        //Usunięcie kontenera ze statku
        ship2.RemoveContainer(kontenerL1);
        Console.WriteLine(ship2.ToString());
        
        //Rozładowanie kontenera
        Console.WriteLine("przed rozładowaniem: " + kontenerG1.CurrentLoadWeight + "kg");
        kontenerG1.UnLoad();
        Console.WriteLine("po rozładowaniu: " + kontenerG1.CurrentLoadWeight + "kg");
        
        //Zastąpienie kontenera na statku o danym numerze innym kontenerem
        // ship1.ReplaceContainer("KON-G-2", kontenerC1);
        Console.WriteLine("przed zamianą: " + ship1.ToString());
        ship1.ReplaceContainer("KON-L-1", kontenerC1);
        Console.WriteLine("po zamianie: " + ship1.ToString());
        
        //Możliwość przeniesienie kontenera między dwoma statkami
        Console.WriteLine("Przed transferem:");
        Console.WriteLine(ship1.ToString());
        Console.WriteLine(ship2.ToString());
        ship2.TransferContainer("KON-R-3", ship1);
        Console.WriteLine("Po transferze:");
        Console.WriteLine(ship1.ToString());
        Console.WriteLine(ship2.ToString());
    }
}