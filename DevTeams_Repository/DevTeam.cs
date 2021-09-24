using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeam 
    {
        public DevTeam() { }
        public DevTeam(string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
    }
}
