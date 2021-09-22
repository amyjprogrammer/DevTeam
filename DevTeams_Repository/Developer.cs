using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class Developer
    {
        //need name, id numbers, bool Pluralsight

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                string fullName = FirstName + LastName;
                return fullName;
            }
        }

        public int IDNumber { get; set; }
        public bool Pluralsight { get; set; }
    }
}
