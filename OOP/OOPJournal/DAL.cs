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
        private readonly string folderPath = "HealthClinic";
        private string fileFullPath;
        private FileStream patientFile;

        public DAL()
        {
            Directory.CreateDirectory(folderPath);
        }

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
                return false;
            }
            StreamWriter writer = new StreamWriter(patientFile);

            for (int i = 0; i < patientInfo.Length; i++)
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
            StreamReader reader = new StreamReader(patientFile);

            string[] journalArray = new string[6];
            List<string> entryList = new List<string>();

            for (int i = 0; !reader.EndOfStream; i++)
            {
                if (i < journalArray.Length)
                {
                    journalArray[i] = reader.ReadLine();

                }
                else if (i == 6)
                {
                    reader.ReadLine();
                }
                else if (journalArray.Length < i)
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
            StreamWriter writer = new StreamWriter(patientFile);

            writer.WriteLine($"{entry.TimeFormat}: {entry.Doctor} - {entry.Description}");

            writer.Close();
        }
    }
}
