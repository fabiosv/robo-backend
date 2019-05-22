using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;

namespace RoboAPI.Models
{
    public class Head
    {
        public int Rotation { get; set; }
        public int Inclination { get; set; }
        private Dictionary<int, string> rotationStates = new Dictionary<int, string>();
        private Dictionary<int, string> inclinationStates = new Dictionary<int, string>();

        public Head(int rotation, int inclination)
        {
            this.Inclination = inclination;
            this.Rotation = rotation;
            this.LoadStates();
        }

        private void LoadStates()
        {
            string states_path = Path.GetFullPath(
                Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "./Models/RoboStates.xml")
            );
            foreach (XElement level1Element in XElement.Load(states_path).Elements("head").Elements("rotation").Elements("states").Elements("state"))
            {
                this.rotationStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }

            foreach (XElement level1Element in XElement.Load(states_path).Elements("head").Elements("inclination").Elements("states").Elements("state"))
            {
                this.inclinationStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }
        }

        public string RotationToString()
        {
            return this.rotationStates[this.Rotation];
        }
        public string InclinationToString()
        {
            return this.inclinationStates[this.Inclination];
        }

        public int MaxRotationValue()
        {
            return this.rotationStates.Count;
        }
        public int MaxInclinationValue()
        {
            return this.inclinationStates.Count;
        }
    }
}