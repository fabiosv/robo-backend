using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoboAPI.Services.Rules
{
    public class CommonRules
    {
        public static bool HasValueChanged(int value, int attribute)
        {
            return value != attribute;
        }

        public static bool IsMovementValid(int var, int attribute)
        {
            return var - attribute == 1 || attribute - var == 1 || attribute - var == 0;
        }
    }
}