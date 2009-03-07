using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;
using System.Drawing;

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

            double retVal = 0;
            if (c1.X != c2.X)
                retVal = (double)(-(c2.Y) + c1.Y) / (double)(c2.X - c1.X);

            return retVal;
        }

        public static double getGrad(Arc arc)
        {
            return getGrad(arc.FrmCity, arc.ToCity);
        }


        public static double getYIntercept(Arc arc)
        {
            return -(arc.FrmCity.Y) - (arc.Grad * arc.FrmCity.X);
        }

        public static Point getIntercept(Arc arc1, Arc arc2)
        {
            //Point p = new Point();
            double x = 0;
            double y = 0;

            x = arc1.Grad - arc2.Grad;
            y = arc2.Yintercept - arc1.Yintercept;

            double xPoint = 0;
            if (x != 0) xPoint = y / x;

            int xP = Convert.ToInt32((double)xPoint);


            int yPoint = Convert.ToInt32(Math.Round((xP * arc1.Grad) + arc1.Yintercept));
            
            return new Point(xP, Math.Abs(yPoint));
            
        }

        public static double getRandom()
        {                                    
            return rd.NextDouble();         
        }







    }
}
