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
        private int slotCapacity;
        public Ressource(int installedShelves, int shelfSlots, int slotCapacity)
        {
            SlotCapacity = slotCapacity;
            Shelves = new Shelf[installedShelves];
            for (int i = 0; i < Shelves.Length; i++)
            {
                Shelves[i] = new Shelf(shelfSlots, slotCapacity);
            }
        }

        public float Money { get { return money; } private set { this.money = value; } }
        public Shelf[] Shelves { get { return shelves; } private set { this.shelves = value; } }
        public int SlotCapacity { get { return slotCapacity; } private set { this.slotCapacity = value; } }
    }
    class Shelf
    {
        private Slot[] slots;
        private int slotCapacity;
        public Shelf(int shelfSlots, int slotCapacity)
        {
            SlotCapacity = slotCapacity;
            Slots = new Slot[shelfSlots];
        }
        public void RegisterProduct(int slotIndex, string productName, float price, int amount)
        {
            Slots[slotIndex] = new Slot(productName, price, amount, SlotCapacity);
        }
        public Slot[] Slots { get { return slots; } private set { this.slots = value; } }
        public int SlotCapacity { get { return slotCapacity; } private set { this.slotCapacity = value; } }
    }
    class Slot
    {
        // ProductName max length = 11;
        private string productName;
        private float price;
        private int amount;
        private int capacity;

        public Slot(string productName, float price, int amount, int capacity)
        {
            ProductName = productName;
            Price = price;
            Amount = amount;
            Capacity = capacity;
        }

        public void UpdatePrice(float price)
        {
            Price = price;
        }
        public void AddProducts(int amount)
        {
            Amount += amount;
        }

        public string ProductName { get { return productName; } private set { this.productName = value; } }
        public float Price { get { return price; } private set { this.price = value; } }
        public int Amount { get { return amount; } private set { this.amount = value; } }
        public int Capacity { get { return capacity; } private set { this.capacity = value; } }

    }
}
