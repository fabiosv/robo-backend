using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RoboAPI.Services;

namespace RoboAPI.Controllers
{
    public enum Robo { Head, LeftArm, RightArm }
    public class ArmsController : ApiController
    {
        private ROBOService robo_service = ROBOService.Instance;

        // GET: api/Arms
        public IEnumerable<Models.Arms> Get()
        {
            return new Models.Arms[] { this.robo_service.LeftArm, this.robo_service.RightArm };
        }

        // PUT: api/Arms/left|right
        public IHttpActionResult Put([FromBody]Models.Arms value)
        {
            try
            {
                if (value.Side == "left")
                {
                    this.robo_service.LeftArm = value;
                    return Ok();
                }

                if (value.Side == "right")
                {
                    this.robo_service.RightArm = value;
                    return Ok();
                }
                return NotFound();
            } catch(Exception e)
            {
                return InternalServerError(e);
            }
            
        }
    }
}
