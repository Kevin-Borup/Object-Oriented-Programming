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
        private string cpr;
        private string address;
        private string phone;
        private string email;
        private string prefDoctor;
        private List<JournalEntry> entries;
        public Journal(string[] patientInfo)
        {
            Name = patientInfo[0];
            Cpr = patientInfo[1];
            Address = patientInfo[2];
            Phone = patientInfo[3];
            Email = patientInfo[4];
            PrefDoctor = patientInfo[5];

        }
        public void AddJournalEntry(string doctor, string description)
        {
            entries.Add(new JournalEntry(doctor, description));
        }
        public void CreateJournalEntry(string date, string doctor, string description)
        {
            entries.Add(new JournalEntry(doctor, description));
        }
        public string Name { get { return name; } private set { name = value; } }
        public string Cpr { get { return cpr; } private set { cpr = value; } }
        public string Address { get { return address; } private set { address = value; } }
        public string Phone { get { return phone; } private set { phone = value; } }
        public string Email { get { return email; } private set { email = value; } }
        public string PrefDoctor { get { return prefDoctor; } private set { prefDoctor = value; } }
        public List<JournalEntry> Entries { get { return entries; } private set { entries = value; } }

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
        public JournalEntry(string date, string doctor, string description)
        {
            timeFormat = Convert.ToDateTime(date);
            this.doctor = doctor;
            this.description = description;
        }
        public DateTime TimeFormat { get { return timeFormat; } set { timeFormat = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
