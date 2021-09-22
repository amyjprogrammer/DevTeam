using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeam : Developer
    {
        //the developers on the team, team name and team id

        public string TeamName { get; set; }
        public int TeamID { get; set; }
    }
}
