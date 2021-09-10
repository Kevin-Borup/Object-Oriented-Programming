using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VendingMachine
    {
        private static int shelves = 3;
        private static int slotsPerShelf = 5;
        Operation system = new Operation();
        Ressource contents = new Ressource(shelves, slotsPerShelf);

        public void PoweredOn()
        {

        }
        public void GetInput()
        {

        }
        public void ShowUserMenu()
        {
            string mainMenu =
                "---------------------------------------------------" +
                "|                                                 |";
        }
        public void StopProces()
        {

        }
        public void GiveProduct()
        {

        }
        public void ShowAdminMenu()
        {

        }
        public void RefillSlots()
        {

        }
        public void GatherIncome()
        {

        }
        public void ChangePrice()
        {

        }
    }
}
