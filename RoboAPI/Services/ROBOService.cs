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
        private Arms LeftArm = new Arms(side: "left", elbow: 3, wrist: 2);
        private Arms RightArm = new Arms(side: "right", elbow: 3, wrist: 2);
        private Head Head = new Head(rotation: 3, inclination: 2);

        // Singleton
        public static ROBOService Instance
        {
            get { return _instance ?? (_instance = new ROBOService()); }
        }

        public int HeadRotation
        {
            get
            {
                return this.Head.Rotation;
            }
            set
            {
                try
                {
                    this.Head.Rotation = HeadRules.RotationRules(value, this.Head);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int HeadInclination
        {
            get
            {
                return this.Head.Inclination;
            }
            set
            {
                try
                {
                    this.Head.Inclination = HeadRules.InclinationRules(value, this.Head);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
            

        public int LeftArmElbow
        {
            get
            {
                return this.LeftArm.Elbow;
            }
            set
            {
                try
                {
                    this.LeftArm.Elbow = ArmRules.ElbowRules(value, this.LeftArm);
                } catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public int LeftArmWrist
        {
            get
            {
                return this.LeftArm.Wrist;
            }
            set
            {
                try
                {
                    this.LeftArm.Wrist = ArmRules.WristRules(value, this.LeftArm);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int RightArmElbow
        {
            get
            {
                return this.RightArm.Elbow;
            }
            set
            {
                try
                {
                    this.LeftArm.Elbow = ArmRules.ElbowRules(value, this.RightArm);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int RightArmWrist
        {
            get
            {
                return this.RightArm.Wrist;
            }
            set
            {
                try
                {
                    this.RightArm.Wrist = ArmRules.WristRules(value, this.RightArm);
                } catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public Dictionary<string, int> DictLeftArm()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Elbow", this.LeftArm.Elbow);
            output.Add("Wrist", this.LeftArm.Wrist);
            return output;
        }

        public Dictionary<string, int> DictRightArm()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Elbow", this.RightArm.Elbow);
            output.Add("Wrist", this.RightArm.Wrist);
            return output;
        }

        public Dictionary<string, int> DictHead()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();
            output.Add("Rotation", this.Head.Rotation);
            output.Add("Inclination", this.Head.Inclination);
            return output;
        } 
    }
}