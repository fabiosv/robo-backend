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
        private int elbow = 3;
        private int wrist = 2;
        private Dictionary<int, string> elbowStates = new Dictionary<int, string>();
        private Dictionary<int, string> wristStates = new Dictionary<int, string>();

        public Arms()
        {
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

        public int Elbow
        {
            get
            {
                return this.elbow;
            }
            set
            {
                if (this.isMovementValid(value, this.elbow))
                {
                    this.elbow = value;
                }
                else
                {
                    throw new Exception(string.Format("Cannot jump from {0} to {1}", this.elbow, value));
                }
            }
        }

        public int Wrist
        {
            get
            {
                return this.wrist;
            }
            set
            {
                if (this.isMovementValid(value, this.wrist) && this.elbow == 4)
                {
                    this.wrist = value;
                }
                else
                {
                    if(this.elbow == 4)
                    {
                        throw new Exception(string.Format("Cannot jump from {0} to {1}", this.wrist, value));
                    } else
                    {
                        throw new Exception("Cannot move wrist unless wrist is 4 - 'Fortemente Contraído'");
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