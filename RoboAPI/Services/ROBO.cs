using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoboAPI.Models;

namespace RoboAPI.Services
{
    public class ROBO
    {
        private Arms leftArm = new Arms();
        private Arms rightArm = new Arms();
        private Head head = new Head();

        public Dictionary<string, int> LeftArm
        {
            get
            {
                var output = new Dictionary<string, int>();
                output.Add("Elbow", this.leftArm.Elbow);
                output.Add("Wrist", this.leftArm.Wrist);
                return output;
            }
        }

        public Dictionary<string, int> RightArm
        {
            get
            {
                var output = new Dictionary<string, int>();
                output.Add("Elbow", this.rightArm.Elbow);
                output.Add("Wrist", this.rightArm.Wrist);
                return output;
            }
        }

        public Dictionary<string, int> Head
        {
            get
            {
                var output = new Dictionary<string, int>();
                output.Add("Rotation", this.head.Rotation);
                output.Add("Inclination", this.head.Inclination);
                return output;
            }
        }
    }
}