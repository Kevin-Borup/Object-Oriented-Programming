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

        private void UpdatePath(string cpr)
        {
            fileFullPath = $"{folderPath}\\{cpr}.txt";
        }
        public bool CreateJournalFile(string[] patientInfo)
        {
            UpdatePath(patientInfo[1]);
            try
            {
                patientFile = new FileStream(fileFullPath, FileMode.CreateNew);
                
            }
            catch (IOException)
            {
                Console.WriteLine("The Patient journal file already exists.");
                patientFile.Close();
                return false;
            }
            writer = new StreamWriter(patientFile);

            for (int i = 0; i < patientFile.Length; i++)
            {
                writer.WriteLine(patientInfo[i]);
            }
            writer.WriteLine("--------------------------------------");
            writer.Close();
            return true;
        }
        public string[] LoadFromFile(string cpr, out string[] entryArray)
        {
            UpdatePath(cpr);
            patientFile = new FileStream(fileFullPath, FileMode.Open);
            reader = new StreamReader(patientFile);

            string[] journalArray = new string[5];
            List<string> entryList = new List<string>();

            for (int i = 0; !reader.EndOfStream; i++)
            {
                if (i < 6)
                {
                    journalArray[i] = reader.ReadLine();

                }
                else if (6 > i)
                {
                    entryList.Add(reader.ReadLine());
                }
            }
            reader.Close();
            entryArray = entryList.ToArray();
            return journalArray;
        }
        public void AddToFile(string cpr, JournalEntry entry)
        {
            UpdatePath(cpr);
            patientFile = new FileStream(fileFullPath, FileMode.Append);
            writer = new StreamWriter(patientFile);

            writer.WriteLine($"{entry.TimeFormat}: {entry.Doctor} - {entry.Description}");

            writer.Close();
        }
    }
}
