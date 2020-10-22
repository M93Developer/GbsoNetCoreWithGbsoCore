using System.Collections.Generic;
using Gbso.App.Data.General;
using Gbso.App.Model.General;
using Gbso.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Gbso.Core.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gbso.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : AppControllerBase
    {
        public PersonController(IConfiguration configuration) : base(configuration)
        {
        }

        // GET: api/<NaturalPersonController>
        [HttpGet]
        public PersonCollection Get()
        {
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Get();
            return rt;
        }

        // GET api/<NaturalPersonController>/5
        [HttpGet("{id}")]
        public PersonModel Get(long id)
        {
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Get(id);
            return rt;
        }

        // POST api/<NaturalPersonController>
        [HttpPost]
        public long? Post([FromBody] PersonModel person)
        {
            
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Set(person);
            return rt;
        }

        // PUT api/<NaturalPersonController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] PersonModel person)
        {
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Update(person);
        }

        // DELETE api/<NaturalPersonController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Delete(id);
        }

        // Update collection api/<NaturalPersonController>/5
        [HttpDelete("{id}")]
        public UpdateCollectionResult Update([FromBody] PersonCollection persons)
        {
            var connection = new SqlConnection(MainConnectionString);
            var data = new PersonData(connection);
            var rt = data.Update(persons);
            return rt;
        }
    }
}
