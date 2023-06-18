using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prompts 
{
    public static class Movement
    {
        public static string Moved = "Przemieszczono się do lokacji ";
        public static string NotMoved = "Nie udało się przemieścić";
    }
    public static class Fight{ }
    public static class Shop{ }
    public static class Scrap
    {
        public static string CansSold = "Sprzedano puszki w ilości ";
    }
    public static class Gather 
    {
        public static string Shot2zl = "";
        public static string BigShot5zl = "";
        public static string Mandat = "";
        public static string Bida = "";
    }
}

namespace Items {
    public class Item { };
}

namespace Characters
{
    public class Character {
        public int hp;
        public int atk;
        public int def;
        public string name;
        public List<Items.Item> items;

        public Character(int zycie, int atak, int obrona, string imie, List<Items.Item> itemki) {
            hp = zycie; atk = atak; def = obrona; name = imie; items = itemki;
        }
        public Character() { }
    }

    public class MainCharacter : Character 
    {
        public MainCharacter()
        {
            lvl = 1;
            atk = 3;
            def = 1;
            numOfCans = 0;
            hp = 10;
            currItems = new List<Items.Item>();
            agility = 0;
            mamoona = 0;
            placeID = 6;
        }
        public int lvl;
        public int numOfCans;
        public int agility;
        List<Items.Item> currItems;
        public int mamoona;
        public int placeID;

        public bool Fight(Character chr2)
        {
            while (this.hp > 0 && chr2.hp>0) {
                chr2.hp = chr2.hp - (this.atk-chr2.def);
                Random rnd = new Random();
                int roll = rnd.Next(0, 20);
                if(roll > this.agility) { 
                    this.hp = this.hp - (chr2.atk-this.def);
                }
            }
            if (this.hp > 0) return true; else return false;
        }

        public bool Go(int PlaceId)
        {
            if (Places.PlacesGraph.CanGo(this.placeID, PlaceId))
            {
                this.placeID = PlaceId;
                System.Console.WriteLine(Prompts.Movement.Moved + Places.PlacesGraph.NameByID(PlaceId));
                return true;
            }
            else System.Console.WriteLine(Prompts.Movement.NotMoved);
            return false;
        }
    }
}

namespace Places
{
    public class PlacesGraph {
        public static List<Places.Place> places = new List<Places.Place>() { 
            new Places.MainStreet(),
            new Places.AlcoStore(),
            new Places.Scrapyard(),
            new Places.DiagonalAlly(),
            new Places.CozyStreet()};
        public static bool CanGo(int placeid, int destinationid) {
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
        public MainStreet() {
            neighbors = new List<int>() { 1, 2, 3, 4, 5 };
            id = 0;
            name = "Aleje Spółdzielczości Pracy";
        }
        //szukaj puszki
        public override void SpecialF(MainCharacter chr)
        {
        }
    }

    public class DiagonalAlly : Place 
    { 
        public DiagonalAlly() { 
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
        public AlcoStore() { 
            neighbors = new List<int>() { 0 };
            id = 2;
            name = "Sklep Monopolowy 'Kapsel'";
        }
        //odpal sklep
        public override void SpecialF(MainCharacter chr)
        {
        }
    }

    public class CozyStreet : Place
    {
        public CozyStreet() { 
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
                    chr.Go(4);
                    break;

            }
        }
    }

    public class Scrapyard : Place 
    { 
        public Scrapyard() { 
            neighbors = new List<int>() { 0 };
            id = 5;
            name = "Skup złomu 'Pawełek'";
        }

        //sprzedaj zlom
        public override void SpecialF(MainCharacter chr)
        {
            chr.mamoona += chr.numOfCans * 4;
            System.Console.WriteLine(Prompts.Scrap.CansSold+chr.numOfCans);
            chr.numOfCans = 0;
        }
    }
    
    public class Bench : Place 
    { 
        public Bench() { 
            neighbors = new List<int>() { 0 , 3 };
            id = 5;
            name = "Ławeczka";
        }

        //spanie
        public override void SpecialF(MainCharacter chr)
        {
        }
    }
}
