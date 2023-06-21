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
            new Item("Butelka 'Taternik'", 1, 0, 2, 0, 0, 0),
            new Item("Bulka standard", 2, 3, 0, 0, 0, 1),
            new Item("Bulka deluxe", 5, 10, 1, 1, 1, 2),
            new Item("Butelka 'Tychy'", 4, 0, 5, 0, 0, 3),
            new Item("Czapka z daszkiem", 10, 2, 0, 3, 0, 4),
            new Item("Kurtka 'FBI'", 15, 6, 0, 4, 4, 5),
            new Item("Butelka 'Wyborna'", 10, 0, 8, 0, 1, 6),
            new Item("UNIKAT - Butelka 'Jacek Danielowicz'", 0, -1, 0, -1, -1, -1)
        };
    }

    public static class EqZuli
    {
        public static List<Item> EqMarian = new List<Item>() { AllItems.list[0] };
        public static List<Item> EqStanislaw = new List<Item>()
        {
            AllItems.list[1],
            AllItems.list[4]
        };
        public static List<Item> EqMietek = new List<Item>()
        {
            AllItems.list[7],
            AllItems.list[6],
            AllItems.list[5]
        };
    }
}

