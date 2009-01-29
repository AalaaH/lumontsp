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
        private static Random rd = new Random();


        public static double getDistance(City c1, City c2)
        {
            if (c2 == null) return 0;
            double d1 = Math.Pow((double)c1.X - (double)c2.X, 2);
            double d2 = Math.Pow((double)c1.Y - (double)c2.Y, 2);

            return Math.Sqrt(d1 + d2);
        }


        public static double getDistance(Arc arc)
        {
            return getDistance(arc.FrmCity, arc.ToCity);
        }

        public static double getGrad(City c1, City c2)
        {
            if (c2 == null) return 0;

            if (c1.X != c2.X)
                return (c2.Y - c1.Y) / (c2.X - c1.X);

            return 0;
        }

        public static double getGrad(Arc arc)
        {
            return getGrad(arc.FrmCity, arc.ToCity);
        }
        
        public static double getRandom()
        {                                    
            return rd.NextDouble();         
        }







    }
}
