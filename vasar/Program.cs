using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vasar
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> kosar = new Dictionary<string, int>();
            var raktar = new Dictionary<string, int> { { "ez", 10 }, {"az", 30 }, {"amaz", 3 }, {"csoki", 100 }, {"semmi", 0 } };
            List<int> ar = new List<int>();
            ar = Arak(ar, raktar.Count);
            int menu, biztos;
            do
            {
                
                Console.WriteLine("1. árucikkek feltöltése a kosárba\n2. árucikkek feltöltése a raktárba\n3. kosár megtekintése\n4. Raktár megtekitése\n5. Elem eltávolítása a kosárból\n6. Kosár ürítése\n7. vásárlás szimulálása\n\n8. Kilépés\nMit szeretne csinálni?\n->");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        kosar = KosarFeltoltes(kosar, raktar);
                        raktar = TermekLevonas(raktar, kosar);
                        break;
                    case 2:
                        raktar = RaktarFeltoltes(raktar);
                        ar = Arak(ar, raktar.Count);
                        break;
                    case 3:
                        Kiiras(kosar);
                        break;
                    case 4:
                        Kiiras(raktar);
                        break;
                    case 5:
                        KosarEltavolitas(kosar);
                        break;
                    case 6:
                        Console.WriteLine("1. igen\n bármi más: nem\nBiztos vagy benne?\n->");
                        biztos = Convert.ToInt32(Console.ReadLine());
                        if (biztos == 1)
                            kosar.Clear();
                        break;
                    case 7:
                        Fizetes(kosar, ar, raktar);
                        break;
                    case 8:
                        Console.WriteLine("Ön a kilépést választotta! Viszontlátásra!");
                        Console.ReadLine();
                        break;
                    default:
                        break;

                }
            }
            while (menu != 8);
        }

        static Dictionary<string, int> Fizetes(Dictionary<string, int> kosar, List<int> ar, Dictionary<string, int> raktar)
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < raktar.Count; i++)
            {
                if (kosar.ContainsKey(raktar.ElementAt(i).Key))
                {
                    Console.WriteLine($"item: {raktar.ElementAt(i).Key}, menyiség: {kosar[raktar.ElementAt(i).Key]}, összeg: {kosar[raktar.ElementAt(i).Key] * ar[i]}");
                }
            }
            Console.WriteLine("\n\n");
            kosar.Clear();
            return kosar;


        }

        static Dictionary<string, int> KosarFeltoltes(Dictionary<string, int> kosar, Dictionary<string, int> raktar)
        {
            string kosarstr;
            int mennyiseg, veg = 0;
            do
            {
                Console.WriteLine("Mit szeretne hozzáadni a kosarához?\n->");
                kosarstr = Console.ReadLine();
                if (kosarstr != null && raktar.ContainsKey(kosarstr))
                {
                    Console.WriteLine($"mennyit szeretne hozzáadni ebből a termékből? (még van belőle {raktar[kosarstr]})\n->");
                    mennyiseg = Convert.ToInt32(Console.ReadLine());
                    if (mennyiseg > 0 && mennyiseg <= raktar[kosarstr])
                    {
                        kosar.Add(kosarstr, mennyiseg);
                        Console.WriteLine("Termék sikeresen hozzáadva a kosárhoz!");
                        veg++;
                    }
                    else
                    {
                        Console.WriteLine("kérem hogy értelmes értéket adjon meg");
                    }
                }
                else
                {
                    Console.WriteLine("Kérem adjon meg egy a raktárban szereplő értéket \n\n");
                }
            } while (veg == 0);
            return kosar;
        }

        static Dictionary<string, int> TermekLevonas(Dictionary<string, int> raktar, Dictionary<string, int> kosar)
        {
            if (kosar.Count > 0) 
                raktar[kosar.ElementAt(kosar.Count-1).Key] -= kosar.ElementAt(kosar.Count-1).Value;
            return raktar;
        }

        static Dictionary<string, int> RaktarFeltoltes(Dictionary<string, int> raktar)
        {
            string raktarstr;
            int mennyiseg, veg = 0;
            do
            {
                Console.WriteLine("Mit szeretne hozzáadni a raktárhoz?\n->");
                raktarstr = Console.ReadLine();
                if (raktarstr != null)
                {
                    Console.WriteLine("mennyit szeretne hozzáadni ebből a termékből?\n->");
                    mennyiseg = Convert.ToInt32(Console.ReadLine());
                    if (mennyiseg > 0)
                    {
                        raktar.Add(raktarstr, mennyiseg);
                        Console.WriteLine("Termék sikeresen hozzáadva a raktárhoz!");
                    }
                    else
                    {
                        Console.WriteLine("kérem hogy 0-nál nagyobb értéket adjon meg");
                    }
                }
                else
                {
                    Console.WriteLine("Kérem adjon meg egy nem NULL értéket");
                }
                Console.WriteLine("1. igen\n2. nem\nMégegy?\n->");
                veg = Convert.ToInt32(Console.ReadLine());
            }
            while (veg == 1);
            return raktar;
        }

        static List<int> Arak(List<int> ar, int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                if (ar.Count < i)
                {
                    ar.Add(rnd.Next(1000, 10000));
                }
            }
            return ar;
        }

        static void Kiiras(Dictionary<string, int> dict)
        {
            int i;
            foreach (KeyValuePair<string, int> item in dict)
            { 
                
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }


        static Dictionary<string, int> KosarEltavolitas(Dictionary<string, int> kosar)
        {
            string elem;
            Kiiras(kosar);
            Console.WriteLine("\nmelyik elemet kívánja eltávoltani?");
            elem = Console.ReadLine();

            if (kosar.ContainsKey(elem))
                kosar.Remove(elem);


            return kosar;
        }

    }
}
