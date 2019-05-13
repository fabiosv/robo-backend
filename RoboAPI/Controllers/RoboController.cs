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
    public class RoboController : ApiController
    {
        private ROBO robo_service = new ROBO();
        // GET: api/Arms
        public Dictionary<string,Dictionary<string,int>> Get()
        {
            Dictionary<string, Dictionary<string, int>> robo = new Dictionary<string, Dictionary<string, int>>();
            robo.Add("Head", robo_service.Head);
            robo.Add("LeftArm", robo_service.LeftArm);
            robo.Add("RightArm", robo_service.RightArm);
            return robo;
        }

        // GET: api/Arms/5
        public Dictionary<string, Dictionary<string, int>> Get(string bodyPart)
        {
            Dictionary<string, Dictionary<string, int>> robo = new Dictionary<string, Dictionary<string, int>>();
            System.Console.WriteLine(bodyPart);
            switch (bodyPart)
            {
                case "Head":
                    robo.Add("Head", robo_service.Head);
                    break;
                case "LeftArm":
                    robo.Add("LeftArm", robo_service.LeftArm);
                    break;
                case "RightArm":
                    robo.Add("RightArm", robo_service.RightArm);
                    break;
                default:
                    break;
            }
            return robo;
        }

        // PUT: api/Arms/5
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
