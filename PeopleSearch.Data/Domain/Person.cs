using System;
using System.Collections.Generic;

namespace PeopleSearch.Data.Domain
{
    public sealed class Person
    {
        private Person() {/* For use by Entity Framework */ }
        public Person(string firstName, string lastName, DateTime? dob = null)
        {
            if(String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First Name is required", nameof(firstName));

            if(String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last Name is empty", nameof(lastName));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dob;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public ICollection<PersonalInterest> PersonalInterests { get; set; } = new List<PersonalInterest>();
        public byte[] Avatar { get; set; }

    }
}