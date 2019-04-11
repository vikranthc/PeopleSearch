using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data.Domain;

namespace PeopleSearch.Data.Service
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersons(int skip, int take);
        Task<IEnumerable<Person>> Search(string v);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleSearchContext _db;

        public PersonRepository(PeopleSearchContext ctx)
        {
            _db = ctx;
        }

        public async Task<IEnumerable<Person>> GetPersons(int skip, int take)
        {
            return await _db.Persons
                .Include(c => c.PersonalInterests)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Person>> Search(string v)
        {
            return await _db.Persons
                .Include(c => c.PersonalInterests)
                .Where(c => c.IsMatch(v))
                .ToListAsync();
        }
    }
}
