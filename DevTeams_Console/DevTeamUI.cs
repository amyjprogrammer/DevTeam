﻿using DevTeams_Repository;
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
                Console.WriteLine
                    (
                        "Enter the number of your selection:\n" +
                        "1. Show Developer Options\n" +
                        "2. Show Developer Team Options\n" +
                        "3. Exit"
                    );
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
                        Console.WriteLine("Please enter a valid number between 1-3.\n" +
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
                Console.WriteLine
                    (
                        "Enter the number of your selection:\n" +
                        "1. Show all Developers\n" +
                        "2. Add new Developer\n" +
                        "3. Edit Developer Information\n" +
                        "4. Remove Developer\n" +
                        "5. Developers with Pluralsight license\n" +
                        "6. Main Menu"
                    );
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
                        Console.WriteLine("Please enter a valid number between 1-6.\n" +
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
                Console.WriteLine
                    (
                        "Enter the number of your selection:\n" +
                        "1. Show all Developer Teams\n" +
                        "2. Add new Developer Team\n" +
                        "3. Edit Developer Team\n" +
                        "4. Delete Developer Teams\n" +
                        "5. Main Menu"
                    );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllDevTeams();
                        break;
                    case "2":
                        AddDevTeams();
                        break;
                    case "3":
                        UpdateDevTeamById();
                        break;
                    case "4":
                        RemoveDevTeamById();
                        break;
                    case "5":
                        isDevTeamRunning = false;
                        RunMenu(false);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-5.\n" +
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
                Developer createDev = new Developer();
                Console.WriteLine("Information for the New Developer");
                Console.Write("Please enter the first name: ");
                createDev.FirstName = Console.ReadLine();
                Console.Write("Please enter the last name: ");
                createDev.LastName = Console.ReadLine();
                Console.Write("Please enter the unique ID number: ");
                /*
                                I need to add a way to check the number and make sure it is unique
                */
                int uniqueId = Convert.ToInt32(Console.ReadLine());
                createDev.IdNumber = uniqueId;
                Console.WriteLine("Does this employee have Pluralsight access?");
                Console.Write("Answer true or false: ");
                string userAnswer = Console.ReadLine().ToLower();
                createDev.Pluralsight = CheckUserAnswerForTrueOrFalse(userAnswer);
                _developerRepo.AddDeveloperToList(createDev);
                Console.Clear();
                DisplayDeveloperInfo(createDev);
                Console.WriteLine("This Developer was just added.");
                Console.WriteLine("Would you like to add another Developer? [Y or N]");
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
        private void UpdateEmployeeById()
        {
            bool updateEmployee = true;
            while (updateEmployee)
            {
                Console.Clear();
                DisplayAllDeveloperInfo();
                Console.Write("\n\nPlease enter the Id number for the Employee you would like to update: ");
                int userInputEmployeeId = Convert.ToInt32(Console.ReadLine());
                Developer existingDevContent = _developerRepo.GetDeveloperById(userInputEmployeeId);
                if (existingDevContent == null)
                {
                    Console.WriteLine("We are not able to find that Employee Id.");
                    PauseProgram();
                    return;
                }
                Developer updateDevContent = new Developer();
                Console.WriteLine($"Employee First Name: {existingDevContent.FirstName}\n");
                Console.Write("Please enter the new First Name: ");
                updateDevContent.FirstName = Console.ReadLine();
                Console.WriteLine($"Employee Last Name: {existingDevContent.LastName}\n");
                Console.Write("Please enter the new Last Name: ");
                updateDevContent.LastName = Console.ReadLine();
                Console.WriteLine($"Employee Id Number: {existingDevContent.IdNumber}\n");
                Console.Write("Please enter the new Id Number: ");
                int idInfo = Convert.ToInt32(Console.ReadLine());
                updateDevContent.IdNumber = idInfo;
                /* check for unique id*/
                Console.WriteLine($"Do they have access to Pluralsight: {existingDevContent.Pluralsight}\n");
                Console.Write("Please enter either true or false: ");
                string userAnswer = Console.ReadLine().ToLower();
                updateDevContent.Pluralsight = CheckUserAnswerForTrueOrFalse(userAnswer);
                if (_developerRepo.UpdateExistingDevContent(existingDevContent, updateDevContent))
                {
                    Console.Clear();
                    Console.WriteLine("Update successful");
                    DisplayDeveloperInfo(updateDevContent);
                }
                else
                {
                    Console.WriteLine("Update Failed.");
                }
                Console.WriteLine("\nWould you like to update another Developer? [Y or N]");
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
                Console.Write("\n\nPlease enter the Id number for the Employee you would like to remove: ");
                int userInputEmployeeId = Convert.ToInt32(Console.ReadLine());
                Developer existingDevContent = _developerRepo.GetDeveloperById(userInputEmployeeId);
                if (existingDevContent == null)
                {
                    Console.WriteLine("We are not able to find that Employee Id.");
                    PauseProgram();
                    return;
                }
                Console.WriteLine($"Are you sure you want to delete {existingDevContent.FullName}?");
                Console.Write("Please confirm with Yes or No: ");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "yes")
                {
                    Console.Clear();
                    _developerRepo.DeleteDevContent(existingDevContent);
                    DisplayDeveloperInfo(existingDevContent);
                    Console.WriteLine("This developer was removed.");
                }
                else if (userAnswer == "no")
                {
                    Console.WriteLine($"{existingDevContent.FullName} was not deleted.");
                    PauseProgram();
                    return;
                }
                else
                {
                    return;
                }
                Console.WriteLine("\nWould you like to remove another Developer? [Y or N]");
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
            PauseProgram();
        }
        private void DevelopersWithPluralsight()
        {
            Console.Clear();
            Console.WriteLine("A list of Employees with a Pluralsight license:\n");
            List<Developer> listOfAllDevelopers = _developerRepo.GetAllDeveloperInfo();
            int index = 1;
            foreach (Developer devContent in listOfAllDevelopers)
            {
                if (devContent.Pluralsight == true)
                {
                    Console.WriteLine($"{index}. {devContent.FullName}: Id- {devContent.IdNumber}");
                    index++;
                }
            }
            PauseProgram();
        }
        private void AddDevTeams()
        {
            Console.Clear();
            Console.Write("Please enter the name for your Developer Team: ");
            string userTeamName = Console.ReadLine();
            Console.Write("Please enter the Id number for the Team: ");
            int userTeamId = Convert.ToInt32(Console.ReadLine());
            List<Developer> developers = new List<Developer>();
            bool addDevTeam = true;
            while (addDevTeam)
            {
                Console.WriteLine("Would you like to add members to your team? [Y/N] ");
                string userAddDevsYesOrNo = Console.ReadLine();
                if(userAddDevsYesOrNo == "Y".ToUpper())
                {
                    Console.Clear();
                    DisplayAllDeveloperInfo();
                    Console.WriteLine("Please choose Developer by Id.");
                    int userInputDevId = int.Parse(Console.ReadLine());
                    Developer developer = _developerRepo.GetDeveloperById(userInputDevId);
                    developers.Add(developer);
                }
                else
                {
                    addDevTeam = false;
                }
            }
            DevTeam team = new DevTeam(userTeamName, userTeamId, developers);
            _devTeamRepo.AddDevTeamContentToDirectory(team);
            PauseProgram();
        }
        private void ShowAllDevTeams()
        {
            Console.Clear();
            Console.WriteLine("The Developer Teams are listed below:\n");
            DisplayAllDevTeams();
            PauseProgram();
        }
        private void SelectDevelopersToAddToTeam()
        {
            bool addDevToTeams = true;
            while (addDevToTeams)
            {
                Console.Clear();
                List<Developer> addDevs = _developerRepo.GetAllDeveloperInfo();
                List<DevTeam> addDevTeam = _devTeamRepo.GetAllDevTeams();
                Console.WriteLine("The list of the Developer Teams:\n");
                DisplayAllDevTeams();
                Console.Write("\nPlease enter the ID number for the Developer Team you would like to add Developers to: ");
                int devTeamInput = Convert.ToInt32(Console.ReadLine());
                DevTeam targetdevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(devTeamInput);
                if (targetdevTeamContent == null)
                {
                    Console.WriteLine("We are no able to find that Developer Team Id.");
                    PauseProgram();
                    return;
                }
                DisplayAllDeveloperInfo();
                Console.WriteLine($"Please select the ID number for the Developer you want to add to {targetdevTeamContent.TeamName}");
                int userInputEmployeeId = int.Parse(Console.ReadLine());
                Developer existingDevContent = _developerRepo.GetDeveloperById(userInputEmployeeId);
                if (existingDevContent == null)
                {
                    Console.WriteLine("We are not able to find that Employee Id.");
                    PauseProgram();
                    return;
                }
                _devTeamRepo.AddDevToDevTeam(devTeamInput);
                Console.WriteLine("\nWould you like to update another Developer Team? [Y or N]");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    addDevToTeams = false;
                }
                else
                {
                    addDevToTeams = false;
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
                Console.WriteLine("\n\nPlease enter the Id number for the Developer Team you would like to update:");
                int devTeamInput = Convert.ToInt32(Console.ReadLine());
                DevTeam targetdevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(devTeamInput);
                if (targetdevTeamContent == null)
                {
                    Console.WriteLine("We are no able to find that Developer Team Id.");
                    PauseProgram();
                    return;
                }
                DevTeam updatedevTeamContent = new DevTeam();
                Console.WriteLine($"The current team name is {targetdevTeamContent.TeamName}.");
                Console.Write("Please enter the new name: ");
                updatedevTeamContent.TeamName = Console.ReadLine();
                Console.WriteLine($"The current team id is {targetdevTeamContent.TeamId}");
                Console.Write("Please enter the new team Id: ");
                updatedevTeamContent.TeamId = Convert.ToInt32(Console.ReadLine());
                if (_devTeamRepo.UpdatingDevTeamInfo(targetdevTeamContent, updatedevTeamContent))
                {
                    Console.Clear();
                    Console.WriteLine("Update successful\n");
                    DisplayOneDevTeam(updatedevTeamContent);
                }
                else
                {
                    Console.WriteLine("Update failed.");
                }
                Console.WriteLine("\nWould you like to update another Developer Team? [Y or N]");
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
                PauseProgram();
            }
        }
        private void RemoveDevTeamById()
        {
            bool removeDevTeam = true;
            while (removeDevTeam)
            {
                Console.Clear();
                DisplayAllDevTeams();
                Console.Write("\n\nPlease enter the Id number for the Developer Team you would like to remove: ");
                int userInputDevTeamId = Convert.ToInt32(Console.ReadLine());
                DevTeam existingDevTeamContent = _devTeamRepo.GetOnlyOneDevTeam(userInputDevTeamId);
                if (existingDevTeamContent == null)
                {
                    Console.WriteLine("We are not able to find that Employee Id.");
                    PauseProgram();
                    return;
                }
                Console.WriteLine($"Are you sure you want to delete {existingDevTeamContent.TeamName}?");
                Console.Write("Please confirm with Yes or No: ");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "yes")
                {
                    Console.Clear();
                    _devTeamRepo.DeleteDevTeam(existingDevTeamContent);
                    Console.WriteLine($"\n{existingDevTeamContent.TeamName} was deleted with Id: {existingDevTeamContent.TeamId}");
                    Console.WriteLine("This Developer Team was removed.");
                }
                else
                {
                    Console.WriteLine($"{existingDevTeamContent.TeamName} was not deleted.");
                    PauseProgram();
                    return;
                }
                Console.WriteLine("\nWould you like to remove another Developer Team? [Y or N]");
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
            PauseProgram();
        }
        private void DisplayDeveloperInfo(Developer devContent)
        {
            Console.WriteLine($"{devContent.FullName}- Id: {devContent.IdNumber}");
        }
        private void PauseProgram()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DisplayAllDeveloperInfo()
        {
            List<Developer> listOfAllDevelopers = _developerRepo.GetAllDeveloperInfo();
            int index = 1;
            foreach (Developer devContent in listOfAllDevelopers)
            {
                Console.WriteLine($"{index}. {devContent.FullName}: Id- {devContent.IdNumber}");
                index++;
            }
        }
        private bool CheckUserAnswerForTrueOrFalse(string userAnswer)
        {
            while (userAnswer != "true" && userAnswer != "false")
            {
                Console.WriteLine("Please enter either true or false: ");
                userAnswer = Console.ReadLine().ToLower();
            }
            bool convertUserAnswer = Convert.ToBoolean(userAnswer);
            return convertUserAnswer;
        }
        private void DisplayAllDevTeams()
        {
            List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
            var index = 1;
            foreach (DevTeam devTeamContent in listOfAllDevTeams)
            {
                Console.WriteLine($"{index}. {devTeamContent.TeamName}- Id: {devTeamContent.TeamId}");
                index++;
            }
        }
        private void DisplayOneDevTeam(DevTeam devTeamInfo)
        {
            Console.WriteLine($"\n{devTeamInfo.TeamName} was created with Id: {devTeamInfo.TeamId}");
        }
        private void DisplayAllDevTeamWithDevs()
        {
            List<DevTeam> listOfAllDevTeams = _devTeamRepo.GetAllDevTeams();
            foreach (DevTeam devTeamContent in listOfAllDevTeams)
            {
                Console.WriteLine($"\n{devTeamContent.TeamName}- Id: {devTeamContent.TeamId}");
                foreach (Developer devInfo in devTeamContent.AddTeamMembers)
                {
                    Console.WriteLine($"{devInfo.FullName}- Id: {devInfo.IdNumber}");
                }
            }
        }
    }
}
