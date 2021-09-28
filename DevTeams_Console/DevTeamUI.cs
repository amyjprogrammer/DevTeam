using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    class DevTeamUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            RunMenu(true);
        }
        //check that the ID is unique or are we assigning the ID?
        private void RunMenu(bool isRunning)
        {
            while (isRunning)
            {
                Console.Clear();

                //The main menu with options to go to Dev or DevTeam
                Console.WriteLine
                    (
                        "Welcome to the Komodo Insurance Team Management Application\n" +
                        "****************************************************************\n\n" +
                        "1. Show Developer Options\n" +
                        "2. Show Developer Team Options\n" +
                        "3. Exit"
                    );
                Console.Write("\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DevTeamMenu();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number between 1-3.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DeveloperMenu()
        {
            bool isDevRunning = true;
            while (isDevRunning)
            {
                Console.Clear();

                //Developer Menu
                Console.WriteLine
                    (
                        "Developer Menu\n" +
                        "*********************************************\n\n" +
                        "1. Show all Developers\n" +
                        "2. Add new Developer\n" +
                        "3. Edit Developer Information\n" +
                        "4. Remove Developer\n" +
                        "5. Developers that need a Pluralsight license\n" +
                        "6. Main Menu\n"
                    );
                Console.Write("Enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDevelopers();
                        break;
                    case "2":
                        CreateNewDeveloper();
                        break;
                    case "3":
                        UpdateEmployeeById();
                        break;
                    case "4":
                        RemoveEmployeeById();
                        break;
                    case "5":
                        DevelopersWithPluralsight();
                        break;
                    case "6":
                        isDevRunning = false;
                        RunMenu(false);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number between 1-6.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DevTeamMenu()
        {
            bool isDevTeamRunning = true;
            while (isDevTeamRunning)
            {
                Console.Clear();

                //DevTeam Menu
                Console.WriteLine
                    (
                        "Developer Team Menu\n" +
                        "**************************************\n\n" +
                        "1. Show all Developer Teams with Developers\n" +
                        "2. Add new Developer Team and Assign Multiple Developers\n" +
                        "3. Update Developer on Team\n" +
                        "4. Edit Developer Team\n" +
                        "5. Delete Developer Team\n" +
                        "6. Main Menu\n"
                    );
                Console.Write("\nEnter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDevelopersWithTeams();
                        break;
                    case "2":
                        AddDevTeams();
                        break;
                    case "3":
                        UpdateDeveloperOnTeams();
                        break;
                    case "4":
                        UpdateDevTeamById();
                        break;
                    case "5":
                        RemoveDevTeamById();
                        break;
                    case "6":
                        isDevTeamRunning = false;
                        RunMenu(false);
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number between 1-5.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void CreateNewDeveloper()
        {
            bool addNewDev = true;
            while (addNewDev)
            {
                Console.Clear();

                //newing up the Developer
                Developer createDev = new Developer();
                Console.WriteLine("Information for the New Developer\n" +
                    "********************************************\n\n");
                Console.Write("Please enter the first name: ");
                createDev.FirstName = Console.ReadLine();
                Console.Write("\nPlease enter the last name: ");
                createDev.LastName = Console.ReadLine();
                Console.Write("\nPlease enter the unique ID number: ");

                //Making sure user entered a number
                MakeSureUserEnteredANum(createDev);

                Console.WriteLine("\nDoes this employee have Pluralsight access?");
                Console.Write("Answer True or False: ");
                string userAnswer = Console.ReadLine().ToLower();
                createDev.Pluralsight = CheckUserAnswerForTrueOrFalse(userAnswer);
                _developerRepo.AddDeveloperToList(createDev);
                Console.Clear();
                Console.WriteLine("This Developer was just added.\n");
                DisplayDeveloperInfo(createDev);
                Console.Write("\nWould you like to add another Developer? [Y or N]: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    addNewDev = false;
                }
                else
                {
                    addNewDev = false;
                }
            }
            PauseProgram();
        }
        private void ShowAllDevelopers()
        {
            Console.Clear();
            DisplayAllDeveloperInfo();
            PauseProgram();
        }
        private void ShowAllDevelopersWithTeams()
        {
            Console.Clear();
            DisplayAllDevTeamWithDevs();
        }
        private void UpdateEmployeeById()
        {
            bool updateEmployee = true;
            while (updateEmployee)
            {
                Console.Clear();
                DisplayAllDeveloperInfo();
                Console.Write("\n\nPlease enter the Id number for the Employee you would like to update: ");

                int uniqueId = MakeSureUserEnteredANum();
                Developer existingDevContent = _developerRepo.GetDeveloperById(uniqueId);
                if (existingDevContent == null)
                {
                    Console.WriteLine("We are not able to find that Employee Id.");
                    PauseProgram();
                    return;
                }
                Developer updateDevContent = new Developer();
                Console.WriteLine($"\nCurrent Employee First Name: {existingDevContent.FirstName}");
                Console.Write("Please enter the new First Name: ");
                updateDevContent.FirstName = Console.ReadLine();
                Console.WriteLine($"\nCurrent Employee Last Name: {existingDevContent.LastName}");
                Console.Write("Please enter the new Last Name: ");
                updateDevContent.LastName = Console.ReadLine();
                Console.WriteLine($"\n Current Employee Id Number: {existingDevContent.IdNumber}");
                Console.Write("Please enter the new Id Number: ");

                //Making sure user entered a number
                bool checkUserGaveWrongNum = true;
                while (checkUserGaveWrongNum)
                {
                    int userInputForNewDevId = MakeSureUserEnteredANum();
                    bool verifyIfUniqueId = CheckIfDevNumIsUnique(userInputForNewDevId);
                    if (verifyIfUniqueId == true)
                    {
                        checkUserGaveWrongNum = false;
                    }
                    else
                    {
                        Console.WriteLine("\nThe Developer Id must be unique.");
                        Console.Write("Please enter another number: ");
                    }
                    updateDevContent.IdNumber = userInputForNewDevId;
                }
                Console.WriteLine($"\nCurrent Pluralsight Access: {existingDevContent.Pluralsight}");
                Console.Write("Please enter new access with True or False: ");
                string userAnswer = Console.ReadLine().ToLower();
                updateDevContent.Pluralsight = CheckUserAnswerForTrueOrFalse(userAnswer);
                if (_developerRepo.UpdateExistingDevContent(existingDevContent, updateDevContent))
                {
                    Console.Clear();
                    Console.WriteLine("Update successful\n");
                    DisplayDeveloperInfo(updateDevContent);
                }
                else
                {
                    Console.WriteLine("Update Failed.");
                }
                Console.Write("\nWould you like to update another Developer? [Y or N]: ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    updateEmployee = false;
                }
                else
                {
                    updateEmployee = false;
                }
            }

            PauseProgram();
        }
        private void RemoveEmployeeById()
        {
            bool removeEmployee = true;
            while (removeEmployee)
            {
                Console.Clear();

                DisplayAllDeveloperInfo();
                //Double check that list has employees to remove
                List<Developer> listOfAllDevs = _developerRepo.GetAllDeveloperInfo();
                if (listOfAllDevs.Count == 0)
                {
                    removeEmployee = false;
                }
                else
                {
                    Console.Write("\nPlease enter the Id number for the Employee you would like to remove: ");

                    //Make sure user gave a number
                    bool checkUserGaveWrongNum = true;
                    while (checkUserGaveWrongNum)
                    {
                        int uniqueId = MakeSureUserEnteredANum();
                        Developer existingDevContent = _developerRepo.GetDeveloperById(uniqueId);
                        if (existingDevContent == null)
                        {
                            Console.WriteLine("\nWe are not able to find that Employee Id.");
                            PauseProgram();
                            return;
                        }
                        Console.WriteLine($"\nAre you sure you want to delete {existingDevContent.FullName}?");
                        Console.Write("Please confirm with Yes or No: ");
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer == "yes")
                        {
                            Console.Clear();
                            _developerRepo.DeleteDevContent(existingDevContent);
                            Console.WriteLine("This developer was removed.\n\n");
                            DisplayDeveloperInfo(existingDevContent);
                        }
                        else if (userAnswer == "no")
                        {
                            Console.WriteLine($"\n{existingDevContent.FullName} was not deleted.");
                            PauseProgram();
                            return;
                        }
                        else
                        {
                            return;
                        }
                        Console.Write("\nWould you like to remove another Developer? [Y or N]: ");
                        string answer = Console.ReadLine().ToUpper();
                        if (answer == "Y")
                        {
                            continue;
                        }
                        else if (answer == "N")
                        {
                            removeEmployee = false;
                        }
                        else
                        {
                            removeEmployee = false;

                        }
                    }
                }
            }
            PauseProgram();
        }
        private void DevelopersWithPluralsight()
        {
            Console.Clear();
            Console.WriteLine("A list of Employees That Need the Pluralsight license:\n" +
                "***************************************************************\n");

            List<Developer> listOfAllDevelopers = _developerRepo.GetAllDeveloperInfo();
            int index = 1;
            foreach (Developer devContent in listOfAllDevelopers)
            {
                if (devContent.Pluralsight == false)
                {
                    Console.WriteLine($"{index}. Full name: {devContent.FullName}: Id- {devContent.IdNumber}");
                    index++;
                }
            }
            PauseProgram();
        }
        private void AddDevTeams()
        {
            Console.Clear();
            Console.WriteLine("Your new Developer Team\n" +
                "************************************\n");
            Console.Write("Please enter the name for your new Developer Team: ");

            string userTeamName = Console.ReadLine();
            Console.Write("\nPlease enter the Id number for the Team: ");

            //verifying the user entered a number
            int userTeamId = MakeSureUserEnteredANum();

            List<Developer> developerCheck = _developerRepo.GetAllDeveloperInfo();
            List<Developer> developers = new List<Developer>();
            if (developerCheck.Count() > 0)
            {
                bool addDevTeam = true;
                while (addDevTeam)
                {
                    Console.Write("\nWould you like to add members to your team? [Y/N] ");
                    string userAddDevsYesOrNo = Console.ReadLine().ToUpper();
                    if (userAddDevsYesOrNo == "Y")
                    {
                        Console.Clear();
                        DisplayAllDeveloperInfo();
                        Console.Write("\nPlease choose Developer by Id: ");

                        //Make sure user gave a number
                        int uniqueId = MakeSureUserEnteredANum();
                        Developer developer = _developerRepo.GetDeveloperById(uniqueId);
                        developers.Add(developer);
                    }
                    else
                    {
                        addDevTeam = false;
                    }
                }
            }

            DevTeam team = new DevTeam(userTeamName, userTeamId, developers);
            _devTeamRepo.AddDevTeamContentToDirectory(team);
            DisplayOneDevTeam(team);
            PauseProgram();
        }
        private void UpdateDeveloperOnTeams()
        {
            bool updateDevsOnTeams = true;
            while (updateDevsOnTeams)
            {
                Console.Clear();
                DisplayAllDevTeams();

                List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
                if (listOfAllDevTeams.Count == 0)
                {
                    updateDevsOnTeams = false;
                }
                else
                {
                    Console.Write("\n\nPlease enter the Id number for the Developer Team you would like to update: ");
                    var uniqueId = MakeSureUserEnteredANum();
                    var targetdevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(uniqueId);
                    if (targetdevTeamContent == null)
                    {
                        Console.WriteLine("\nWe are not able to find that Developer Team Id.");
                        return;
                    }

                    Console.Clear();
                    List<Developer> developers = _developerRepo.GetAllDeveloperInfo();
                    if (developers.Count() > 0)
                    {
                        DisplayAllDeveloperInfo();
                        Console.WriteLine("\n*******************************************\n" +
                            $"Which Developer would you like to add to {targetdevTeamContent.TeamName}?");
                        Console.Write("\nEnter the Developer Id you would like to add to: ");

                        int userInputId = MakeSureUserEnteredANum();
                        var devToAddToTeam = _developerRepo.GetDeveloperById(userInputId);
                        _devTeamRepo.AddDevToTeam(uniqueId, devToAddToTeam);
                    }
                    else
                    {
                        Console.WriteLine("We currently don't have any Developers listed");
                        updateDevsOnTeams = false;
                    }

                    Console.Write("\nWould you like to update another Developer Team? [Y or N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        continue;
                    }
                    else if (answer == "N")
                    {
                        updateDevsOnTeams = false;
                    }
                    else
                    {
                        updateDevsOnTeams = false;
                    }
                }
            }
            PauseProgram();
        }
        private void UpdateDevTeamById()
        {
            bool updateDevTeams = true;
            while (updateDevTeams)
            {
                Console.Clear();
                DisplayAllDevTeams();

                List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
                if (listOfAllDevTeams.Count == 0)
                {
                    updateDevTeams = false;
                }
                else
                {
                    Console.Write("\n\nPlease enter the Id number for the Developer Team you would like to update: ");
                    var uniqueId = MakeSureUserEnteredANum();
                    DevTeam targetdevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(uniqueId);
                    if (targetdevTeamContent == null)
                    {
                        Console.WriteLine("\nWe are not able to find that Developer Team Id.");
                        PauseProgram();
                        return;
                    }
                    DevTeam updatedevTeamContent = new DevTeam();
                    Console.WriteLine($"\nThe current team name is {targetdevTeamContent.TeamName}.");
                    Console.Write("Please enter the new name: ");
                    updatedevTeamContent.TeamName = Console.ReadLine();
                    Console.WriteLine($"\nThe current team id is {targetdevTeamContent.TeamId}");
                    Console.Write("Please enter the new team Id: ");

                    bool checkUserInputNum = true;
                    while (checkUserInputNum)
                    {
                        //verifying the user entered a number
                        updatedevTeamContent.TeamId = MakeSureUserEnteredANum();
                        //making sure the user entered a unique number for the team
                        bool checkIfGaveUniqueId = MakeSureGaveUniqueId(updatedevTeamContent.TeamId);
                        if (checkIfGaveUniqueId == true)
                        {
                            checkUserInputNum = false;
                        }
                        else
                        {
                            Console.WriteLine("\nThe team Id must be unique.");
                            Console.Write("Please enter another number: ");
                        }
                    }
                    if (_devTeamRepo.UpdatingDevTeamInfo(targetdevTeamContent, updatedevTeamContent))
                    {
                        Console.Clear();
                        Console.WriteLine("Update successful");
                        Console.WriteLine($"\nYou updated {updatedevTeamContent.TeamName} Id: {updatedevTeamContent.TeamId}");
                    }
                    else
                    {
                        Console.WriteLine("Update failed.");
                    }
                    Console.Write("\nWould you like to update another Developer Team? [Y or N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        continue;
                    }
                    else if (answer == "N")
                    {
                        updateDevTeams = false;
                    }
                    else
                    {
                        updateDevTeams = false;
                    }
                }

            }
            PauseProgram();
        }
        private void RemoveDevTeamById()
        {
            bool removeDevTeam = true;
            while (removeDevTeam)
            {
                Console.Clear();
                DisplayAllDevTeams();

                List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
                if (listOfAllDevTeams.Count == 0)
                {
                    removeDevTeam = false;
                }
                else
                {
                    Console.Write("\nPlease enter the Id number for the Developer Team you would like to remove: ");
                    //verify user entered a number
                    int userInputDevTeamId = MakeSureUserEnteredANum();
                    DevTeam existingDevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(userInputDevTeamId);
                    if (existingDevTeamContent == null)
                    {
                        Console.WriteLine("\nWe are not able to find that Developer Team Id.");
                        PauseProgram();
                        return;
                    }
                    Console.WriteLine($"\nAre you sure you want to delete team {existingDevTeamContent.TeamName}?");
                    Console.Write("Please confirm with Yes or No: ");
                    string userAnswer = Console.ReadLine().ToLower();
                    if (userAnswer == "yes")
                    {
                        Console.Clear();
                        _devTeamRepo.DeleteDevTeam(existingDevTeamContent);
                        Console.WriteLine("This Developer Team was removed\n" +
                            "***************************************\n");
                        Console.WriteLine($"{existingDevTeamContent.TeamName} was deleted with Id: {existingDevTeamContent.TeamId}");
                    }
                    else
                    {
                        Console.WriteLine($"\nTeam {existingDevTeamContent.TeamName} was not deleted.");
                        PauseProgram();
                        return;
                    }
                    Console.Write("\nWould you like to remove another Developer Team? [Y or N]: ");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        continue;
                    }
                    else if (answer == "N")
                    {
                        removeDevTeam = false;
                    }
                    else
                    {
                        removeDevTeam = false;
                    }
                }
            }
            PauseProgram();
        }
        private void DisplayDeveloperInfo(Developer devContent)
        {
            Console.WriteLine($"Full name: {devContent.FullName}- Id: {devContent.IdNumber}\n");
        }
        private void PauseProgram()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DisplayAllDeveloperInfo()
        {
            Console.WriteLine("A list of all Developers\n" +
               "******************************************\n");
            List<Developer> listOfAllDevelopers = _developerRepo.GetAllDeveloperInfo();
            if (listOfAllDevelopers.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Developers listed.");
            }
            else
            {
                int index = 1;
                foreach (Developer devContent in listOfAllDevelopers)
                {
                    Console.WriteLine($"{index}. Full name: {devContent.FullName}: Id- {devContent.IdNumber}");
                    index++;
                }
            }
        }
        private bool CheckUserAnswerForTrueOrFalse(string userAnswer)
        {
            while (userAnswer != "true" && userAnswer != "false")
            {
                Console.Write("Please enter either True or False: ");
                userAnswer = Console.ReadLine().ToLower();
            }
            bool convertUserAnswer = Convert.ToBoolean(userAnswer);
            return convertUserAnswer;
        }
        private void DisplayAllDevTeams()
        {
            Console.WriteLine("A list of all the Developer Teams\n" +
              "******************************************\n");
            List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
            if (listOfAllDevTeams.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Developer Teams listed.");
            }
            else
            {
                var index = 1;
                foreach (DevTeam devTeamContent in listOfAllDevTeams)
                {
                    Console.WriteLine($"{index}. Team Name: {devTeamContent.TeamName}- Id: {devTeamContent.TeamId}");
                    index++;
                }
            }
        }
        private void DisplayOneDevTeam(DevTeam devTeamInfo)
        {
            Console.WriteLine($"\n{devTeamInfo.TeamName} was created with Id: {devTeamInfo.TeamId}");
        }
        private void DisplayAllDevTeamWithDevs()
        {
            Console.WriteLine("A List of all The Developer Teams and Members\n" +
               "**************************************************\n");
            List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
            if (listOfAllDevTeams.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Developer Teams listed.");
            }
            else
            {
                int index = 1;
                foreach (DevTeam devTeamContent in listOfAllDevTeams)
                {
                    Console.WriteLine($"\nTeam name: {devTeamContent.TeamName}- Id: {devTeamContent.TeamId}\n" +
                        $"Members in the team: \n");
                    if (devTeamContent.AddTeamMembers != null)
                    {
                        foreach (Developer devInfo in devTeamContent.AddTeamMembers)
                        {
                            Console.WriteLine($"{index}. {devInfo.FullName}- Id: {devInfo.IdNumber}");
                            index++;
                        }
                    }
                }
            }
            PauseProgram();
        }
        private void MakeSureUserEnteredANum(Developer name)
        {
            bool checkUserGaveWrongNum = true;
            while (checkUserGaveWrongNum)
            {
                string stringInput = Console.ReadLine();
                if (!int.TryParse(stringInput, out int uniqueId))
                {
                    Console.Write("Please enter a number: ");
                    continue;
                }
                else
                {
                    uniqueId = Int32.Parse(stringInput);
                    name.IdNumber = uniqueId;
                    checkUserGaveWrongNum = false;
                }
            }
        }
        private int MakeSureUserEnteredANum()
        {
            bool checkUserGaveWrongNum = true;
            while (checkUserGaveWrongNum)
            {
                string stringInput = Console.ReadLine();
                if (!int.TryParse(stringInput, out int uniqueId))
                {
                    Console.Write("Please enter a number: ");
                    continue;
                }
                else
                {
                    return Int32.Parse(stringInput);
                }
            }
            return 0;
        }
        private bool MakeSureGaveUniqueId(int uniqueId)
        {
            DevTeam oneDevTeams = _devTeamRepo.GetOnlyOneDevTeam(uniqueId);
            if (oneDevTeams != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckIfDevNumIsUnique(int uniqueId)
        {
            Developer devCheck = _developerRepo.GetDeveloperById(uniqueId);
            if (devCheck != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
