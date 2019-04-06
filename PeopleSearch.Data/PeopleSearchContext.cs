using System.Collections;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data.Domain;

namespace PeopleSearch.Data
{
    public class PeopleSearchContext : DbContext
    {
        public PeopleSearchContext(DbContextOptions<PeopleSearchContext> options) : base(options)
        {


        }

        public DbSet<Person> Persons { get; set; }
    }
}
