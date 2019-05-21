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

        public Head()
        {
            string states_path = Path.GetFullPath(
                Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "./Models/RoboStates.xml")
            );
            foreach (XElement level1Element in XElement.Load(@states_path).Elements("head").Elements("rotation").Elements("states").Elements("state"))
            {
                rotationStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }

            foreach (XElement level1Element in XElement.Load(@states_path).Elements("head").Elements("inclination").Elements("states").Elements("state"))
            {
                inclinationStates.Add(Int32.Parse(level1Element.Attribute("position").Value), level1Element.Value);
            }
        }

        public Head(int rotation, int inclination)
        {
            this.Inclination = inclination;
            this.Rotation = rotation;
        }

        private bool isMovementValid(int var, int attribute)
        {
            System.Console.WriteLine(var - attribute);
            return var - attribute == 1 || attribute - var == 1 || attribute - var == 0;
        }
    }
}