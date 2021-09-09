using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Ressource
    {
        private float money;
        private Item[,] inventory = new Item[5, 3];

        public float Money { get { return money; } private set { this.money = value; } }
        public Item[,] Inventory { get { return inventory; } private set { this.inventory = value; } }
    }

    class Item
    {
        private string name;
        private float price;
        private int amount;

        public Item(string name, float price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
        public string Name { get { return name; } private set { this.name = value; } }
        public float Price { get { return price; } private set { this.price = value; } }
        public int Amount { get { return amount; } private set { this.amount = value; } }

    }
}
