
namespace DevTeams.Data.Entities
{
    public class DeveloperTeam
    {
        public DeveloperTeam()
        {
            
        }
        public int TeamId { get; set; }

        public string TeamName { get; set; }


        //* One developer team can have many developers
        public List<Developer> DevsOnTeam {get; set;} = new List<Developer>();
        
        // public DeveloperTeam(List<Developer> developers)
        // {
        //     Developer = developers;
        // }

        public DeveloperTeam( int teamId, string teamName)
        {
            TeamId = teamId;
            TeamName = teamName;
        }
    
    }
}