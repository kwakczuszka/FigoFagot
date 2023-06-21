using Characters;
using Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prompts 
{
    public static class MainSt
    {
        public static string oneCan = "Znaleziono 1 puszke!";
        public static string twoCans = "Znaleziono 2 puszki!";
        public static string noCan = "Nima puszek :(";
    }
    public static class Movement
    {
        public static string Moved = "Przemieszczono się do lokacji ";
        public static string NotMoved = "Nie udało się przemieścić";
    }
    public static class Fight
    {
        public static string Fajt = "Walcz z wrogim zulem - ";
        public static string Victory = "Walka wygrana!";
        public static string Defeat = "Walka Przegrana!";
    }
    public static class Shop
    {
        public static string OpenShop = "Wejdz do sklepu";
        public static string ShopMain = "Yyy... tego no, dzien dobry, ja chcialem kupic, eee...";
        public static string PurchaseSuccessful = "Dziekuje kierowniku, do widzenia - zakupiono ";
        public static string InsufficientMamooney = "Oj no ksieciuniu, a na kreche nie da rade? - nie masz tyle kasy";

    }
    public static class Scrap
    {
        public static string CansSold = "Sprzedano puszki w ilości ";
        public static string GetCans = "Szukaj puszek";
        public static string SellCans = "Sprzedaj puszki";
    }
    public static class Gather 
    {
        public static string Shot2zl = "";
        public static string BigShot5zl = "";
        public static string Mandat = "";
        public static string Bida = "";
        public static string ProbujZebrac = "Zebraj drobne od ludzi";
    }
    public static class General
    {
        //tutaj wrzuc lore xd
        public static string Intro = "";
        public static string GoSomewhere = "Udaj sie do lokacji ";
    }

    public static class Bench
    {
        public static string Sleep = "Przespales sie, sen to zdrowie!";
    }

}

namespace General {
    public static class Events
    {
        public static void Intro(MainCharacter chr) 
        {
            Enemies.Init();
            Console.WriteLine(Prompts.General.Intro);
            PlacesGraph.places[0].WhatYuDo(chr);
        }

        public static void WhatUDo() { }
    }

    public static class Enemies
    {
        public static Stack<Character> wrogie_zule = new Stack<Character>();
        public static void Init() { 
            Character zulMarian = new Character(10, 2, 1, "Marian", Items.EqZuli.EqMarian);
            Character zulStanislaw = new Character(20, 7, 5, "Stanislaw", Items.EqZuli.EqStanislaw);
            Character zulMietek = new Character(30, 12, 6, "Stanislaw", Items.EqZuli.EqMietek);
            wrogie_zule.Push(zulMietek);
            wrogie_zule.Push(zulStanislaw);
            wrogie_zule.Push(zulMarian);
        } 
    }
}


namespace Items {
    public class Item
    {
        public string name;
        public int price;
        public int hp;
        public int atk;
        public int def;
        public int agl;
        public int id;
        public Item(string name, int price, int hp, int atk, int def, int agl, int id)
        {
            this.name = name;
            this.price = price;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.agl = agl;
            this.id = id;
        }
    };

    public static class AllItems
    {
        public static List<Item> list = new List<Item>()
        {
            new Item("Butelka 'Taternik'", 1, 0, 2, 0, 0, 0),
            new Item("Bulka standard", 2, 3, 0, 0, 0, 1),
            new Item("Bulka deluxe", 5, 10, 0, 0, 1, 2),
            new Item("Butelka 'Tychy'", 4, 0, 5, 0, 0, 3),
            new Item("Czapka z daszkiem", 10, 2, 0, 3, 0, 4),
            new Item("Kurtka 'FBI'", 15, 6, 0, 4, 4, 5),
            new Item("Butelka 'Wyborna'", 10, 0, 8, 0, 1, 6), 
            new Item("UNIKAT - Butelka 'Jacek Danielowicz'", 0, 0, 0, 0, 0, -1) 
        };
    }
    
    public static class EqZuli
    {
        public static List<Item> EqMarian = new List<Item>() {AllItems.list[0]};
        public static List<Item> EqStanislaw = new List<Item>() {
            AllItems.list[1],
            AllItems.list[4]
        };
        public static List<Item> EqMietek = new List<Item>() { 
            AllItems.list[7],
            AllItems.list[6],
            AllItems.list[5]
        };
    }
}
