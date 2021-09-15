using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace OOPJournal
{
    class DAL
    {
        // This is the main folder containing the data of the system.
        // HealthClinic the folder to contain all created .txt's.
        private readonly string folderPath = "HealthClinic";
        private string fileFullPath;
        private FileStream patientFile;

        // Upon initialization of DAL, it creates the folder to be used for storage.
        // The method checks whether the folder exists before creating it.
        // This is a builtin feature, thereby dismissing the need for a manual check.
        public DAL()
        {
            Directory.CreateDirectory(folderPath);
        }
        /// <summary>
        /// This method is used to update the path to the .txt file interacted with.
        /// This is needed as the order of methods aren't guarenteed, thereby needing this update.
        /// It uses the cpr of the current patient to point to their .txt.
        /// Used either for initial creation, addition to the file, or gathering contents from said file.
        /// </summary>
        /// <param name="cpr"></param>
        private void UpdatePath(string cpr)
        {
            fileFullPath = $"{folderPath}\\{cpr}.txt";
        }
        /// <summary>
        /// This method creates a .txt file containing the journal info.
        /// It is the essential preparation to making use of and saving a journal.
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        /// <exception cref="IOException">This error is caused when a file with given name exists.</exception>
        public bool CreateJournalFile(string[] patientInfo)
        {
            UpdatePath(patientInfo[1]);
            try
            {
                // This line is encapsulated in a try-catch to handle the scenario of creating a new file, whilst said file already exists.
                // The main method is a bool, creating a return value based on this local success.
                // This exception handling is only meant to catch the IOException, this is to avoid disabling the detection of other exceptions.
                patientFile = new FileStream(fileFullPath, FileMode.CreateNew);
            }
            catch (IOException)
            {
                return false;
            }
            StreamWriter writer = new StreamWriter(patientFile);

            // All the strings from patientInfo is written to the file.
            for (int i = 0; i < patientInfo.Length; i++)
            {
                writer.WriteLine(patientInfo[i]);
            }
            // A rather unessarry seperator, mainly for visual feedback when looking at the .txt file.
            writer.WriteLine("--------------------------------------");
            // High necessity in closing the StreamWriter process and the underlying FileStream.
            // This is to allow changes to be saved and to reduce ressource usage.
            writer.Close();
            return true;
        }
        /// <summary>
        /// This method uses the cpr number to locate and open the .txt for the current patient.
        /// The method provides two arrays each containing different parts of the journal file.
        /// </summary>
        /// <param name="cpr"></param>
        /// <param name="journalArray">"journalArray" is the string array of the length 6, containing all journal info.</param>
        /// <param name="entryArray">"entryArray" is the string array of unknown length, containing all entry submissions.</param>
        public void LoadFromFile(string cpr, out string[] journalArray, out string[] entryArray)
        {
            UpdatePath(cpr);
            patientFile = new FileStream(fileFullPath, FileMode.Open);
            StreamReader reader = new StreamReader(patientFile);

            // It provides increased error-avoidance to use a limited array as the known .txt setup allows for specification of each data section.
            // Meanwhile, the entryArray is of unknown size as a journal can have 0 or many entries. So its creation and addition of data is handled as a list.
            journalArray = new string[6];
            List<string> entryList = new List<string>();

            // The journal info uses a predined amount of lines, and can therefore be sectioned into focus areas.
            // The journal is the first 6 lines, (index 0-5). This value of 6 is known, but Length is used incase of future changes.
            // Anything under the journal area is added to the entries one line after another.
            // This is with the exception of one line, the '-' seperator. In order to move past it, ReadLine has to be called to move forward in the document.
            for (int i = 0; !reader.EndOfStream; i++)
            {
                if (i < journalArray.Length)
                {
                    journalArray[i] = reader.ReadLine();

                }
                else if (i == journalArray.Length)
                {
                    reader.ReadLine();
                }
                else if (journalArray.Length < i)
                {
                    // Whilst gathering the data, all '|' are changed into '\n'.
                    // This is to reacquire the formatting created by the user.
                    // As \n normally created formatting within the .txt file itself.
                    entryList.Add(reader.ReadLine().Replace('|', '\n'));
                }
            }
            // The list is copied to a new array, allowing for more list security in the application.
            entryArray = entryList.ToArray();
            // High necessity in closing the StreamReader process and the underlying FileStream.
            // This is to allow changes to be saved and to reduce ressource usage.
            reader.Close();
        }
        /// <summary>
        /// This method adds the entry data to the active journal's .txt file.
        /// The file is found by referencing to the CPR#.
        /// </summary>
        /// <param name="cpr"></param>
        /// <param name="entry"></param>
        public void AddToFile(string cpr, JournalEntry entry)
        {
            UpdatePath(cpr);
            // We change the patientFile to point to the updated path and setting it to FileMode.Append.
            // This FileStream is designed to search for this specific file and opening it to add data.
            patientFile = new FileStream(fileFullPath, FileMode.Append);
            StreamWriter writer = new StreamWriter(patientFile);

            // The culture specification is needed when formatting DateTime to a string.
            // The Culture info default to the system culture, which is a conflict with the system as current method to split contents is with a '-'.
            // Which is the system culture default symbol of my PC. The provider allow the string to be created purely as specified, independent of system culture.
            CultureInfo provider = CultureInfo.InvariantCulture;
            string entryDate = entry.TimeFormat.ToString("yyyy/MM/dd HH:mm", provider);
            // Upon description creation, \n are added to simulate the [ENTER] value of the user.
            // It also allows for the option to save the description at close representation of creation.
            // The replace is needed to avoid formatting within the .txt file itself. As that would complicate reading from the file.
            string entryDescription = entry.Description.Replace('\n', '|');
            writer.WriteLine($"{entryDate} - {entry.Doctor} - {entryDescription}");

            // High necessity in closing the StreamWriter process and the underlying FileStream.
            // This is to allow changes to be saved and to reduce ressource usage.
            writer.Close();
        }
    }
}
