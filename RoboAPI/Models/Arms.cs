using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;

namespace RoboAPI.Models
{
    public class Arms
    {
        public int Elbow { get; set; }
        public int Wrist { get; set; }
        public string Side { get; set; }
        private Dictionary<int, string> elbowStates = new Dictionary<int, string>();
        private Dictionary<int, string> wristStates = new Dictionary<int, string>();

        public Arms(string side, int elbow, int wrist)
        {
            this.Side = side;
            this.Elbow = elbow;
            this.Wrist = wrist;
            string states_path = Path.GetFullPath(
                Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "./Models/RoboStates.xml")
            );
            foreach (XElement level1Element in XElement.Load(@states_path).Elements("arms").Elements("elbow").Elements("states").Elements("state"))
            {
                elbowStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }

            foreach (XElement level1Element in XElement.Load(@states_path).Elements("arms").Elements("wrist").Elements("states").Elements("state"))
            {
                wristStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }
        }
    }
}