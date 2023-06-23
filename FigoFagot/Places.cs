using Characters;
using General;
using Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Places
{
    public class PlacesGraph
    {
        public static List<Places.Place> places = new List<Places.Place>() {
            new Place.MainStreet(),
            new Place.DiagonalAlly(),
            new Place.AlcoStore(),
            new Place.CozyStreet(),
            new Place.Scrapyard(),
            new Place.Bench()};
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
        public string? name;

        public virtual void SpecialF(MainCharacter chr) { }
        public virtual void WhatYuDo(MainCharacter chr) { }

        
        public static int Secure(int min, int max) 
        {
            try
            {
                while (true)
                {
                    int ss = Int32.Parse(Console.ReadLine());
                    if (ss <= max && ss >= min)
                    {
                        return ss;
                    }
                    else
                    {
                        Console.WriteLine("zły znak!");
                        return Secure(min, max);
                    }
                }
            }
            catch
            {
                Console.WriteLine("zły znak!");
                return Secure(min, max);
            }
       
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
            WhatYuDo(chr);
        }

        public override void WhatYuDo(MainCharacter chr)
        {
            Console.WriteLine("1. " + Prompts.General.GoSomewhere+PlacesGraph.NameByID(1));
            Console.WriteLine("2. " + Prompts.General.GoSomewhere+PlacesGraph.NameByID(2));
            Console.WriteLine("3. " + Prompts.General.GoSomewhere +PlacesGraph.NameByID(3));
            Console.WriteLine("4. " + Prompts.General.GoSomewhere +PlacesGraph.NameByID(4));
            Console.WriteLine("5. " + Prompts.General.GoSomewhere +PlacesGraph.NameByID(5));
            Console.WriteLine("6. " + Prompts.Scrap.GetCans);
            Console.WriteLine("Twoj wybor:");
            
            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                if (choice > 0 && choice < 7) 
                {
                    switch (choice)
                    {
                        case 1:
                            chr.Go(1);
                            break;
                        case 2:
                            chr.Go(2);
                            break;
                        case 3:
                            chr.Go(3);
                            break;
                        case 4:
                            chr.Go(4);
                            break;
                        case 5:
                            chr.Go(5);
                            break;
                        case 6:
                            this.SpecialF(chr);
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("zła liczba!");
                    WhatYuDo(chr);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("zły znak!");
                WhatYuDo(chr);
            }

            
            Console.Clear();
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
            if (Enemies.wrogie_zule.Count > 0)
            {
                if (chr.Fight(Enemies.wrogie_zule.Peek())) Enemies.wrogie_zule.Pop();
                WhatYuDo(chr);
            }
            else General.Events.Outro();
        }

        public override void WhatYuDo(MainCharacter chr)
        {
            if (Enemies.wrogie_zule.Count()>0)
            {
                Console.WriteLine("1. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(0));
                Console.WriteLine("2. " + Prompts.Fight.Fajt + Enemies.wrogie_zule.Peek().name);
                Console.WriteLine("Twoj wybor:");
                int choice;
                    choice = Place.Secure(1, 2);
                switch (choice)
                {
                    case 1:
                        chr.Go(0);
                        break;
                    case 2:
                        this.SpecialF(chr);
                        break;
                }
                Console.Clear();
            }
            else General.Events.Outro();
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
            stuff = new List<Items.Item>() {
                AllItems.list[0],
                AllItems.list[1],
                AllItems.list[2],
                AllItems.list[3],
                AllItems.list[4],
                AllItems.list[5],
                AllItems.list[6],
                AllItems.list[7]
            };
        }
            //odpal sklep
      
        

         public override void SpecialF(MainCharacter chr) 
        { 
        
            System.Console.WriteLine(Prompts.Shop.ShopMain);
            Console.WriteLine("Zaskórniaki: \t"+chr.mamoona.ToString());
            Console.WriteLine("0. Opuść sklep");
            for (int i = 0; i < stuff.Count(); i++)
            {
                System.Console.WriteLine($"\n{i + 1}. {stuff[i].name}, \tcena: {stuff[i].price}");
            }
            int choice;  
                while (true)
                {
                    try
                    {
                        choice = Int32.Parse(System.Console.ReadLine());
                    if (choice < stuff.Count) ;
                            break;
                    }
                    catch { Console.WriteLine("zły znak!"); }
                }
            if (choice == 0) {
                Console.WriteLine("W sumie to nic nie chciałem, do widzenia... albo zapomniałem?");
            }
            else if (stuff[choice - 1].price <= chr.mamoona)
            {
                System.Console.WriteLine(Prompts.Shop.PurchaseSuccessful +stuff[choice-1].name);
                chr.currItems.Add(stuff[choice - 1]);
                chr.mamoona -= stuff[choice - 1].price;
                stuff.Remove(stuff[choice - 1]);
                Console.WriteLine("Zakupione przedmioty (wyposażono automatycznie):");
                foreach (Item it in chr.currItems)
                {
                    Console.WriteLine(it.name);
                }
                chr.Equip();
            }
            else { Console.WriteLine(Prompts.Shop.InsufficientMamooney); }
            WhatYuDo(chr);

        }
        public override void WhatYuDo(MainCharacter chr)
        {
            Console.WriteLine("1. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(0));
            Console.WriteLine("2. " + Prompts.Shop.OpenShop);
            Console.WriteLine("Twoj wybor:");
            int choice;
            choice = Place.Secure(1, 2);
                switch (choice)
            {
                case 1:
                    chr.Go(0);
                    break;
                case 2:
                    this.SpecialF(chr);
                    break;
            }
            Console.Clear();
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
                    chr.mamoona -= 7;
                    System.Console.WriteLine(Prompts.Gather.Mandat);
                    chr.Go(5);
                    break;
            }
            WhatYuDo(chr);
        }
        public override void WhatYuDo(MainCharacter chr)
        {
            Console.WriteLine("1. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(0));
            Console.WriteLine("2. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(5));
            Console.WriteLine("3. " + Prompts.Gather.ProbujZebrac);
            Console.WriteLine("Twoj wybor:");
            int choice;
            choice = Place.Secure(1, 3);
                switch (choice)
            {
                case 1:
                    chr.Go(0);
                    break;
                case 2:
                    chr.Go(5);
                    break;
                case 3:
                    this.SpecialF(chr);
                    break;
            }
            Console.Clear();
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
            chr.mamoona += chr.numOfCans;
            System.Console.WriteLine(Prompts.Scrap.CansSold + chr.numOfCans.ToString());
            chr.numOfCans = 0;
            WhatYuDo(chr);
        }

        public override void WhatYuDo(MainCharacter chr)
        {
            Console.WriteLine("1. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(0));
            Console.WriteLine("2. " + Prompts.Scrap.SellCans);
            Console.WriteLine("Twój wybór:");
            int choice;
            choice = Place.Secure(1, 2);
                switch (choice)
            {
                case 1:
                    chr.Go(0);
                    break;
                case 2:
                    this.SpecialF(chr);
                    break;
            }
            Console.Clear();
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
            chr.hp = chr.maxhp;
            Console.WriteLine(Prompts.Bench.Sleep);
            WhatYuDo(chr);
        }
        public override void WhatYuDo(MainCharacter chr)
        {
            Console.WriteLine("1. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(0));
            Console.WriteLine("2. " + Prompts.General.GoSomewhere + PlacesGraph.NameByID(3));
            Console.WriteLine("3. Prześpij sie (odnowienie HP)");
            Console.WriteLine("Twój wybór:");
            int choice;
            choice = Place.Secure(1, 3);
                switch (choice)
            {
                case 1:
                    chr.Go(0);
                    break;
                case 2:
                    chr.Go(3);
                    break;
                case 3:
                    this.SpecialF(chr);
                    break;
            }
            Console.Clear();
        }
    }
}}
