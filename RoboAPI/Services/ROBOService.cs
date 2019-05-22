using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoboAPI.Models;
using RoboAPI.Services.Rules;

namespace RoboAPI.Services
{
    public class ROBOService
    {
        static ROBOService _instance;
        private Arms leftArm = new Arms(side: "left", elbow: 1, wrist: 3);
        private Arms rightArm = new Arms(side: "right", elbow: 1, wrist: 3);
        private Head head = new Head(rotation: 3, inclination: 2);

        // Singleton
        public static ROBOService Instance
        {
            get { return _instance ?? (_instance = new ROBOService()); }
        }

        public Head Head
        {
            get
            {
                return this.head;
            }
            set
            {
                try
                {
                    this.head.Inclination = HeadRules.InclinationRules(value.Inclination, this.head);
                    this.head.Rotation = HeadRules.RotationRules(value.Rotation, this.head);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Arms LeftArm
        {
            get
            {
                return this.leftArm;
            }
            set
            {
                try
                {
                    this.leftArm.Elbow = ArmRules.ElbowRules(value.Elbow, this.leftArm);
                    this.leftArm.Wrist = ArmRules.WristRules(value.Wrist, this.leftArm);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Arms RightArm
        {
            get
            {
                return this.rightArm;
            }
            set
            {
                try
                {
                    this.rightArm.Elbow = ArmRules.ElbowRules(value.Elbow, this.rightArm);
                    this.rightArm.Wrist = ArmRules.WristRules(value.Wrist, this.rightArm);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Dictionary<string, int> DictLeftArm()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Elbow", this.leftArm.Elbow);
            output.Add("Wrist", this.leftArm.Wrist);
            return output;
        }

        public Dictionary<string, int> DictRightArm()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Elbow", this.rightArm.Elbow);
            output.Add("Wrist", this.rightArm.Wrist);
            return output;
        }

        public Dictionary<string, int> DictHead()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Rotation", this.head.Rotation);
            output.Add("Inclination", this.head.Inclination);
            return output;
        } 
    }
}