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
        private Shelf[] shelves;
        public Ressource(int installedShelves, int shelfSlots)
        {
            Shelves = new Shelf[installedShelves];
            for (int i = 0; i < Shelves.Length; i++)
            {
                shelves[0] = new Shelf(shelfSlots);
            }
        }

        public float Money { get { return money; } private set { this.money = value; } }
        public Shelf[] Shelves { get { return shelves; } private set { this.shelves = value; } }
    }
    class Shelf
    {
        private Slot[] slots;
        public Shelf(int shelfSlots)
        {
            Slots = new Slot[shelfSlots];
        }
        public Slot[] Slots { get { return slots; } private set { this.slots = value; } }
    }
    class Slot
    {
        private string product;
        private float price;
        private int amount;
        private int capacity = 10;

        public Slot(string product, float price, int amount)
        {
            Product = product;
            Price = price;
            Amount = amount;
            CheckCapacity();
        }

        public void ChangeProduct(string product, float price, int amount)
        {
            Product = product;
            Price = price;
            Amount = amount;
            CheckCapacity();
        }
        public void UpdatePrice(float price)
        {
            Price = price;
        }
        public void AddProducts(int amount)
        {
            Amount += amount;
            CheckCapacity();
        }
        private void CheckCapacity()
        {
            if (Amount > capacity)
            {
                Amount = capacity;
            }
        }

        public string Product { get { return product; } private set { this.product = value; } }
        public float Price { get { return price; } private set { this.price = value; } }
        public int Amount { get { return amount; } private set { this.amount = value; } }

    }
}
