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
        public DevTeam(string teamName, int teamId, List<Developer> addTeamMembers)
        {
            TeamName = teamName;
            TeamId = teamId;
            AddTeamMembers = addTeamMembers;
        }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public List<Developer> AddTeamMembers{ get; set; }
    }
}
