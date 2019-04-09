using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeopleSearch.Data.Domain;

namespace PeopleSearch.Data.Service
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons(int skip, int take);
        IEnumerable<Person> Search(string v);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleSearchContext _db;

        public PersonRepository(PeopleSearchContext ctx)
        {
            _db = ctx;
        }

        public IEnumerable<Person> GetPersons(int skip, int take)
        {
            return _db.Persons.Skip(skip).Take(take).ToList();
        }

        public IEnumerable<Person> Search(string v)
        {
            return _db.Persons.Where(c => IsMatch(c, v));
        }

        private bool IsMatch(Person person, string text)
        {
            return
                person.FirstName.Contains(text, StringComparison.InvariantCultureIgnoreCase)
                || person.LastName.Contains(text, StringComparison.InvariantCultureIgnoreCase);

        }
    }
}
