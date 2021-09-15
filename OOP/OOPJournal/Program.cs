using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OOPJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console Window adjustments
            Console.SetBufferSize(140, 40);
            Console.SetWindowSize(140, 40);

            // Instantiating sys, of the class System. 
            // This will be the main class to run the application
            // This is done to clear away from Main, and create a clean overview.
            System sys = new System();
            sys.Process();
        }
    }
    class System
    {
        readonly Manager mg = new Manager();
        int lineClearNum = 10;
        /// <summary>
        /// This is the main Process of the System.
        /// This Method will call the main visuals for the application.
        /// This is to provide the user with the info needed to take the proper action.
        /// </summary>
        public void Process()
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
                        GetJournal();
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
        /// <summary>
        /// This method interacts with the user to create a new file which contains the Journal/patient info.
        /// It provides feedback the success of the operation.
        /// The method the loads he input as a Journal, and begins the process for visual feedback and further aditions.
        /// </summary>
        private void CreateJournal()
        {
            string[] userInfo = new string[6];
            string[] journalHeaders = new string[6];
            journalHeaders[0] = "Name: ";
            journalHeaders[1] = "CPR: ";
            journalHeaders[2] = "Address: ";
            journalHeaders[3] = "Phone: ";
            journalHeaders[4] = "Email: ";
            journalHeaders[5] = "Prefered Doctor: ";

            Console.Clear();
            CreationHeader();
            int journalHeaderStart = Console.CursorTop;
            for (int i = 0; i < journalHeaders.Length; i++)
            {
                PrintHeader(journalHeaders, userInfo);
                Console.SetCursorPosition(journalHeaders[i].Length, i + journalHeaderStart);
                userInfo[i] = Console.ReadLine();
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
            AddEntry(currentJournal);
            ShowEntry(mg.GetNextEntry(currentJournal));
            JournalControls(currentJournal);
        }
        /// <summary>
        /// This method is used to write the elemets of 2 arrays as 1.
        /// This provides the user with a rather seemless experience.
        /// </summary>
        /// <param name="journalHeaders"></param>
        /// <param name="userInfo"></param>
        private void PrintHeader(string[] journalHeaders, string[] userInfo)
        {
            Console.Clear();
            CreationHeader();
            for (int i = 0; i < journalHeaders.Length; i++)
            {
                Console.WriteLine(journalHeaders[i] + userInfo[i]);
            }
        }
        /// <summary>
        /// This method is used to search for a journal, by providing the means to input ones CPR.
        /// The method also has the CPR as a variable parameter. This means you can also provide a cpr, to the load the corresponding journal. 
        /// </summary>
        /// <param name="cpr"></param>
        private void GetJournal(string cpr = "")
        {
            while (true)
            {
                if (cpr.Equals(""))
                {
                    cpr = InputReader<string>("Write the CPR of the patient: ");
                }

                if (cpr.Length == 10)
                {
                    break;
                }
            }
            
            Journal currentJournal = mg.LoadJournalFromFile(cpr);
            ShowJournalInfo(currentJournal);
            ShowEntry(mg.GetNextEntry(currentJournal));
            JournalControls(currentJournal);
        }
        /// <summary>
        /// After initial setup, this method becomes the main operator of the application.
        /// Both create and load journal ends here. Creating a loop for constant options and interactions.
        /// It makes use of the key pressed to create the accurate reponse.
        /// </summary>
        /// <param name="currentJournal"></param>
        private void JournalControls(Journal currentJournal)
        {
            while (true)
            {
                ShowControls();
                Console.CursorVisible = false;
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:

                        ShowEntry(mg.GetPreviousEntry(currentJournal));
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        GetJournal();
                        break;
                    case ConsoleKey.DownArrow:
                        CreateJournal();
                        break;
                    case ConsoleKey.Spacebar:
                        AddEntry(currentJournal);
                        break;
                    case ConsoleKey.RightArrow:
                        ShowEntry(mg.GetNextEntry(currentJournal));
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        /// <summary>
        /// This method prints the headers and information of the journal provided.
        /// </summary>
        /// <param name="currentJournal"></param>
        private void ShowJournalInfo(Journal currentJournal)
        {
            Console.Clear();
            string[] age = mg.AgeShowcase(currentJournal.Cpr);
            JournalHeader();
            Console.WriteLine($"-------------------------------------------------------------------------------------\n" +
                              $"Journal of {currentJournal.Name}\n" +
                              $"-------------------------------------------------------------------------------------\n" +
                              $"Name: {currentJournal.Name}\n" +
                              $"CPR: {currentJournal.Cpr}\n" +
                              $"Address: {currentJournal.Address}\n" +
                              $"Phone: {currentJournal.Phone}\n" +
                              $"Email: {currentJournal.Email}\n" +
                              $"Prefered Doctor: {currentJournal.PrefDoctor}\n" +
                              $"Age: {age[0]} Years & {age[1]} Days\n" +
                              $"-------------------------------------------------------------------------------------\n");
            lineClearNum = Console.CursorTop;
        }
        /// <summary>
        /// Prints the details of the entry to the Console.
        /// If no entry is available, the method prints out this as feedback.
        /// </summary>
        /// <param name="entry"></param>
        private void ShowEntry(JournalEntry entry)
        {
            ClearLine(lineClearNum);
            if (entry != null)
            {
                // Used to seperate the date formatting from the OS culture settings.
                CultureInfo provider = CultureInfo.InvariantCulture;
                Console.WriteLine("Entry: \n" +
                                 $"{entry.CreationDate.ToString("| yyyy/MM/dd | HH:mm", provider)} | {entry.Doctor} |\n" +
                                 $"   {entry.Description}\n");
            }
            else
            {
                Console.WriteLine("Entry: \n" +
                                 $"No available entry.\n");
            }

        }

        /// <summary>
        /// With the use of a currentJournal, this method provides a user interface to provide info.
        /// The gathered data is used to create an entry in the current journal.
        /// </summary>
        /// <param name="currentJournal">The Journal used to add entry to.</param>
        private void AddEntry(Journal currentJournal)
        {
            ClearLine(lineClearNum);
            Console.WriteLine("Entry:");
            string header = $"{DateTime.Now.ToString("| yyyy/MM/dd | HH:mm")} | ";
            Console.Write(header + "Doctor Name: ");
            string doctorName = Console.ReadLine();
            ClearLine();
            Console.WriteLine($"{header} {doctorName} |");

            // This while loop allows the user to create a longer descriptions along with creating new lines.
            // The user stop the writing procress by typing "END" on one line.
            string description = string.Empty;
            Console.WriteLine("Type to write... Write 'END' when finished.");
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("END")) break; else description += line + "\n";
            }
            ClearLine(lineClearNum);
            mg.AddEntry(currentJournal, doctorName, description);
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
                    // It is by choice to cause a crash, if the user leaves the input empty.
                    // As Parse can't recieve null values. This is used to avoid handling bad input.
                    return int.Parse(input);
                default:
                    break;
            }
            return input;
        }
        /// <summary>
        /// This method clears the previously written line, whilst adjusting the cursor to be located at the previous line's start.
        /// This method can be called without any parameters, or called whilst providing a parameter value.
        /// This calls the second ClearLine() Method, as it allows a more costumized setting.
        /// </summary>
        private void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        /// <summary>
        /// This overload of ClearLine allows one to defined a line to start at, in the console.
        /// Effectively clearing all output/input from that point onwards. 
        /// </summary>
        /// <param name="start"></param>
        private void ClearLine(int start)
        {
            int lastLine = Console.CursorTop;
            Console.SetCursorPosition(0, start);
            for (int i = start; i <= lastLine; i++)
            {
                Console.Write(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, start);
        }
        #region Visuals for the Application
        /// <summary>
        /// ASCII Art to create a better visual experiance for the user .
        /// </summary>
        private void MainHeader()
        {
            // Font Name: Script
            Console.WriteLine(@"
 ,                _      _         ___  _                     
/|   |           | |    | |       / (_)| | o          o       
 |___|  _   __,  | |_|_ | |      |     | |     _  _       __  
 |   |\|/  /  |  |/  |  |/ \     |     |/  |  / |/ |  |  /    
 |   |/|__/\_/|_/|__/|_/|   |_/   \___/|__/|_/  |  |_/|_/\___/");
        }
        private void CreationHeader()
        {
            Console.WriteLine(@"
   ___                                    
  / (_)                   o               
 |      ,_    _   __, _|_     __   _  _   
 |     /  |  |/  /  |  |  |  /  \_/ |/ |  
  \___/   |_/|__/\_/|_/|_/|_/\__/   |  |_/");
        }
        private void JournalHeader()
        {
            Console.WriteLine(@"
                                       _  
  /\                                  | | 
 |  |  __          ,_    _  _    __,  | | 
 |  | /  \_|   |  /  |  / |/ |  /  |  |/  
  \_|/\__/  \_/|_/   |_/  |  |_/\_/|_/|__/
   /|                                     
   \|");
        }
        /// <summary>
        /// The visuals for the MainMenu of the application.
        /// </summary>
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
        /// <summary>
        /// The Method presents the user with all available interaction at the current state.
        /// </summary>
        private void ShowControls()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------\n" +
                                "| Previous Entry | Load Journal | New Journal | Add Entry | Next Entry |  Exit App  |\n" +
                                "|       ◄─       |       ▲      |       ▼     |  [SPACE]  |     ─►     │    [ESC]   │\n" +
                                "-------------------------------------------------------------------------------------");

        }
        #endregion
    }
}
