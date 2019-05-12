using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoboAPI.Controllers
{
    public class ArmsController : ApiController
    {
        // GET: api/Arms
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Arms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Arms
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Arms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Arms/5
        public void Delete(int id)
        {
        }
    }
}
