using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class Developer
    {
        public Developer() { }
        public Developer(string firstName, string lastName, int idNumber, bool pluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Pluralsight = pluralsight;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
        public int IdNumber { get; set; }
        public bool Pluralsight { get; set; }
    }
}
