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
        public Dictionary<string,Dictionary<string,int>> Get()
        {
            Dictionary<string, Dictionary<string, int>> robo = new Dictionary<string, Dictionary<string, int>>();
            robo.Add("LeftArm", robo_service.DictLeftArm());
            robo.Add("RightArm", robo_service.DictRightArm());
            return robo;
        }

        // PUT: api/Arms/left|right
        public IHttpActionResult Put([FromBody]Models.Arms value)
        {
            try
            {
                if (value.Side == "left")
                {
                    this.robo_service.LeftArmElbow = value.Elbow;
                    this.robo_service.LeftArmWrist = value.Wrist;
                    return Ok();
                }

                if (value.Side == "right")
                {
                    this.robo_service.RightArmElbow = value.Elbow;
                    this.robo_service.RightArmWrist = value.Wrist;
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
