using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Data.Domain;
using PeopleSearch.Data.Service;

namespace PeopleSearch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IPersonRepository personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        
        public async Task<IEnumerable<Person>> Index(string searchText = null)
        {
            if (searchText == null)
            {
                return await personRepository.GetPersons(skip: 0, take: 100);
            }
            else
            {
                await Task.Delay(2500);
                return await personRepository.Search(searchText);
            }
        }
    }
}