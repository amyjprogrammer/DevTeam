using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _contentDevTeam = new List<DevTeam>();
        public void AddDevTeamContentToDirectory(DevTeam devTeamInfo)
        {
            _contentDevTeam.Add(devTeamInfo);
        }
        public List<DevTeam> GetAllDevTeams()
        {
            return _contentDevTeam;
        }
        public DevTeam GetOnlyOneDevTeam(int specificDevTeamNum)
        {
            foreach (DevTeam devTeamContent in _contentDevTeam)
            {
                if(devTeamContent.TeamId == specificDevTeamNum)
                {
                    return devTeamContent;
                }
            }
            return null;
        }
        public bool UpdatingDevTeamInfo(DevTeam existingDevTeamInfo, DevTeam newDevTeamInfo)
        {
            if(existingDevTeamInfo != null && newDevTeamInfo != null)
            {
                existingDevTeamInfo.TeamId = newDevTeamInfo.TeamId;
                existingDevTeamInfo.TeamName = newDevTeamInfo.TeamName;
                existingDevTeamInfo.AddTeamMembers = newDevTeamInfo.AddTeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDevTeam(DevTeam existingDevTeamInfo)
        {
            bool result = _contentDevTeam.Remove(existingDevTeamInfo);
            return result;
        }
        public void AddDevToTeam(int originalTeamId, Developer devInfo)
        {
            DevTeam devTeamInfo = GetOnlyOneDevTeam(originalTeamId);
            devTeamInfo.AddTeamMembers.Add(devInfo);

        }
    }
}
