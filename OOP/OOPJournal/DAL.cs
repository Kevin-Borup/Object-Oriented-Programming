using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPJournal
{
    class DAL
    {
        private string folderPath = @".\HealthClinic";
        private string fileFullPath;
        FileStream patientFile;
        StreamReader reader;
        StreamWriter writer;

        private void UpdatePath(uint cpr)
        {
            fileFullPath = folderPath + @"\" + cpr.ToString() + ".txt";
        }
        public void CreateFullPath(uint cpr)
        {
            UpdatePath(cpr);
            try
            {
                patientFile = new FileStream(fileFullPath, FileMode.CreateNew);
            }
            catch (IOException)
            {
                Console.WriteLine("The Patient txt file already exists.");
            }
        }
        public string[] LoadFromFile(out string[] entryArray) 
        {
            patientFile = new FileStream(fileFullPath, FileMode.Open);
            reader = new StreamReader(patientFile);

            string[] journalArray = new string[5];
            List<string> entryList = new List<string>();

            for (int i = 0; reader.EndOfStream; i++)
            {
                if (i < 6)
                {
                    journalArray[i] = reader.ReadLine();

                }
                else if (8 > i)
                {
                    entryList.Add(reader.ReadLine());
                }
            }

            reader.Close();
            entryArray = entryList.ToArray();
            return journalArray;
        }
        public void AddToFile(uint cpr, JournalEntry entry)
        {
            UpdatePath(cpr);
            patientFile = new FileStream(fileFullPath, FileMode.Append);
            writer = new StreamWriter(patientFile);

            writer.WriteLine($"{entry.TimeFormat}: {entry.Doctor} - {entry.Description}");

            writer.Close();
        }
    }
}
