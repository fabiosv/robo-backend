using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoboAPI.Services.Rules
{
    public class HeadRules : CommonRules
    {
        // Facet Methods, all validations for Head will be tested here
        public static int RotationRules(int value, Models.Head head)
        {
            if (IsMovementValid(value, head.Rotation) && !IsHeadInclinateToDown(head.Inclination) && 
                IsValueUnderBorders(value, head.MaxRotationValue()) || !HasValueChanged(value, head.Rotation))
            {
                return value;
            }
            else
            {
                if (!IsValueUnderBorders(value, head.MaxRotationValue()))
                {
                    throw new Exception(string.Format("Rotation Value out of range! Min: {0} Max: {1}", 1, head.MaxRotationValue()));
                }
                if (IsHeadInclinateToDown(head.Inclination))
                {
                    throw new Exception("Cannot rotate head because inclination is 3 - 'Para Baixo'");
                }
                else
                {
                    throw new Exception(string.Format("Rotation Cannot jump from {0} to {1}", head.Rotation, value));
                }
            }
        }

        public static int InclinationRules(int value, Models.Head head)
        {
            if (IsMovementValid(value, head.Inclination) && IsValueUnderBorders(value, head.MaxInclinationValue()) 
                || !HasValueChanged(value, head.Inclination))
            {
                return value;
            }
            else
            {
                if(IsValueUnderBorders(value, head.MaxInclinationValue()))
                {
                    throw new Exception(string.Format("Inclination Cannot jump from {0} to {1}", head.Inclination, value));
                } else
                {
                    throw new Exception(string.Format("Inclination Value out of range! Min: {0} Max: {1}", 1, head.MaxInclinationValue()));
                }
                    
            }
        }

        private static bool IsHeadInclinateToDown(int inclination)
        {
            return inclination == 3;
        }
    }
}