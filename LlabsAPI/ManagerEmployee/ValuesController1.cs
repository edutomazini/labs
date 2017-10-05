using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManagerEmployee
{
    public class ValuesController1 : ApiController
    {
        [Route("api/values")]
        [HttpGet]
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/values/{id}")]
        [HttpGet]
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }


        [Route("api/values")]
        [HttpPost]
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        [Route("api/values/{id}")]
        [HttpDelete]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}