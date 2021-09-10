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
        public void Process()
        {
            string[] journalDetails;
            string[] entries;


        }

        private void JournalVisual()
        {
            string journal = 
                "Name               CPR\n" +
                "Address            PrefDoctor\n" +
                "Phone / Email      Age: year & days\n";
            string seperation = 
                "-------------------------------------------------\n";
            string entry = 
                "DateTime - Doctor\n" +
                "   Description";

            Console.WriteLine(journal + seperation + entry);
        }
    }
}
