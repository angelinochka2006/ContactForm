using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactForm
{
    public class ContactManager
    {
        public List<Contactc> Contacts { get; private set; }
        public ContactManager()
        {
            Contacts = new List<Contactc>();
            LoadContacts();
        }
        public void AddContact(Contactc contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            Contacts.Add(contact);
            SaveContacts();
        }
        public void RemoveContact(Contactc contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            Contacts.Remove(contact);
            SaveContacts();
        }
        public List<Contactc> SearchContacts(string query)
        {
            return Contacts.Where(c => c.Name.Contains(query) ||
            c.PhoneNumber.Contains(query)).ToList();
        }
        private void SaveContacts()
        {
            File.WriteAllLines("contacts.txt", Contacts.Select(c => $"{c.Name}|{c.PhoneNumber}"));
        }
        private void LoadContacts()
        {
            if (File.Exists("contacts.txt"))
            {
                var lines = File.ReadAllLines("contacts.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        Contacts.Add(new Contactc(parts[0], parts[1]));
                    }
                }
            }
        }
    }
}
