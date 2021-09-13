using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Manager
    {
        DAL database = new DAL();
        JournalConnector journalConnector = new JournalConnector();
        public void CreateJournalFile(string name, string cpr, string address, string phone, string email, string prefDoctor)
        {
            string[] patientInfo = journalConnector.CreateJournalString(name, cpr, address, phone, email, prefDoctor);

            database.CreateJournalFile(patientInfo);
        }
        public void AddEntry(Journal currentJournal, string doctor, string description)
        {
            currentJournal.AddJournalEntry(doctor, description);
            database.AddToFile(currentJournal.Cpr, currentJournal.Entries[currentJournal.Entries.Count - 1]);
        }

        public Journal LoadJournalFromFile(string cpr)
        {
            string[] journalInfo;
            string[] entryArray;

            journalInfo = database.LoadFromFile(cpr, out entryArray);

            return journalConnector.JournalCreation(journalInfo);
        }
        public JournalEntry GetEntry(Journal currentJournal, ref int index)
        {

            return JournalEntry;
        }
        public string AgeShowcase()
        {
            return string.Empty;
        }
        public void JournalNavigator(sbyte key)
        {

        }
    }

    class JournalConnector
    {
        int[,] cprAge;
        Journal currentJournal;
        public JournalConnector()
        {

            #region cprAge Array Setup (version 1)
            /*
            uint[,] cprAge = new uint[4, 99];
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
            uint[,] cprAge = new uint[4, 100];
            for (int i = 0; i < cprAge.Length; i++)
            {
                for (int j = 0; j < cprAge.GetLength(i); j++)
                {
                    if (i == 0)
                    {
                        cprAge[i, j] = 19;
                    }
                    else if (i == 1)
                    {
                        if (j < 37) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                    else if (i == 2)
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
        public string BirthDateCalculator(string cpr)
        {
            // 1912991234
            uint year = Convert.ToUInt32(cpr.Substring(4, 2));
            // 99
            uint cpr1 = Convert.ToUInt32(cpr.Substring(6, 1));
            // 1
            string birthCenYear = cprAge[cpr1, year].ToString() + year.ToString();
            // 19 + 99 = 1999
            string birthDate = cpr.Substring(0, 4);
            // 1912
            birthDate += birthCenYear;
            // 19121999

            return birthDate;
        }
        public string AgeCalculator(string cpr)
        {
            string birthDate = BirthDateCalculator(cpr);

            return string.Empty;
        }
        public string FileToString(uint cpr)
        {
            return string.Empty;
        }
        public string[] CreateJournalString(string name, string cpr, string address, string phone, string email, string prefDoctor)
        {
            string[] patientInfo = new string[6];

            patientInfo[0] = name;
            patientInfo[1] = cpr;
            patientInfo[2] = address;
            patientInfo[3] = phone;
            patientInfo[4] = email;
            patientInfo[5] = prefDoctor;

            return patientInfo;
        }
        public Journal JournalCreation(string[] patientInfo)
        {
            return new Journal(patientInfo);
        }
        public Journal GetJournal(string[] journalInfo, string[] entryArray)
        {
            currentJournal = new Journal(journalInfo);

            for (int i = 0; i < entryArray.Length; i++)
            {
                string[] entry = EntrySplitter(entryArray[i]);

                currentJournal.AddJournalEntry(entry);
            }

            return new Journal(patientInfo);
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
        public void GetEntry()
        {

        }

        public void JournalNavigator(sbyte key)
        {

        }
    }
}
