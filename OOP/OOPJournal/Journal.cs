using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
        private List<JournalEntry> entries = new List<JournalEntry>();
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
            Entries.Add(new JournalEntry(doctor, description));
        }
        public void RecreateJournalEntry(string date, string doctor, string description)
        {
            Entries.Add(new JournalEntry(date, doctor, description));
        }
        // All attributes/properties are publically available to get informations.
        // Althoug they're all private in regards to set, meaning only the journal itself can edit it with a builtin funtion.
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
        // Journal Entry generates it's own date upon construction, whilst assigning doctor and description.
        public JournalEntry(string doctor, string description)
        {
            TimeFormat = DateTime.Now;
            Doctor = doctor;
            Description = description;
        }
        // This construction allows on to personally define the date.
        // This is used for creating entries on the back of previosuly existing acount.
        public JournalEntry(string date, string doctor, string description)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            TimeFormat = DateTime.ParseExact(date, "yyyy/MM/dd HH:mm", provider);
            Doctor = doctor;
            Description = description;
        }

        public DateTime TimeFormat { get { return timeFormat; } set { timeFormat = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
