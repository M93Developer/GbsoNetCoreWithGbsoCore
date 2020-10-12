using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gbso.App.Model.General;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gbso.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return new PersonModel[] { new PersonModel(), new PersonModel()};
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public PersonModel Get(int id)
        {
            return new PersonModel();
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
