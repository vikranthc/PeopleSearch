using System;

namespace PeopleSearch.Data.Domain
{
    public class PersonalInterest
    {
        public long PersonalInterestId { get; private set; }

        public string Interest { get; private set; }

        public PersonalInterest(string interest)
        {
            if(string.IsNullOrWhiteSpace(interest))
                throw new ArgumentException("Interest is required", nameof(interest));

            this.Interest = interest.Trim();
        }

        private PersonalInterest()
        {
            /* For EF */
        }
    }
}