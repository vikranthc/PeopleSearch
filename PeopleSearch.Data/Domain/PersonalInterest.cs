namespace PeopleSearch.Data.Domain
{
    public class PersonalInterest
    {
        public string Description { get; set; }

        public PersonalInterest(string description)
        {
            this.Description = description;
        }
        private PersonalInterest()
        {
            
        }
    }
}