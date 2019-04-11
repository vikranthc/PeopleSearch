using System.Linq;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data;
using PeopleSearch.Data.Domain;
using PeopleSearch.Data.Service;
using Xunit;

namespace PeopleSearch.Tests
{
    public class Person_Repository_Tests
    {
        [Fact]
        public void ReturnResults()
        {
            var options = new DbContextOptionsBuilder<PeopleSearchContext>()
                .UseInMemoryDatabase("testDb")
                .Options;

            using (var a = new PeopleSearchContext(options))
            {

                a.Persons.Add(new Person("Vikranth", "Ceakala"));
                a.Persons.Add(new Person("Vikranth", "Reddy"));
                a.SaveChanges();
                var repo = new PersonRepository(a);
                Assert.Equal(2, repo.GetPersons(0,100).Result.Count());
            }
        }

        [Fact]
        public void SearchResults()
        {
            var options = new DbContextOptionsBuilder<PeopleSearchContext>().UseInMemoryDatabase("testDb2").Options;

            using (var a = new PeopleSearchContext(options))
            {

                a.Persons.Add(new Person("Vikranth", "Ceakala"));
                a.Persons.Add(new Person("Vikranth", "Reddy"));
                a.SaveChanges();

                var repo = new PersonRepository(a);

                Assert.Single(repo.Search("reddy").Result);
                Assert.Equal(2, repo.Search("ranth").Result.Count());
                Assert.Empty(repo.Search("Dhatri").Result);
                Assert.Empty(repo.Search("Nelle").Result);
            }
        }
    }
}
