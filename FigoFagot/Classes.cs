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
        public static string oneCan = "Znaleziono 1 puszkę!";
        public static string twoCans = "Znaleziono 2 puszki!";
        public static string noCan = "Brak puszek :(";
    }
    public static class Movement
    {
        public static string Moved = "Przemieszczono się do lokacji ";
        public static string NotMoved = "Nie udało się przemieścić";
    }
    public static class Fight
    {
        public static string Fajt = "Walcz z wrogim żulem - ";
        public static string Victory = "Walka wygrana!";
        public static string Defeat = "Walka przegrana!";
    }
    public static class Shop
    {
        public static string OpenShop = "Wejdź do sklepu";
        public static string ShopMain = "Yyy... tego no, dzień dobry, ja chciałem kupić, eee...";
        public static string PurchaseSuccessful = "Dziekuję kierowniku, do widzenia - zakupiono ";
        public static string InsufficientMamooney = "Oj no księciuniu, a na krechę nie da radę? - nie masz tyle kasy";

    }
    public static class Scrap
    {
        public static string CansSold = "Sprzedano puszki w ilości ";
        public static string GetCans = "Szukaj puszek";
        public static string SellCans = "Sprzedaj puszki";
    }
    public static class Gather 
    {
        public static string Shot2zl = "Wyżebrałeś 2 zł";
        public static string BigShot5zl = "Wyżebrałeś 5 zł";
        public static string Mandat = "Złapała cię policja! Zapłaciłeś mandat 7 zł";
        public static string Bida = "Ludzie nie byli dziś zbyt łaskawi. Nie udało ci się nic wyżebrać.";
        public static string ProbujZebrac = "Zebraj drobne od ludzi";
    }
    public static class General
    {
        //tutaj wrzuc lore xd
        public static string Intro = "\t\t\t\tWitaj w miejskiej przygodzie braci Figo-Fagot!" +
            "\n\tTwoim zadaniem jest wcielić się w postać brata Figo,\n\t" +
            "który po nieudanej karierze muzycznej niestety się stoczył i dołączył do grona żuli." +
            "\n\tPomóż mu zdobyć wystarczającą ilość pieniędzy walcząc z innymi żulami" +
            "\n\taby mógł awansować do klasy średniej i dołączyć do swojego brata Fagot.\n";
        public static string GoSomewhere = "Udaj sie do lokacji ";
        public static string Epilogue = "Gra zakończona sukcesem!" +
            "\nPokonałeś najbogatszego żula w mieście i nic już nie stoi ci na przeszkodzie," +
            "\naby dołączyć do twojego brata Fagot.";
        public static string Instructions = "Przemieszczaj się po mapie i odkrywaj lokalizacje:\n" +
            "w Mrocznym Zaułku możesz prowadzić walki z żulami\n" +
            "na Ławeczce możesz zregenerować się po walce\n" +
            "w sklepie możesz zaopatrzyć się w rzeczy zwiększające twoje szanse w walce\n" +
            "na ul. Akacjowej możesz spróbować szczęścia w żebraniu\n" +
            "na złomowisku możesz sprzedać puszki zebrane na Alejach.\n";
    }

    public static class Bench
    {
        public static string Sleep = "Przespałeś się, sen to zdrowie!";
    }

}

namespace General {
    public static class Events
    {
        public static void Intro(MainCharacter chr) 
        {
            Enemies.Init();
            Console.WriteLine(Prompts.General.Intro);
            Console.WriteLine("Kliknij enter aby przejść do instrukcji");
            Console.ReadLine();
            Console.WriteLine(Prompts.General.Instructions);
            Console.WriteLine("Kliknij enter aby rozpocząć grę");
            Console.ReadLine();

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
            Character zulAlojzy = new Character(17, 4, 2, "Alojzy", Items.EqZuli.EqAlojzy);
            Character zulStanislaw = new Character(27, 6, 4, "Stanislaw", Items.EqZuli.EqStanislaw);
            Character zulBodzio = new Character(38, 9, 8, "Bodzio", Items.EqZuli.EqBodzio);
            Character zulFraniu = new Character(47, 12, 9, "Franiu", Items.EqZuli.EqFraniu);
            Character zulZbychu = new Character(53, 15, 9, "Zbychu", Items.EqZuli.EqZbychu);
            Character zulMietek = new Character(68, 19, 11, "Mietek - FINAŁOWY BOSS", Items.EqZuli.EqMietek);
            wrogie_zule.Push(zulMietek);
            wrogie_zule.Push(zulZbychu);
            wrogie_zule.Push(zulFraniu);
            wrogie_zule.Push(zulBodzio);
            wrogie_zule.Push(zulStanislaw);
            wrogie_zule.Push(zulAlojzy);
            wrogie_zule.Push(zulMarian);
        } 
    }
}


