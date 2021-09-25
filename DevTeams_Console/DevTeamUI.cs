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
            RunMenu();
        }
        //check that the ID is unique or are we assigning the ID?
        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                        "Enter the number of your selection:\n" +
                        "1. Show all Developers\n" +
                        "2. Add new Developer\n" +
                        "3. Edit Developer Information\n" +
                        "4. Delete Developer\n" +
                        "5. Show all Developer Teams\n" +
                        "6. Add new Developer Team\n" +
                        "7. Edit Developer Team\n" +
                        "8. Delete Developer Teams\n" +
                        "9. Developers with Pluralsight license\n" +
                        "10. Exit"
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
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        DevelopersWithPluralsight();
                        break;
                    case "10":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-9.\n" +
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
                CheckUserAnswerForTrueOrFalse(userAnswer);
                bool convertUserAnswer = Convert.ToBoolean(userAnswer);
                createDev.Pluralsight = convertUserAnswer;
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
                CheckUserAnswerForTrueOrFalse(userAnswer);
                bool convertUserAnswer = Convert.ToBoolean(userAnswer);
                updateDevContent.Pluralsight = convertUserAnswer;
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
                _developerRepo.DeleteDevContent(existingDevContent);
                DisplayDeveloperInfo(existingDevContent);
                Console.WriteLine("This developer was removed.");
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
        private void CheckUserAnswerForTrueOrFalse(string userAnswer)
        {
            while (userAnswer != "true" && userAnswer != "false")
            {
                Console.WriteLine("Please enter either true or false: ");
                userAnswer = Console.ReadLine().ToLower();
            }
        }
    }
}
