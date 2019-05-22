using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RoboAPI.Services;

namespace RoboAPI.Controllers
{
    public class HeadController : ApiController
    {
        private ROBOService robo_service = ROBOService.Instance;

        // GET: api/Head
        public Models.Head Get()
        {
            return robo_service.Head;
        }

        // PUT: api/Head/
        public IHttpActionResult Put([FromBody]Models.Head value)
        {
            try
            {
                this.robo_service.Head = value;
                return Ok();
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Error: " + e.ToString());
                return InternalServerError(e);
            }
        }
    }
}
