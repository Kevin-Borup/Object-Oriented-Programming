using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Manager
    {
        public void CreateJournal(string name, string address, string phone, string email, uint cpr, string prefDoctor, string description)
        {

        }
        public void CreateEntry(uint cpr, string doctor, string description)
        {

        }
        public Journal CreateFromFile(uint cpr)
        {
            return new Journal();
        }
        public Journal LoadJournal(uint cpr, out string age)
        {
            age = string.Empty;
            return new Journal();
        }
        public void JournalNavigator(sbyte key)
        {

        }
    }

    class JournalConnector
    {
        int[,] cprAge;
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
                        if (j < 37) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                    else if (i < 9)
                    {
                        if (j < 58) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                    else
                    {
                        if (j < 37) cprAge[i, j] = 20; else cprAge[i, j] = 19;
                    }
                }
            }
            #endregion

        }
        public string AgeCalculator(uint cpr)
        {
            
            string cprString = cpr.ToString();
            // 1912991234
            uint year = Convert.ToUInt32(cprString.Substring(6, 1));
            // 99
            uint cpr1 = Convert.ToUInt32(cprString.Substring(6, 1));
            // 1
            string birthCenYear = cprAge[cpr1, year].ToString() + year.ToString();
            // 19 + 99 = 1999
            string birthDate = cprString.Substring(0, 4);
            // 1912
            birthDate += birthCenYear;
            // 19121999

            return string.Empty;
        }
        public string FileToString(uint cpr)
        {
            return string.Empty;
        }
        public void JournalCreation(string name, string address, string phone, string email, uint cpr, string prefDoctor, string description)
        {

        }
        public void JournalNavigator(sbyte key)
        {

        }
    }
}
