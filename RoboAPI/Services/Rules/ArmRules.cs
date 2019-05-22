using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoboAPI.Services.Rules
{
    public class ArmRules : CommonRules
    {
        // Facet Methods, all validations for Arms will be tested here
        public static int ElbowRules(int value, Models.Arms arm)
        {
            if (IsMovementValid(value, arm.Elbow) && IsValueUnderBorders(value, arm.MaxElbowValue()) 
                || !HasValueChanged(value, arm.Elbow))
            {
                return value;
            }
            else
            {
                if (IsValueUnderBorders(value, arm.MaxElbowValue()))
                {
                    throw new Exception(string.Format("Elbow Cannot jump from {0} to {1}", arm.Elbow, value));
                }
                else
                {
                    throw new Exception(string.Format("Elbow Value out of range! Min: {0} Max: {1}", 1, arm.MaxElbowValue()));
                }
                
            }
        }

        public static int WristRules(int value, Models.Arms arm)
        {
            if (IsMovementValid(value, arm.Wrist) && IsElbowContracted(arm.Elbow)
                && IsValueUnderBorders(value, arm.MaxWristValue()) || !HasValueChanged(value, arm.Wrist))
            {
                return value;
            }
            else
            {
                if(!IsValueUnderBorders(value, arm.MaxWristValue()))
                {
                    throw new Exception(string.Format("Wrist Value out of range! Min: {0} Max: {1}", 1, arm.MaxWristValue()));
                }
                if (IsElbowContracted(arm.Elbow))
                {
                    throw new Exception(string.Format("Wrist Cannot jump from {0} to {1}", arm.Wrist, value));
                }
                else
                {
                    throw new Exception("Cannot move wrist unless elbow is 4 - 'Fortemente Contraído'");
                }
            }
        }

        private static bool IsElbowContracted(int elbow)
        {
            return elbow == 4;
        }
    }
}