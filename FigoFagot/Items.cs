using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
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
            new Item("Butelka 'Taternik'", 48, 0, 2, 0, 0, 0),
            new Item("Bulka standard", 15, 3, 0, 0, 0, 1),
            new Item("Bulka deluxe", 32, 10, 1, 1, 1, 2),
            new Item("Butelka 'Tychy'", 58, 0, 5, 0, 0, 3),
            new Item("Butelka 'Wyborna'", 102, 0, 7, 0, 1, 4),
            new Item("Puszka 'Harnold'", 65, 2, 4, 0, 1, 5),
            new Item("Papierosy 'Wielbłądy'", 130, 0, 2, 0, 4, 6),
            new Item("Gazeta 'Porządny obywatel'", 25, 4, 0, 0, 2, 7),
            new Item("Kurtka 'FBI'", 0, 6, 0, 2, 2, 8),
            new Item("Różowy parasol", 0, 0, 2, 3, 1, 9),
            new Item("Wygnieciony śpiwór'", 0, 10, 0, 2, 0, 10),
            new Item("Zardzewiały scyzoryk", 0, 0, 5, 0, 0, 11),
            new Item("Uszkodzona deska do prasowania", 0, 0, 8, 12, 0, 12),
            new Item("Gumowy kapeć", 0, 0, 3, 1, 1, 13),
            new Item("Plik banknotów", 0, 0, 0, 0, 0,-2),
            new Item("UNIKAT - Butelka 'Jacek Danielowicz'", 0, -1, 0, -1, -1, -1)
        };
    }

    public static class EqZuli
    {
        public static List<Item> EqMarian = new List<Item>() 
        {
            AllItems.list[8],
        };
        public static List<Item> EqStanislaw = new List<Item>()
        {
            AllItems.list[9],
        };
        public static List<Item> EqBodzio = new List<Item>() 
        { 
            AllItems.list[10] 
        };
        public static List<Item> EqFraniu = new List<Item>()
        {
            AllItems.list[11]
        };
        public static List<Item> EqZbychu = new List<Item>()
        {
            AllItems.list[12]
        };
        public static List<Item> EqAlojzy = new List<Item>()
        {
            AllItems.list[13]
        };
        public static List<Item> EqMietek = new List<Item>()
        {
            AllItems.list[14],
            AllItems.list[15]
        };
    }
}

