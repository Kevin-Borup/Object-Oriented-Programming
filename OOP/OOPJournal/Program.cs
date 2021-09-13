using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            System sys = new System();
            sys.Process();
        }

        
    }
    class System
    {
        Manager mg = new Manager();
        public void Process()
        {
            string[] journalDetails;
            string[] entries;

            MainHeader();
            MainMenu();
            MainChoice();
            
        }
        public void MainHeader()
        {
            Console.WriteLine(@"
                    ,                _      _         ___  _                     
                   /|   |           | |    | |       / (_)| | o          o       
                    |___|  _   __,  | |_|_ | |      |     | |     _  _       __  
                    |   |\|/  /  |  |/  |  |/ \     |     |/  |  / |/ |  |  /    
                    |   |/|__/\_/|_/|__/|_/|   |_/   \___/|__/|_/  |  |_/|_/\___/");
        }
        public void MainMenu()
        {
            Console.Write("\n" +
                          "1. Create Patient Journal\n" +
                          "2. Load Patient Journal\n" +
                          "\n" +
                          "3. Exit\n" +
                          "\n" +
                          "Enter your choice: ");

        }
        public void MainChoice()
        {
            while (true)
            {
                switch (InputReader<int>())
                {
                    case 1:
                        CreateJournal();
                        break;
                    case 2:
                        ShowJournal();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        MainHeader();
                        MainMenu();
                        break;
                }
            }
        }
        public void CreateJournal()
        {
            string journal =
                "Name: \n" +
                "CPR: \n" +
                "Address: \n" +
                "Phone: \n" +
                "Email: \n" +
                "PrefDoctor: \n";
            Console.Clear();
            Console.WriteLine(journal);

        }
        public void ShowJournal()
        {
            string cpr = InputReader<string>("Write the CPR of the patient: ");
            Journal currentJournal = mg.LoadJournalFromFile(cpr);
            ShowJournalInfo(currentJournal);
            int index = 0;
            ShowEntry(mg.GetEntry(currentJournal, ref index));
            ShowControls();
            JournalControls();
        }
        private void JournalControls()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        PreviousEntry();
                        break;
                    case ConsoleKey.UpArrow:
                        ShowJournal();
                        break;
                    case ConsoleKey.DownArrow:
                        CreateJournal();
                        break;
                    case ConsoleKey.Spacebar:
                        AddEntry();
                        break;
                    case ConsoleKey.RightArrow:
                        NextEntry();
                        break;
                }
            }
        }
        private void ShowJournalInfo(Journal currentJournal)
        {
            Console.WriteLine($"\n" +
                              $"Journal of {currentJournal.Name}\n" +
                              $"-----------------------------------------------------------------------------\n" +
                              $"{currentJournal.Name}\n" +
                              $"{currentJournal.Cpr}\n" +
                              $"{currentJournal.Address}\n" +
                              $"{currentJournal.Phone}\n" +
                              $"{currentJournal.Email}\n" +
                              $"{currentJournal.PrefDoctor}\n" +
                              $"{mg.AgeShowcase()}\n" +
                              $"-----------------------------------------------------------------------------\n");
        }
        private void ShowEntry(JournalEntry entry)
        {
            if (entry != null)
            {
                Console.WriteLine("\n" +
                                 $"Entry: " +
                                 $"{entry.TimeFormat.ToString("| yyyy/MM/dd | HH:mm")} | {entry.Doctor} |\n" +
                                 $"   {entry.Description}\n");
            }
            else
            {
                Console.WriteLine("\n" +
                                 $"Entry: " +
                                 $"No available entries.\n");
            }
            
        }
        private void ShowControls()
        {
            Console.WriteLine("\n------------------------------------------------------------------------\n" +
                                "| Previous Entry | Load Journal | New Journal | Add Entry | Next Entry |\n" +
                                "|       ◄─       |       ▲      |       ▼     |  [SPACE]  |     ─►     │\n" +
                                "------------------------------------------------------------------------");
            Console.CursorVisible = false;
        }
        private void NextEntry()
        {

        }
        public void PreviousEntry()
        {

        }
        public void AddEntry()
        {
            /* 11 lines
             * \n
             * Entry:
             * | yyyy/MM/dd | HH:mm | doctorName |
             *    entryDescription
             */
            ClearLine(13); // Clear from Entry and all lines down.
            mg.AddEntry();
            ShowControls();
            JournalControls();
        }

        public void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        #region ClearLine "Overload" Methods
        public void ClearLine(int start)
        {
            int lastLine = Console.CursorTop;
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lastLine; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, start);
        }
        public void ClearLine(int start, int lineAmount)
        {
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lineAmount; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, start);
        }
        public void ClearLine(int start, int lineAmount, int setCursor)
        {
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lineAmount; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, setCursor);
        }
        #endregion

        public dynamic InputReader<T>(string output = "")
        {
            Console.Write(output);
            string input = Console.ReadLine();

            if (typeof(T) == typeof(int))
            {
                return int.Parse(input);
            }
            return input;
        }
    }
}
