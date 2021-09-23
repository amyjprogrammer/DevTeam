using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public enum TeamName  {TeamOne, TeamTwo, TeamThree}
    public class DevTeam 
    {
        //the developers on the team, team name and team id

        public TeamName NameOfTeam { get; set; }
        public int TeamID { get; set; }
    }
}
