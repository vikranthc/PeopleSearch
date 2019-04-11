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
            await Task.Delay(2500);
            if(String.IsNullOrWhiteSpace(searchText))
            {
                return await personRepository.GetPersons(skip:0, take:100);
            }
            else
            {
                return await personRepository.Search(searchText);
            }
        }
    }
}