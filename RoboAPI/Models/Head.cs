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
        private int rotation = 3;
        private int inclination = 2;
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

        public int Inclination
        {
            get
            {
                return this.inclination;
            }
            set
            {
                if (this.isMovementValid(value, this.inclination))
                {
                    this.inclination = value;
                } else
                {
                    throw new Exception(string.Format("Cannot jump from {0} to {1}", this.inclination, value));
                }
            }
        }

        public int Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                if (this.isMovementValid(value, this.rotation) && this.inclination < 3)
                {
                    this.rotation = value;
                }
                else
                {
                    if(this.inclination == 3)
                    {
                        throw new Exception("Cannot rotate head because inclination is 3 - 'Para Baixo'");
                    } else {
                        throw new Exception(string.Format("Cannot jump from {0} to {1}", this.rotation, value));
                    }
                }
            }
        }

        private bool isMovementValid(int var, int attribute)
        {
            return var - attribute > 1 || attribute - var > 1;
        }
    }
}