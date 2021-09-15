using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Operation
    {
        private static int shelves = 1;
        private static int slotsPerShelf = 5;
        private static int productsPerSlot = 10;
        private Ressource content = new Ressource(shelves, slotsPerShelf, productsPerSlot);
        public void MainSetup()
        {
            for (int i = 0; i < content.Shelves.Length; i++)
            {
                for (int j = 0; j < content.Shelves[i].Slots.Length; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            content.Shelves[i].RegisterProduct(j, "Cola", 29.99f, productsPerSlot);
                        }
                        else if (j == 1)
                        {
                            content.Shelves[i].RegisterProduct(j, "Sprite", 29.99f, productsPerSlot);
                        }
                        else if (j == 2)
                        {
                            content.Shelves[i].RegisterProduct(j, "Water", 19.99f, productsPerSlot);
                        }
                        else if (j == 3)
                        {
                            content.Shelves[i].RegisterProduct(j, "Protein Bar", 15.99f, productsPerSlot);
                        }
                        else if (j == 4)
                        {
                            content.Shelves[i].RegisterProduct(j, "KitKat", 19.99f, productsPerSlot);
                        }
                    }
                }
            }
        }
        public string[] ProductNames()
        {
            List<string> productNames = new List<string>();
            for (int i = 0; i < content.Shelves.Length; i++)
            {
                for (int j = 0; j < content.Shelves[i].Slots.Length; j++)
                {
                    productNames.Add(content.Shelves[i].Slots[j].ProductName);
                }
            }
            return productNames.ToArray();
        }
        public float AddMoney(float money)
        {
            return 0f;
        }
        public float GetMachineMoney()
        {
            return 0f;
        }
        public string ProductPurchase(float money, int keypad)
        {
            return string.Empty;
        }
        public void ProcesWait()
        {

        }
        public float EmptyMoney()
        {
            return 0f;
        }
        public void RefillVM()
        {

        }
        public void ChangeSlotProduct()
        {

        }
        public void ChangePrice()
        {

        }
    }
}
