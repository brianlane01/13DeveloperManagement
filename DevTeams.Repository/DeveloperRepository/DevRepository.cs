using System.Linq;
using DevTeams.Data.Entities;

namespace DevTeams.Repository.DeveloperRepository
{
    public class DevRepository
    {
        //* Create a Fake Database 
        private readonly List<Developer> _devDbContext = new List<Developer>();

        //* Database Id base value:
        private int _count = 0;

        public DevRepository()
        {
            SeedDev();
        }

        private void AssignId(Developer developer)
        {
            _count++;
            developer.DevId = _count;
        }

        public bool AddDeveloper(Developer developer)
        {
            if (developer is null)
            {
                return false;
            }
            else
            {
                _count++;
                developer.DevId = _count;
                _devDbContext.Add(developer);
                return true;
            }
        }

        private bool SaveToDatabase(Developer developer)
        {
            AssignId(developer);
            _devDbContext.Add(developer);
            return true;
        }

        public bool DeleteDeveloper(Developer developer)
        {
            bool deleteResult = _devDbContext.Remove(developer);
            return deleteResult;
        }

        public Developer GetDeveloper(int id)
        {
            return _devDbContext.SingleOrDefault(x => x.DevId == id)!;
        }

        public List<Developer> GetDevelopers()
        {
            return _devDbContext;
        }

        public Developer GetDevsByTeam(int devTeamID)
        {
            foreach (Developer developer in _devDbContext)
            {
                if (developer.DevTeamId == devTeamID)
                {
                    return developer;
                }
            }
            return null;
        }

        private void SeedDev()
        {
            var dev1 = new Developer
            {
                DevTeamId = 1,
                FirstName = "Brian",
                LastName = "Lane",
                HasPluralsight = true
            };

            var dev2 = new Developer
            {
                DevTeamId = 2,
                FirstName = "Tripp",
                LastName = "Lane",
                HasPluralsight = true
            };
            var dev3 = new Developer
            {
                DevId = 3,
                FirstName = "Danette",
                LastName = "Peppers",
                HasPluralsight = false
            };

            _devDbContext.Add(dev1);
            _devDbContext.Add(dev2);
            _devDbContext.Add(dev3);
        }
    }
}