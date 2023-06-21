using Items;
using Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    public class Character
    {
        public int hp;
        public int atk;
        public int def;
        public string name;
        public List<Items.Item> items;

        public Character(int zycie, int atak, int obrona, string imie, List<Items.Item> itemki)
        {
            hp = zycie; atk = atak; def = obrona; name = imie; items = itemki;
        }
        public Character() { }
    }

    public class MainCharacter : Character
    {
        public MainCharacter(string nam)
        {
            name = nam;
            atk = 3;
            def = 1;
            numOfCans = 0;
            hp = 10;
            maxhp = 10;
            currItems = new List<Items.Item>();
            items = new List<Items.Item>();
            agility = 0;
            mamoona = 0;
            placeID = 0;
        }
        public int lvl;
        public int numOfCans;
        public int agility;
        public List<Items.Item> currItems;
        public int mamoona;
        public int placeID;
        public int maxhp;

        public bool Fight(Character chr2)
        {
            if (hp < maxhp) 
            {
                
            }
            while (this.hp > 0 && chr2.hp > 0)
            {
                if(chr2.def >= this.atk) {
                    Console.WriteLine(Prompts.Fight.Defeat);
                    return false; }
                chr2.hp = chr2.hp - (this.atk - chr2.def);
                Console.WriteLine(name + " uderza " + chr2.name + " za " + (atk - chr2.def).ToString());

                Random rnd = new Random();
                int roll = rnd.Next(0, 20);
                if (roll > this.agility)
                {
                    this.hp = this.hp - (chr2.atk - this.def);
                    Console.WriteLine(chr2.name + " uderza " + name + " za " + (chr2.atk-def).ToString());
                }
            }
            if (this.hp > 0) {
                this.currItems = chr2.items;
                Console.WriteLine(Prompts.Fight.Victory);
                Console.WriteLine("Zdobyte przedmioty (wyposażono automatycznie):");
                foreach (Item it in currItems) {
                    Console.WriteLine(it.name);
                }
                Equip();

                return true; } else
            {
                Console.WriteLine(Prompts.Fight.Defeat);
                return false;

            }

        }

        public bool Go(int PlaceId)
        {
            if (Places.PlacesGraph.CanGo(this.placeID, PlaceId))
            {
                this.placeID = PlaceId;
                System.Console.WriteLine(Prompts.Movement.Moved + Places.PlacesGraph.NameByID(PlaceId));
                PlacesGraph.places[placeID].WhatYuDo(this);
                return true;
            }
            else System.Console.WriteLine(Prompts.Movement.NotMoved);
            PlacesGraph.places[this.placeID].WhatYuDo(this);
            return false;
        }

        public void Equip()
        {
            foreach(Item it in currItems)
            {
                this.def += it.def;
                this.atk += it.atk;
                this.maxhp += it.hp;
                this.agility += it.agl;
                items.Add(it);
            }
            hp = maxhp;
            currItems.Clear();
        }
    }
}
