using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPJournal
{
    class Journal
    {
        private string name;
        private string address;
        private string phone;
        private string email;
        private uint cpr;
        private string prefDoctor;
        private List<JournalEntry> entries;
        public void AddJournalEntry(string doctor, string description)
        {
            entries.Add(new JournalEntry(doctor, description));
        }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public uint Cpr { get { return cpr; } set { cpr = value; } }
        public string PrefDoctor { get { return prefDoctor; } set { prefDoctor = value; } }

    }
    class JournalEntry
    {
        private DateTime timeFormat;
        private string doctor;
        private string description;
        public JournalEntry(string doctor, string description)
        {
            timeFormat = DateTime.Now;
            this.doctor = doctor;
            this.description = description;
        }
        public DateTime TimeFormat { get { return timeFormat; } set { timeFormat = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
