using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Manager
    {
        //The manager is used a way to point towards logic on a deeper level to highten security. 
        private readonly DAL database = new DAL();
        private readonly JournalConnector journalConnector = new JournalConnector();
        public bool CreateJournalFile(string[] patientInfo)
        {
            return database.CreateJournalFile(patientInfo);
        }
        public Journal LoadJournalFromFile(string cpr)
        {
            database.LoadFromFile(cpr, out string[] journalInfo, out string[] entryArray);

            return journalConnector.GetJournal(journalInfo, entryArray);
        }
        public void AddEntry(Journal currentJournal, string doctor, string description)
        {
            currentJournal.AddJournalEntry(doctor, description);
            database.AddToFile(currentJournal.Cpr, currentJournal.Entries[currentJournal.Entries.Count - 1]);
        }
        public JournalEntry GetNextEntry(Journal currentJournal)
        {
            return journalConnector.GetNextEntry(currentJournal);
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
        /// <summary>
        /// The JournalConnector immediately fills an array with values to provide a multidimensional array to translate age based on CPR.
        /// </summary>
        public JournalConnector()
        {
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
        }
        /// <summary>
        /// With use of some string manipulation, the method extracts and inserts value to create the desired birthday string.
        /// </summary>
        /// <param name="cpr"></param>
        /// <returns></returns>
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
        /// <summary>
        /// This method creates a string array containing the value of years and days in a persons age.
        /// </summary>
        /// <param name="cpr"></param>
        /// <returns></returns>
        public string[] AgeCalculator(string cpr)
        {
            string[] age = new string[2];
            // Gets a string of a birthdate including century from the CPR.
            string birthDate = BirthDateCalculator(cpr);
            DateTime birth = DateTime.ParseExact(birthDate, "ddMMyyyy", null);
            DateTime today = DateTime.Now;
            DateTime thisBDay = new DateTime(today.Year, birth.Month, birth.Day);
            // The logic begind this process is to create 3 DateTimes to compare between.
            // The third DateTime ThisBDay is created as a way to gather the day difference from today to the cpr birthday.
            // Otherwise the DateTime Method Compare would always see today as being later, as ones birth obviosuly happened before the current day.
            // DateTime doesn't allow one to remove the data concerning Years, Months, Days, Hours, Minutes, or Seconds. They're always attached.
            // So from a comparison perspective, making the year the same value, is an indirect way of making it irrelevant to the focus on days.


            // Default: Birthday has already happened.
            int years = today.Year - birth.Year;
            int days = today.DayOfYear - thisBDay.DayOfYear;
            // The .Date provides the date exclusive of Time. Making it possible to compare on days, but not also hours of life.
            // Technically it still carries data concerning Time. It is merely all set to midnight 00:00:00, thereby making it obsolete in comparison.
            int difference = DateTime.Compare(today.Date, thisBDay.Date);
            // If birthday hasn't happened yet, don't count this year, and reverse amount of days so to get days from instead of until.
            if (difference < 0)
            {
                years -= 1;
                days = 365 + days;
            }

            age[0] = years.ToString();
            age[1] = days.ToString();

            return age;
        }
        public Journal JournalCreation(string[] patientInfo)
        {
            return new Journal(patientInfo);
        }
        /// <summary>
        /// The method creates a journal from a file, as it is provided with 2 arrays. 
        /// One with journal info and one with entry submissions.
        /// </summary>
        /// <param name="journalInfo"></param>
        /// <param name="entryArray"></param>
        /// <returns></returns>
        public Journal GetJournal(string[] journalInfo, string[] entryArray)
        {
            // The method starts by creating the Journal.
            currentJournal = new Journal(journalInfo);

            // Then with a for-loop it iterates over every found entry to process it for entry creation.
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
        /// <summary>
        /// This method splits a string into an array based on the char '-'.
        /// It then cleans the values by trimming the whitespace found on eitherside of the value.
        /// This is the main preparation of data read from a file.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private string[] EntrySplitter(string entry)
        {
            // dato - doc - desc
            string[] entrySplit = entry.Split('-');
            // Array with whitespace = [dato_][_doc_][_desc]
            for (int i = 0; i < entrySplit.Length; i++)
            {
                entrySplit[i] = entrySplit[i].Trim();
            }
            return entrySplit;
        }
        /// <summary>
        /// With the use of a index managed by the JournalConnector it can iterate to the next entry on the currentJournal.
        /// This allows the user to browse through entries one at a time in a journal.
        /// </summary>
        /// <param name="currentJournal"></param>
        /// <returns></returns>
        public JournalEntry GetNextEntry(Journal currentJournal)
        {
            JournalEntry currentEntry = null;

            if (currentJournal.Entries != null)
            {
                List<JournalEntry> entries = currentJournal.Entries;
                if (entryIndex < entries.Count /*&& entries != null*/)
                {
                    currentEntry = entries[entryIndex];
                    entryIndex++;
                }
            }

            return currentEntry;
        }
        /// <summary>
        /// With the use of a index managed by the JournalConnector it can iterate to the previous entry on the currentJournal.
        /// This allows the user to browse through entries one at a time in a journal.
        /// </summary>
        /// <param name="currentJournal"></param>
        /// <returns></returns>
        public JournalEntry GetPreviousEntry(Journal currentJournal)
        {
            List<JournalEntry> entries = currentJournal.Entries;
            JournalEntry currentEntry = null;

            if (0 <= entryIndex - 1)
            {
                entryIndex -= 1;
                currentEntry = entries[entryIndex];
            }

            return currentEntry;
        }
    }
}
