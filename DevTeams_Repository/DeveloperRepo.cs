using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepo
    {
        protected readonly List<Developer> _developerList = new List<Developer>();
        public void AddDeveloperToList(Developer developerInfo)
        {
            _developerList.Add(developerInfo);
        }
        public List<Developer> GetAllDeveloperInfo()
        {
            return _developerList;
        }
        public Developer GetDeveloperById(int developerId)
        {
            foreach (Developer devInfo in _developerList)
            {
                if(devInfo.IdNumber == developerId)
                {
                    return devInfo;
                }
            }
            return null;
        }
        public bool UpdateExistingDevContent(Developer existingDevContent, Developer newDevContent)
        {
            if(existingDevContent != null)
            {
                existingDevContent.FirstName = newDevContent.FirstName;
                existingDevContent.LastName = newDevContent.LastName;
                existingDevContent.IdNumber = newDevContent.IdNumber;
                existingDevContent.Pluralsight = newDevContent.Pluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDevContent(Developer existingDevContent)
        {
            bool result = _developerList.Remove(existingDevContent);
            return result;
        } 
    }
}
