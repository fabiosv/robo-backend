using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoboAPI.Models
{
    public class Head
    {
        private int rotation = 3;
        private int inclination = 2;
        public Head()
        {

        }
 
        public int getRotation()
        {
            return this.rotation;
        }

        public void setRotation(int rotation)
        {
            if(this.isMovementValid(rotation, this.rotation) || this.inclination == 3)
            {
                // TODO: raise an error
            } else
            {
                this.rotation = rotation;
            }
        }

        public int getInclination()
        {
            return this.inclination;
        }

        public void setInclination(int inclination)
        {
            if (this.isMovementValid(inclination, this.inclination))
            {
                // TODO: raise an error
            } else
            {
                this.inclination = inclination;
            }
        }

        private bool isMovementValid(int var, int attribute)
        {
            return var - attribute > 1 || attribute - var > 1;
        }
    }
}