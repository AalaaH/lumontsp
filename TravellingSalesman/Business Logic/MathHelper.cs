using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    /// <summary>
    /// holds generic math functions
    /// </summary>
    public class MathHelper
    {
        public static double getDistance(City c1, City c2)
        {
            double d = Math.Sqrt(Math.Pow((c1.X - c2.X),2) + Math.Pow((c1.Y - c2.Y),2));
            return d;
        }

        static Random rd = new Random();

        /// <summary>
        /// returns a random double between 0 and 1
        /// </summary>
        /// <returns></returns>
        public static double getRandom()
        {                                    
            return rd.NextDouble();         
        }



    }
}
