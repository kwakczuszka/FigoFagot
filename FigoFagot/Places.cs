using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Places
{
    public class PlacesGraph
    {
        public static List<Places.Place> places = new List<Places.Place>() {
            new Places.MainStreet(),
            new Places.DiagonalAlly(),
            new Places.AlcoStore(),
            new Places.CozyStreet(),
            new Places.Scrapyard(),
            new Places.Bench()};
        public static bool CanGo(int placeid, int destinationid)
        {
            if (places[placeid].neighbors.Contains(destinationid)) return true;
            else return false;
        }
        public static string NameByID(int id)
        {
            return places[id].name;
        }
    }

    public class Place
    {
        public List<int> neighbors;
        public int id;
        public bool areWeHere;
        public string name;

        public virtual void SpecialF(MainCharacter chr) { }
    }

    public class MainStreet : Place
    {
        public MainStreet()
        {
            neighbors = new List<int>() { 1, 2, 3, 4, 5 };
            id = 0;
            name = "Aleje Spółdzielczości Pracy";
        }
        //szukaj puszki
        public override void SpecialF(MainCharacter chr)
        {
            Random rnd = new Random();
            int roll = rnd.Next(0, 15);
            switch (roll)
            {
                case < 2:
                    chr.numOfCans += 2;
                    System.Console.WriteLine(Prompts.MainSt.twoCans);
                    break;
                case < 10:
                    chr.numOfCans += 1;
                    System.Console.WriteLine(Prompts.MainSt.oneCan);
                    break;
                case < 15:
                    System.Console.WriteLine(Prompts.MainSt.noCan);
                    break;
            }
        }
    }

    public class DiagonalAlly : Place
    {
        public DiagonalAlly()
        {
            neighbors = new List<int>() { 0 };
            id = 1;
            name = "Mroczny zaułek";
        }

        //walcz śmieciu
        public override void SpecialF(MainCharacter chr)
        {
        }

    }

    public class AlcoStore : Place
    {
        public List<Items.Item> stuff;
        public AlcoStore()
        {
            neighbors = new List<int>() { 0 };
            id = 2;
            name = "Sklep Monopolowy 'Kapsel'";
            stuff = new List<Items.Item>() { };
        }
        //odpal sklep
        public override void SpecialF(MainCharacter chr)
        {
            System.Console.WriteLine(Prompts.Shop.ShopMain);
            for (int i = 0; i < stuff.Count(); i++)
            {
                System.Console.WriteLine($"\n{i + 1}. {stuff[i].ToString}");
            }
            int choice = Int32.Parse(System.Console.ReadLine());
            if (stuff[choice - 1].price <= chr.mamoona)
            {
                chr.items.Add(stuff[choice - 1]);
                chr.mamoona -= stuff[choice - 1].price;
                stuff.Remove(stuff[choice - 1]);
                System.Console.WriteLine(Prompts.Shop.PurchaseSuccessful);
            }
        }
    }

    public class CozyStreet : Place
    {
        public CozyStreet()
        {
            neighbors = new List<int>() { 0, 5 };
            id = 3;
            name = "Ulica Akacjowa";
        }

        //zebraj
        public override void SpecialF(MainCharacter chr)
        {
            Random rnd = new Random();
            int roll = rnd.Next(0, 25);
            switch (roll)
            {
                case < 10:
                    chr.mamoona += 2;
                    System.Console.WriteLine(Prompts.Gather.Shot2zl);
                    break;
                case < 13:
                    chr.mamoona += 5;
                    System.Console.WriteLine(Prompts.Gather.BigShot5zl);
                    break;
                case < 21:
                    System.Console.WriteLine(Prompts.Gather.Bida);
                    break;
                case < 25:
                    chr.mamoona -= 2;
                    System.Console.WriteLine(Prompts.Gather.Mandat);
                    chr.Go(5);
                    break;
            }
        }
    }

    public class Scrapyard : Place
    {
        public Scrapyard()
        {
            neighbors = new List<int>() { 0 };
            id = 4;
            name = "Skup złomu 'Pawełek'";
        }

        //sprzedaj zlom
        public override void SpecialF(MainCharacter chr)
        {
            chr.mamoona += chr.numOfCans * 4;
            System.Console.WriteLine(Prompts.Scrap.CansSold + chr.numOfCans.ToString());
            chr.numOfCans = 0;
        }
    }

    public class Bench : Place
    {
        public Bench()
        {
            neighbors = new List<int>() { 0, 3 };
            id = 5;
            name = "Ławeczka";
        }

        //spanie
        public override void SpecialF(MainCharacter chr)
        {

        }
    }
}
