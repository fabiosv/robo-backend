using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoboAPI.Models;

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
                if (this.isMovementValid(value, this.Head.Rotation) && this.Head.Inclination < 3)
                {
                    this.Head.Rotation = value;
                }
                else
                {
                    if (this.Head.Inclination == 3)
                    {
                        throw new Exception("Cannot rotate head because inclination is 3 - 'Para Baixo'");
                    }
                    else
                    {
                        throw new Exception(string.Format("Cannot jump from {0} to {1}", this.Head.Rotation, value));
                    }
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
                if (this.isMovementValid(value, this.Head.Inclination))
                {
                    this.Head.Inclination = value;
                }
                else
                {
                    throw new Exception(string.Format("Cannot jump from {0} to {1}", this.Head.Inclination, value));
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
                if (this.isMovementValid(value, this.LeftArm.Elbow))
                {
                    this.LeftArm.Elbow = value;
                }
                else
                {
                    throw new Exception(string.Format("Cannot jump from {0} to {1}", this.LeftArm.Elbow, value));
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
                if (this.isMovementValid(value, this.LeftArm.Wrist) && this.LeftArm.Elbow == 4)
                {
                    this.LeftArm.Wrist = value;
                }
                else
                {
                    if (this.LeftArm.Elbow == 4)
                    {
                        throw new Exception(string.Format("Cannot jump from {0} to {1}", this.LeftArm.Wrist, value));
                    }
                    else
                    {
                        throw new Exception("Cannot move wrist unless wrist is 4 - 'Fortemente Contraído'");
                    }
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
                if (this.isMovementValid(value, this.RightArm.Elbow))
                {
                    this.LeftArm.Elbow = value;
                }
                else
                {
                    throw new Exception(string.Format("Cannot jump from {0} to {1}", this.RightArm.Elbow, value));
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
                if (this.isMovementValid(value, this.RightArm.Wrist) && this.RightArm.Elbow == 4)
                {
                    this.RightArm.Wrist = value;
                }
                else
                {
                    if (this.RightArm.Elbow == 4)
                    {
                        throw new Exception(string.Format("Cannot jump from {0} to {1}", this.RightArm.Wrist, value));
                    }
                    else
                    {
                        throw new Exception("Cannot move wrist unless wrist is 4 - 'Fortemente Contraído'");
                    }
                }
            }
        }

        private bool isMovementValid(int var, int attribute)
        {
            System.Console.WriteLine(var - attribute);
            return var - attribute == 1 || attribute - var == 1 || attribute - var == 0;
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