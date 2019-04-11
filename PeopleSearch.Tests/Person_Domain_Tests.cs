using PeopleSearch.Data.Domain;
using System;
using Xunit;

namespace PeopleSearch.Tests
{
    public class Person_Domain_Tests
    {
        [Fact]
        public void Person_Without_FirstName_Should_Fail()
        {
            var ex = Record.Exception(() => new Person("", "Ceakala"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void Person_Without_Empty_LastName_Should_Fail()
        {
            var ex = Record.Exception(() => new Person("Vikranth", "  "));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void Person_With_Future_Birthday_Should_Fail()
        {
            var futureDate = DateTime.Now.Add(TimeSpan.FromDays(1));
            var ex = Record.Exception(() => new Person("Vikranth", "Ceakala", futureDate));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void Person_Should_Be_Updatable()
        {
            var person1 = new Person("Vikranth", "C3ak@la", new DateTime(2016, 4, 4));
            var person2 = new Person("Vikranth", "Ceakala", new DateTime(1988, 11, 2));

            var person = person1.UpdateTo(person2);

            Assert.Equal(person1.LastName, person2.LastName);
            Assert.Equal(person1.DateOfBirth, person2.DateOfBirth);
        }

        public void Person_Search_Should_Match_FirstName_Or_LastName()
        {
            var person1 = new Person("Vikranth", "Ceakala", new DateTime(1988, 11, 2));
            var isMatch = person1.IsMatch("Vik");

            Assert.True(isMatch);
            Assert.False(person1.IsMatch("zz"));
            Assert.False(person1.IsMatch(null));
        }


        [Fact]
        public void PersonalInterest_Without_Interest_Should_Fail()
        {
            var ex = Record.Exception(() => new PersonalInterest(""));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void PersonalInterest_With_Interest_Should_Instantiate()
        {
            var ex = Record.Exception(() => new PersonalInterest("    Writing"));

            Assert.Null(ex);
        }

        [Fact]
        public void PersonalInterest_Should_Trim_WhiteSpace_Interest()
        {
            var userEnteredText = "    Rafting  ";
            var interest = new PersonalInterest(userEnteredText);

            Assert.Equal(interest.Interest, userEnteredText.Trim());
        }
    }
}
