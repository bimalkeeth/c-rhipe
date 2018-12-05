using System;
using rhipecode.common.BusinessContract;
using rhipecode.common.Interfaces.Engine;

namespace rhipecode.businessrules.Helper
{
   
    // This is where the magic happens :)
    public class TriangleHelper:ITriangleHelper
    {
        public bool IsTrianglePossible(double sideA, double sideB, double sideC)
        {
            // all sides must be positive
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                // sum of two sides must the greater than the other side
                bool check1 = sideA + sideB > sideC;
                bool check2 = sideA + sideC > sideB;
                bool check3 = sideC + sideB > sideA;
                return (check1 && check2 && check3);
            }
            return false;
        }

       
    }
}