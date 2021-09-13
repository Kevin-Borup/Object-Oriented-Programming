using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Manager
    {
        private readonly DAL database = new DAL();
        private readonly JournalConnector journalConnector = new JournalConnector();
        public bool CreateJournalFile(string[] patientInfo)
        {
            return database.CreateJournalFile(patientInfo);
        }
        public void AddEntry(Journal currentJournal, string doctor, string description)
        {
            currentJournal.AddJournalEntry(doctor, description);
            database.AddToFile(currentJournal.Cpr, currentJournal.Entries[currentJournal.Entries.Count - 1]);
        }

        public Journal LoadJournalFromFile(string cpr)
        {
            string[] journalInfo = database.LoadFromFile(cpr, out string[] entryArray);

            return journalConnector.GetJournal(journalInfo, entryArray);
        }
        public JournalEntry GetNextEntry(Journal currentJournal)
        {
            return journalConnector.GetEntry(currentJournal);
        }
        public JournalEntry GetPreviousEntry(Journal currentJournal)
        {
            return journalConnector.GetPreviousEntry(currentJournal);
        }
        public string[] AgeShowcase(string cpr)
        {
            return journalConnector.AgeCalculator(cpr);
        }
    }

    class JournalConnector
    {
        private readonly int[,] cprAge;
        private int entryIndex = 0;
        private Journal currentJournal;
        public JournalConnector()
        {

            #region cprAge Array Setup (version 1)
            /*
            int[,] cprAge = new int[10, 99];
            for (int i = 0; i < cprAge.Length; i++)
            {
                for (int j = 0; j < cprAge.GetLength(i); j++)
                {
                    if (i < 4)
                    {
                        cprAge[i, j] = 19;
                    }
                    else if (i < 5)
                    {
                        if (j < 37)
                        {
                            cprAge[i, j] = 20;
                        }
                        else
                        {
                            cprAge[i, j] = 19;
                        }
                    }
                    else if (i < 9)
                    {
                        if (j < 58)
                        {
                            cprAge[i, j] = 20;
                        }
                        else
                        {
                            cprAge[i, j] = 19;
                        }
                    }
                    else
                    {
                        if (j < 37)
                        {
                            cprAge[i, j] = 20;
                        }
                        else
                        {
                            cprAge[i, j] = 19;
                        }
                    }
                }
            }
            */
            #endregion

            #region cprAge Array Setup (version 2)
            cprAge = new int[10, 100];
            for (int i = 0; i < cprAge.GetLength(0); i++)
            {
                for (int j = 0; j < cprAge.GetLength(1); j++)
                {
                    if (i < 4)
                    {
                        cprAge[i, j] = 19;
                    }
                    else if (i < 5)
                    {
                        if (j < 37) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                    else if (i < 9)
                    {
                        if (j < 58) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                    else
                    {
                        if (i == 3) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                }
            }
            #endregion

        }
        private string BirthDateCalculator(string cpr)
        {
            // 1912991234
            int year = Convert.ToInt32(cpr.Substring(4, 2));
            // 99
            int cpr1 = Convert.ToInt32(cpr.Substring(6, 1));
            // 1
            string birthCenYear = cprAge[cpr1, year].ToString() + year.ToString();
            // 19 + 99 = 1999
            string birthDate = cpr.Substring(0, 4);
            // 1912
            birthDate += birthCenYear;
            // 19121999

            return birthDate;
        }
        public string[] AgeCalculator(string cpr)
        {
            string[] age = new string[2];
            string birthDate = BirthDateCalculator(cpr);
            DateTime today = DateTime.Now;
            DateTime birthDateTime = DateTime.ParseExact(birthDate, "ddMMyyyy", null);

            int daysInBetween = -(today.DayOfYear - birthDateTime.DayOfYear);

            string years = (today.Year - 1 - birthDateTime.Year).ToString();
            string days = (365 - daysInBetween).ToString();

            age[0] = years;
            age[1] = days;

            return age;
        }
        public Journal JournalCreation(string[] patientInfo)
        {
            return new Journal(patientInfo);
        }
        public Journal GetJournal(string[] journalInfo, string[] entryArray)
        {
            currentJournal = new Journal(journalInfo);

            if (entryArray.Length > 0)
            {
                for (int i = 0; i < entryArray.Length; i++)
                {
                    string[] entry = EntrySplitter(entryArray[i]);

                    currentJournal.RecreateJournalEntry(entry[0], entry[1], entry[2]);
                }
            }

            return currentJournal;
        }
        private string[] EntrySplitter(string entry)
        {
            // dato - doc - desc
            string[] entrySplit = entry.Split('-');
            // Array with whitespace = [dato_][_doc_][_desc]
            for (int i = 0; i < entrySplit.Length; i++)
            {
                entrySplit[i].Trim();
            }
            return entrySplit;
        }
        public JournalEntry GetEntry(Journal currentJournal)
        {
            JournalEntry currentEntry = null;

            if (currentJournal.Entries != null)
            {
                List<JournalEntry> entries = currentJournal.Entries;
                if (entryIndex < entries.Count && entries != null)
                {
                    currentEntry = entries[entryIndex];
                    entryIndex++;
                }
            }

            return currentEntry;
        }
        public JournalEntry GetPreviousEntry(Journal currentJournal)
        {
            List<JournalEntry> entries = currentJournal.Entries;
            JournalEntry currentEntry = null;

            int previousEntry = entryIndex - 1;

            if (0 <= previousEntry)
            {
                currentEntry = entries[previousEntry];
                entryIndex = previousEntry;
            }

            return currentEntry;
        }
    }
}
