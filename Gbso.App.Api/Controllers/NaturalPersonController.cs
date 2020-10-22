using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Gbso.App.Data.General;
using Gbso.App.Model.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gbso.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalPersonController :AppControllerBase
    {
        public NaturalPersonController(IConfiguration configuration) : base(configuration)
        {
        }
        // GET: api/<PersonController>
        [HttpGet]
        public NaturalPersonCollection Get()
        {
            using (var data = new NaturalPersonData(MainConnectionString))
            {
                var rt = data.Get();
                return rt;
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{key}")]
        public NaturalPersonModel Get(long key)
        {
            using (var data = new NaturalPersonData(MainConnectionString))
            {
                var rt = data.Get(key);
                return rt;
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public long? Post([FromBody] NaturalPersonModel naturalPerson)
        {
            using (var naturalPersonData = new NaturalPersonData(MainConnectionString))
            {
                var key = naturalPersonData.Set(naturalPerson);
                return key;
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{key}")]
        public void Put(long? key, [FromBody] NaturalPersonModel naturalPerson)
        {
            var connection = new SqlConnection(MainConnectionString);
            using (var naturalPersonData = new NaturalPersonData(MainConnectionString))
            {
                naturalPersonData.Update(naturalPerson);
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{key}")]
        public void Delete(long Key)
        {
            using (var naturalPersonData = new NaturalPersonData(MainConnectionString))
            {
                naturalPersonData.Delete(Key);
            }
        }
    }
}
