using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using RoboAPI.Services;

namespace RoboAPI.Controllers
{
    public class RoboController : Controller
    {
        private ROBOService robo_service = ROBOService.Instance;

        public ActionResult Index()
        {
            return View(robo_service);
        }

        // GET: api/Arms
        public Dictionary<string, Dictionary<string, int>> Get()
        {
            Dictionary<string, Dictionary<string, int>> robo = new Dictionary<string, Dictionary<string, int>>();
            robo.Add("Head", robo_service.DictHead());
            robo.Add("LeftArm", robo_service.DictLeftArm());
            robo.Add("RightArm", robo_service.DictRightArm());
            return robo;
        }
    }
}
