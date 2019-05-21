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
        public Dictionary<string, Dictionary<string, int>> Get()
        {
            Dictionary<string, Dictionary<string, int>> robo = new Dictionary<string, Dictionary<string, int>>();
            robo.Add("Head", robo_service.DictHead());
            return robo;
        }

        // PUT: api/Head/
        public IHttpActionResult Put([FromBody]Models.Head value)
        {
            try
            {
                this.robo_service.HeadRotation = value.Rotation;
                this.robo_service.HeadInclination = value.Inclination;
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
