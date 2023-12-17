using System.Reflection;

namespace Parprogrammering_3
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                System.Console.OutputEncoding = System.Text.Encoding.Unicode;
                Menu();
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void ShouldCustomerBuy(int i)
        {
            switch (Ask("Vil du kjøpe denne bilen? y/n"))
            {
                case "y":
                    Console.Clear();
                    Kunde.Add(Bilforhandler[i]);
                    Bilforhandler.RemoveAt(i);

                    Console.WriteLine("\nKunden sine biler\n");

                    foreach (var bil in Kunde)
                    {
                        bil.GetCarInfo();
                    }
                    break;
                case "n":
                    break;
            }
        }
        private static void Menu()
        {
            switch (AskInt("Vil du:\n(1) Se på bilutvalget\n(2) Finne bil etter årsmodell\n(3) Søke opp bil basert på km.stand?"))
            {
                case 1:
                    ViewCars();
                    break;
                case 2:
                    Console.Clear();
                    switch (AskInt($"Hvilken årsmodel vil du ha? {EachYearModel()} "))
                    {
                        case 1999:
                            Console.Clear();
                            Bilforhandler[6].GetCarInfo();
                            ShouldCustomerBuy(6);
                            break;
                        case 2018:
                            Console.Clear();
                            Bilforhandler[1].GetCarInfo();
                            ShouldCustomerBuy(1);
                            break;
                        case 2019:
                            Console.Clear();
                            Bilforhandler[3].GetCarInfo();
                            ShouldCustomerBuy(3);
                            break;
                        case 2020:
                            Console.Clear();
                            Bilforhandler[5].GetCarInfo();
                            ShouldCustomerBuy(5);
                            break;
                        case 2021:
                            Console.Clear();
                            Bilforhandler[0].GetCarInfo();
                            ShouldCustomerBuy(0);
                            break;
                        case 2022:
                            Console.Clear();
                            Bilforhandler[4].GetCarInfo();
                            ShouldCustomerBuy(4);
                            break;
                        case 2023:
                            Console.Clear();
                            Bilforhandler[2].GetCarInfo();
                            ShouldCustomerBuy(2);
                            Bilforhandler[7].GetCarInfo();
                            ShouldCustomerBuy(7);
                            break;
                        default:
                            Environment.Exit(1);
                            break;
                    }

                    break;
                case 3:
                    Console.Clear();
                    switch (AskInt("Vil du sortere etter:\n1. større enn\n2. mindre enn"))
                    {
                        case 1:
                            SortByKilometersHigherThan(AskInt("Minimum kilometerstand?"));
                            break;
                        case 2:
                            SortByKilometersLowerThan(AskInt("Maksimum kilometerstand?"));
                            break;
                        default:
                            Environment.Exit(1);
                            break;
                    }

                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }

        private static string EachYearModel()
        {
            string år = null;
            foreach (var bil in Bilforhandler)
            {
                år += $"\n* {bil._årsmodell}";
            }
            return år;
        }

        private static void SortByKilometersHigherThan(int kilometer)
        {
            Console.Clear();
            int i = 0;
            foreach (var bil in Bilforhandler)
            {
                i++;
                if (bil.Kilometerstand > kilometer)
                {
                    Console.WriteLine(i);
                    bil.GetCarInfo();
                }
            }
            ShouldCustomerBuy(AskInt("Hvilken bil vil du kjøpe?") - 1);
        }
        private static void SortByKilometersLowerThan(int kilometer)
        {
            Console.Clear();
            int i = 0;
            foreach (var bil in Bilforhandler)
            {
                i++;
                if (bil.Kilometerstand < kilometer)
                {
                    Console.WriteLine(i);
                    bil.GetCarInfo();
                }
            }
            ShouldCustomerBuy(AskInt("Hvilken bil vil du kjøpe?") - 1);
        }

        public static List<Bil> Bilforhandler = new List<Bil>()
        {
            new Bil("Audi RS3", 2021, "SV12634", 3000, 800000 ),
            new Bil("Porsche 911", 2018, "VB10924", 28000, 1300000 ),
            new Bil("Tesla Model Y", 2023, "EL16664", 500, 1000000 ),
            new Bil("Nissan GTR", 2019, "DR61629", 14000, 700000 ),
            new Bil("BYD TANG", 2022, "EL43286", 50000, 650000 ),
            new Bil("Ford Mustang Mach-E", 2020, "EL57364", 2800, 500000 ),
            new Bil("Nissan Skyline R33", 1999, "RL90152", 150000, 400000 ),
            new Bil("Audi RS6", 2023, "RS65432", 45000, 1250000)
        };

        public static List<Bil> Kunde = new List<Bil>();

        public static void ViewCars()
        {
            Console.Clear();
            foreach (var bil in Bilforhandler)
            {
                bil.GetCarInfo();
            }
        }

        public static string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int AskInt(string question)
        {
            return Convert.ToInt32(Ask(question));
        }
    }
}

//En bilforhandler har ulike biler i sjappa si, det kan være biler med ulike merker, årsmodell, registreringsnummer og kilometerstand. 
//Når kunden kommer inn skal han kunne se hvilke biler som finnes, eller han kan velge å finne en bil ut fra års-range, 
//eller en bil som har kjørt mer eller mindre enn en gitt kilometerstand. 
//Kunden skal også ha mulighet til å kjøpe en av bilene. Bilen må da tilhøre kunden og ikke forhandleren.