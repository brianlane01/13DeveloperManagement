using System;
using System.Collections.Generic;
using System.Linq;
using DevTeams.Data.Entities;

namespace DevTeams.Repository.DeveloperTeamRepository
{
    public class DevTeamRepository
    {
        public DevTeamRepository()
        {
            SeedDevTeam();
        }
        private readonly List<DeveloperTeam> _devTeamDbContext = new List<DeveloperTeam>();

        private int _count = 0;

        private bool SaveToDatabase(DeveloperTeam developerTeam)
        {
            AssignDevTeamId(developerTeam);
            _devTeamDbContext.Add(developerTeam);
            return true;
        }

        private void AssignDevTeamId(DeveloperTeam developerTeam)
        {
            _count++;
            developerTeam.TeamId = _count;
        }

        public bool AddDevelopmentTeam(DeveloperTeam developerTeam)
        {
            if (developerTeam is null)
            {
                return false;
            }
            else
            {
                _count++;
                developerTeam.TeamId = _count;
                _devTeamDbContext.Add(developerTeam);
                return true;
            }
        }

        public bool DeleteDevelopmentTeam(DeveloperTeam developerTeam)
        {
            bool deleteResult = _devTeamDbContext.Remove(developerTeam);
            return deleteResult;
        }

        public DeveloperTeam GetDeveloperTeam(int id)
        {
            return _devTeamDbContext.SingleOrDefault(x => x.TeamId == id)!;
        }

        public List<DeveloperTeam> GetDeveloperTeams()
        {
            return _devTeamDbContext;
        }

        private void SeedDevTeam()
        {
            var devTeam1 = new DeveloperTeam
            {
                TeamId = 1,
                TeamName = "The Avengers"
            };

            var devTeam2 = new DeveloperTeam
            {
                TeamId = 2,
                TeamName = "New Mutants"
            };
            var devTeam3 = new DeveloperTeam
            {
                TeamId = 3,
                TeamName = "Justice League"
            };

            _devTeamDbContext.Add(devTeam1);
            _devTeamDbContext.Add(devTeam2);
            _devTeamDbContext.Add(devTeam3);
        }
    }
}