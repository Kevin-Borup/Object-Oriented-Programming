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
        readonly Manager mg = new Manager();
        public void Process()
        {
            Console.SetBufferSize(143, 9000);
            Console.SetWindowSize(Console.BufferWidth, 41);
            
            MainChoice();   
        }
        private void MainHeader()
        {
            Console.WriteLine(@"
 ,                _      _         ___  _                     
/|   |           | |    | |       / (_)| | o          o       
 |___|  _   __,  | |_|_ | |      |     | |     _  _       __  
 |   |\|/  /  |  |/  |  |/ \     |     |/  |  / |/ |  |  /    
 |   |/|__/\_/|_/|__/|_/|   |_/   \___/|__/|_/  |  |_/|_/\___/");
        }
        private void MainMenu()
        {
            Console.Write("\n" +
                          "1. Create Patient Journal\n" +
                          "2. Load Patient Journal\n" +
                          "\n" +
                          "3. Exit\n" +
                          "\n" +
                          "Enter your choice: ");

        }
        private void MainChoice()
        {
            while (true)
            {
                MainHeader();
                MainMenu();
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
        private void CreateJournal()
        {
            Console.Clear();
            string[] userInfo = new string[6];
            string[] journalHeaders = new string[6];
            journalHeaders[0] = "Name: ";
            journalHeaders[1] = "CPR: ";
            journalHeaders[2] = "Address: ";
            journalHeaders[3] = "Phone: ";
            journalHeaders[4] = "Email: ";
            journalHeaders[5] = "Prefered Doctor: ";

            PrintHeader(journalHeaders, userInfo);
            for (int i = 0; i < journalHeaders.Length; i++)
            {
                Console.SetCursorPosition(journalHeaders[i].Length, i);
                userInfo[i] = Console.ReadLine();
                Console.Clear();
                PrintHeader(journalHeaders, userInfo);
            }

            if (mg.CreateJournalFile(userInfo))
            {
                Console.WriteLine("Success: The journal for this patient has been created.");
                Console.ReadKey();
                Console.Clear();
            } 
            else
            {
                Console.WriteLine("Cancelled: The journal for this patient already exists.");
                Console.ReadKey();
                Console.Clear();
                return;

            }
            Journal currentJournal = mg.LoadJournalFromFile(userInfo[1]);
            ShowJournalInfo(currentJournal);
            ShowEntry(mg.GetNextEntry(currentJournal));
            AddEntry(currentJournal);
        }
        private void PrintHeader(string[] journalHeaders, string[] userInfo)
        {
            for (int i = 0; i < journalHeaders.Length; i++)
            {
                Console.WriteLine(journalHeaders[i] + userInfo[i]);
            }
        }
        private void ShowJournal(string cpr = "")
        {
            if (cpr.Equals(""))
            {
                cpr = InputReader<string>("Write the CPR of the patient: ");
            }
            Journal currentJournal = mg.LoadJournalFromFile(cpr);
            ShowJournalInfo(currentJournal);
            JournalControls(currentJournal);
        }
        private void JournalControls(Journal currentJournal)
        {
            ShowEntry(mg.GetNextEntry(currentJournal));
            while (true)
            {
                ShowControls();
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        ShowEntry(PreviousEntry(currentJournal));
                        break;
                    case ConsoleKey.UpArrow:
                        ShowJournal();
                        break;
                    case ConsoleKey.DownArrow:
                        CreateJournal();
                        break;
                    case ConsoleKey.Spacebar:
                        AddEntry(currentJournal);
                        break;
                    case ConsoleKey.RightArrow:
                        ShowEntry(NextEntry(currentJournal));
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void ShowJournalInfo(Journal currentJournal)
        {
            string[] age = AgeShowcase(currentJournal.Cpr);
            Console.WriteLine($"\n" +
                              $"Journal of {currentJournal.Name}\n" +
                              $"-----------------------------------------------------------------------------\n" +
                              $"Name: {currentJournal.Name}\n" +
                              $"CPR: {currentJournal.Cpr}\n" +
                              $"Address: {currentJournal.Address}\n" +
                              $"Phone: {currentJournal.Phone}\n" +
                              $"Email: {currentJournal.Email}\n" +
                              $"Prefered Doctor: {currentJournal.PrefDoctor}\n" +
                              $"Age: {age[0]} Years & {age[1]} Days\n" +
                              $"-----------------------------------------------------------------------------\n");
        }
        private void ShowEntry(JournalEntry entry)
        {
            if (entry != null)
            {
                Console.WriteLine("Entry: \n" +
                                 $"{entry.TimeFormat.ToString("| yyyy/MM/dd | HH:mm")} | {entry.Doctor} |\n" +
                                 $"   {entry.Description}");
            }
            else
            {
                Console.WriteLine("Entry: \n" +
                                 $"No available entry.");
            }
            
        }
        private void ShowControls()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------\n" +
                                "| Previous Entry | Load Journal | New Journal | Add Entry | Next Entry |  Exit App  |\n" +
                                "|       ◄─       |       ▲      |       ▼     |  [SPACE]  |     ─►     │    [ESC]   │\n" +
                                "-------------------------------------------------------------------------------------");
            Console.CursorVisible = false;
        }
        private JournalEntry NextEntry(Journal currentJournal)
        {
            return mg.GetNextEntry(currentJournal);

        }
        private JournalEntry PreviousEntry(Journal currentJournal)
        {
            return mg.GetPreviousEntry(currentJournal);
        }
        private void AddEntry(Journal currentJournal)
        {
            /* 11 lines
             * \n
             * Entry:
             * | yyyy/MM/dd | HH:mm | doctorName |
             *    entryDescription
             */
            ClearLine(13); // Clear from Entry and all lines down.
            Console.WriteLine("Entry:");
            string header = $"{DateTime.Now.ToString("| yyyy/MM/dd | HH:mm")} | ";
            Console.Write(header + "Doctor Name: ");
            string doctorName = Console.ReadLine();
            ClearLine();
            Console.WriteLine($"{header} {doctorName} |");
            string description = string.Empty;

            Console.WriteLine("Type to write... Write 'END' when finished.");
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("END")) break; else description += line + "\n";
            }

            mg.AddEntry(currentJournal, doctorName, description);
            JournalControls(currentJournal);
        }

        private string[] AgeShowcase(string cpr)
        {
            return mg.AgeShowcase(cpr);
        }

        private void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        #region ClearLine "Overload" Methods
        private void ClearLine(int start)
        {
            int lastLine = Console.CursorTop;
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lastLine; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, start);
        }
        private void ClearLine(int start, int lineAmount)
        {
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lineAmount; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, start);
        }
        private void ClearLine(int start, int lineAmount, int setCursor)
        {
            Console.SetCursorPosition(0, start);
            for (int i = 1; i <= lineAmount; i++)
            {
                Console.WriteLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, setCursor);
        }
        #endregion

        private dynamic InputReader<T>(string output = "")
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
