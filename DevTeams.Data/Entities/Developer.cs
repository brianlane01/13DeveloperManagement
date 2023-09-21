using System;
namespace DevTeams.Data.Entities
{
    public class Developer
    {
        public Developer()
        {
            
        }

        public Developer(string firstName, string lastName, bool hasPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
            
        }
        // Primary Key **Unique Identifier
        public int DevId { get; set; }
        public int DevTeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get
            {
                return $"{FirstName} {LastName}";
            }
            
        }

        public bool HasPluralsight { get; set; }
    }
}