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
        private Operation system = new Operation();
        private Ressource contents = new Ressource(shelves, slotsPerShelf);

        public void PoweredOn()
        {
            MenuHeader();
            ShowUserMenu();
        }
        public void GetInput()
        {

        }
        private void MenuHeader()
        {
            Console.WriteLine(@"
 _    __                     __    _                  
| |  / /  ___    ____   ____/ /   (_)   ____    ____ _
| | / /  / _ \  / __ \ / __  /   / /   / __ \  / __ `/
| |/ /  /  __/ / / / // /_/ /   / /   / / / / / /_/ / 
|___/   \___/ /_/ /_/ \__,_/   /_/   /_/ /_/  \__, /  
    __  ___                   __      _      /____/   
   /  |/  /  ____ _  _____   / /_    (_)   ____   ___ 
  / /|_/ /  / __ `/ / ___/  / __ \  / /   / __ \ / _ \
 / /  / /  / /_/ / / /__   / / / / / /   / / / //  __/
/_/  /_/   \__,_/  \___/  /_/ /_/ /_/   /_/ /_/ \___/ 
                                                      
");
        }
        public void ShowUserMenu()
        {
            Console.WriteLine($@"
{"\t"}-------------------------------
{"\t"}|    1    |    2    |    3    |
{"\t"}-------------------------------
{"\t"}|    4    |    5    |    6    |
{"\t"}-------------------------------
{"\t"}|    7    |    8    |    9    |
{"\t"}-------------------------------
{"\t"}│   ◄──   |    0    | [Enter] |
{"\t"}-------------------------------");
                
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
