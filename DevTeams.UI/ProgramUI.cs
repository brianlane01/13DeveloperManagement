
using DevTeams.Repository.DeveloperRepository;
using DevTeams.Repository.DeveloperTeamRepository;
using DevTeams.Data.Entities;

public class ProgramUI
{
    private readonly DevRepository _devRepo = new DevRepository();
    private readonly DevTeamRepository _devTeamRepo = new DevTeamRepository();
    private bool IsRunning = true;

    public void RunApplication()
    {
        Seed();
        Run();

    }

    private void Run()
    {
        while (IsRunning)
        {
            System.Console.WriteLine("Welcome to Dev_Teams\n" +
            "Please make a selection\n" +
            "1. Add Developer\n" +
            "2. Get All Developers\n" +
            "3. Get Developers By Team\n" +
            "4. Delete Dev Team\n" +
            "0. Close Application\n");
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    AddDeveloper();
                    break;
                case 2:
                    GetAllDevelopers();
                    break;
                case 3:
                    GetAllDeveloperTeams();
                    break;
                case 4:
                    DeleteADevTeam();
                    break;
                case 0:
                    IsRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("INVALID SELECTION");
                    break;
            }
        }
    }
    private bool CloseApplication()
    {
        return false;
    }

    private void GetAllDevelopers()
    {
        //Need to acces the _devRepo
        System.Console.WriteLine("== Dev Listing ==");
        var devsInDb = _devRepo.GetDevelopers();
        if (devsInDb.Count > 0)
        {
            foreach (Developer developer in devsInDb)
            {
                System.Console.WriteLine($"{developer.FullName} - Has Pluralsight: {developer.HasPluralsight}");
            }
        }

        Console.ReadKey();
    }

    private void GetAllDeveloperTeams()
    {
        //Need to acces the _devRepo
        System.Console.WriteLine("== Dev Team Listing ==");
        var devTeamsInDb = _devTeamRepo.GetDeveloperTeams();
        if (devTeamsInDb.Count > 0)
        {
            foreach (DeveloperTeam developerTeam in devTeamsInDb)
            {
                System.Console.WriteLine($"{developerTeam.TeamName} {developerTeam.TeamId}");
            }
        }

        Console.ReadKey();
    }

    private void DeleteADeveloper()
    {
        Console.WriteLine("Enter the ID of the Developer to delete: ");
        int userInput = int.Parse(Console.ReadLine());
        
            DevRepository existingDeveloper = DevRepository.GetDeveloper(userInput);

            if (existingDeveloper != null)
            {
                _devRepo.DeleteDeveloper(userInput);
                Console.WriteLine("Developer deleted successfully!");
            }
            else
            {
                Console.WriteLine("Developer not found.");
            }
    }

    private void AddDeveloper()
    {
        //Need to acces the _devRepo to save the devs to the database!
        Console.WriteLine("Enter Developer First Name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter Developer Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter Developer Team ID: ");
        int devTeamID = int.Parse(Console.ReadLine());

        Console.WriteLine("Does the Developer have Pluralsight access? (y/n): ");
        bool hasPluralsight = Console.ReadLine().ToLower() == "y";

        Developer newDeveloper = new Developer
        {
            FirstName = firstName,
            LastName = lastName,
            DevTeamId = devTeamID,
            HasPluralsight = hasPluralsight
        };

        _devRepo.AddDeveloper(newDeveloper);
        Console.WriteLine("Developer added successfully!");
    }

    private void DeleteADevTeam()
    {
        
        Console.Clear();
        Console.WriteLine("Which Team do you want to remove?");
        List<DeveloperTeam> teamList = new List<DeveloperTeam>();

        if (teamList.Count > 0)
        {
            
            int count = 1;

            foreach (DeveloperTeam developerTeam in teamList)
            {
                count++;
                Console.WriteLine($"{count}. {developerTeam.TeamId}");
            }

            int targetContentId = int.Parse(Console.ReadLine()!);
            int targetIndex = targetContentId - 1;

            if (targetIndex >= 0 && targetIndex < teamList.Count)
            {
                DeveloperTeam desiredTeams = teamList[targetIndex];

                if(_devTeamRepo.DeleteDevelopmentTeam(desiredTeams))
                    Console.WriteLine($"{desiredTeams.TeamId} was Successfully Deleted.");
                else
                    Console.WriteLine($"{desiredTeams.TeamId} was Failed to be Deleted.");
            }
            else
            {
                Console.WriteLine("Invalid Id selection.");
            }

        }
        else
        {
            Console.WriteLine("There are no teams available currently.");
        }

        Console.ReadKey();
    }
    // private void DeleteADevTeam
    // {
    //     Console.WriteLine("Enter the ID of the DevTeam to delete: ");
    //     int userInput = int.Parse(Console.ReadLine());
      
    //         DevTeam existingDevTeam = devTeamRepo.GetTeamById(teamId);

    //         if (existingDevTeam != null)
    //         {
    //             devTeamRepo.DeleteTeam(teamId);
    //             Console.WriteLine("DevTeam deleted successfully!");
    //         }
    //         else
    //         {
    //             Console.WriteLine("DevTeam not found.");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Invalid input. Please enter a valid DevTeam ID.");
    //     }
    // }

    private void Seed()
    {
        // You have to create them here
        //you have to add them to the database here as well
        Developer devA = new Developer("Bill", "Burr", false);
        Developer devB = new Developer("George", "Carlin", true);

        _devRepo.AddDeveloper(devA);
        _devRepo.AddDeveloper(devB);
    }
}

