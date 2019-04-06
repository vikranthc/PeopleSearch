﻿using System;
using System.Collections.Generic;

namespace PeopleSearch.Data.Domain
{
    public sealed class Person
    {
        public long PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public Address Address { get; private set; }
        public IEnumerable<PersonalInterest> PersonalInterests { get; private set; } = new List<PersonalInterest>();
        public byte[] Avatar { get; private set; }

        private Person() {/* For use by Entity Framework */ }

        public Person(
            string firstName,
            string lastName,
            DateTime? dob = null,
            IEnumerable<PersonalInterest> personalInterests = null,
            Address address = null,
            byte[] avatar = null)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First Name is required", nameof(firstName));

            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last Name is required", nameof(lastName));

            if (dob != null && dob > DateTime.Today)
                throw new ArgumentException("Date of Birth should be in the past", nameof(dob));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dob;
            this.Address = address;
            this.Avatar = avatar;
            this.PersonalInterests = personalInterests ?? new List<PersonalInterest>();
        }

        public Person UpdateTo(Person person)
        {
            this.Address = person.Address;
            this.PersonalInterests = person.PersonalInterests;
            this.Avatar = person.Avatar;
            this.DateOfBirth = person.DateOfBirth;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;

            return this;
        }
    }
}