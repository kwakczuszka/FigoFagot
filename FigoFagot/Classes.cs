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
        public static string Intro = "\t\t\tWitaj w miejskiej przygodzie braci Figo-Fagot!" +
            "\n\tTwoim zadaniem jest wcielić się w postać brata Figo,\n\t" +
            "który po nieudanej karierze muzycznej niestety się stoczył i dołączył do grona żuli." +
            "\n\tPomóż mu zdobyć wystarczającą ilość pieniędzy walcząc z innymi żulami" +
            "\n\taby mógł awansować do klasy średniej i dołączyć do swojego brata Fagot.";
        public static string GoSomewhere = "Udaj sie do lokacji ";
        public static string Epilogue = "Gra zakończona sukcesem!" +
            "\nPokonałeś najbogatszego żula w mieście i nic już nie stoi ci na przeszkodzie," +
            "\naby dołączyć do twojego brata Fagot.";
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

        public static void Outro()
        {
            Console.WriteLine(Prompts.General.Epilogue);
            Console.Read();
        }
        public static void WhatUDo() { }
    }

    public static class Enemies
    {
        public static Stack<Character> wrogie_zule = new Stack<Character>();
        public static void Init() { 
            Character zulMarian = new Character(10, 2, 1, "Marian", Items.EqZuli.EqMarian);
            Character zulStanislaw = new Character(20, 7, 5, "Stanislaw", Items.EqZuli.EqStanislaw);
            Character zulMietek = new Character(30, 12, 6, "Mietek - FINALOWY BOSS", Items.EqZuli.EqMietek);
            wrogie_zule.Push(zulMietek);
            wrogie_zule.Push(zulStanislaw);
            wrogie_zule.Push(zulMarian);
        } 
    }
}


