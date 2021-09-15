using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class VendingMachine
    {
        private Operation sys = new Operation();

        public void PoweredOn()
        {
            sys.MainSetup();

            MenuHeader();
            ShowShelves();
            ShowCurrentMoney(0);
            ShowUserMenu();
            MainUserMenu();
        }
        public void MainUserMenu()
        {
            while (true)
            {
                switch (InputReader<int>())
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        ShowAdminMenu();
                        AdminMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                Console.Clear();
                MenuHeader();
                ShowShelves();
                ShowCurrentMoney(0);
                ShowUserMenu();
            }
        }
        public void AdminMenu()
        {
            bool adminActive = true;
            while (adminActive)
            {
                switch (InputReader<int>())
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        adminActive = false;
                        break;
                }
            }
        }

        public void ShowCurrentMoney(float userCash)
        {
            Console.WriteLine($"Current Cash: {userCash}");
        }

        public void ShowMachineMoney(float machineCash)
        {
            Console.WriteLine($"Aqcuired Cash: {machineCash}");
        }

        public void ShowItemListWPrice()
        {
            Console.Write("");
        }

        public void StopProces()
        {

        }
        public void GiveProduct()
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
        /// <summary>
        /// This method is of a dynamic type. The return value is the value defined by "TDataType".
        /// This method provides the ability to create an output for the console, whilst getting input from the user.
        /// </summary>
        /// <typeparam name="TDatatype">The datatype provided here, defines the return value</typeparam>
        /// <param name="output">An optional variable, used for output to the Console.</param>
        /// <returns>Returns user input as the datatype provided.</returns>
        private dynamic InputReader<TDatatype>(string output = "")
        {
            Console.Write(output);
            string input = Console.ReadLine();

            // This switch case is quite overkill at current time, but allows for further development down the line.
            // Mainly when we learn how to make use of Libraries.
            switch (typeof(TDatatype).Name)
            {
                case "Int32":
                    // Breaks the switch if the input is null.
                    if (input != "")
                    {
                        return int.Parse(input);

                    }
                    break;
            }


            return input;
        }
        #region Visuals for the Application
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
/_/  /_/   \__,_/  \___/  /_/ /_/ /_/   /_/ /_/ \___/");
        }
        public void ShowShelves()
        {
            Console.WriteLine(@"
-------------------------------------------------------------
|           |           |           |           |           |
|   Cola    |  Sprite   |   Water   |Protein Bar|  KitKat   |
|           |           |           |           |           |
-------------------------------------------------------------
|  29.99 kr |  29.99 kr |  19.99 kr |  15.99 kr |  19.99 kr |
|    11     |    12     |    13     |    14     |    15     |
-------------------------------------------------------------");
        }
        public void ShowUserMenu()
        {
            Console.Write("\n" +
                          "1. Add money\n" +
                          "2. Input Product Code\n" +
                          "3. Recall your money\n" +
                          "4. Admin Menu\n" +
                          "\n" +
                          "5. Leave\n" +
                          "Write your choice: ");
        }
        public void ShowAdminMenu()
        {
            Console.Clear();
            MenuHeader();
            ShowMachineMoney(sys.GetMachineMoney());
            Console.Write("Admin Header" +
                "\n" +
                          "1. Change price of product(s)\n" +
                          "2. Refill products\n" +
                          "3. Gather money\n" +
                          "\n" +
                          "4. Exit menu\n" +
                          "Write your choice: ");
        }
        #endregion
    }
}
