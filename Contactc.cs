using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactForm
{
    public class Contactc
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Contactc(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
