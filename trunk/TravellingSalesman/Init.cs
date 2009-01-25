using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman
{
    public sealed class Init
    {

        private static Init _init = null;
        public static Init instance {
            get
            {
                if (_init == null) return _init = new Init();
                else return _init;
            }

        }

        /// <summary>
        /// Will generate a list of random cities
        /// </summary>
        /// <param name="numCities"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<City> GenerateProblem(int numCities, int min, int max)
        {
            // AAA
            // AAB
            // AAC
            char[] chars = { 'A', 'B', 'C', 'D', 'E' };
                               //'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S'};
            Random rd = new Random();

            
            List<City> cities = new List<City>();
            for (int i = 0; i < numCities; i++)
            {
                City ct = new City();
                ct.X = rd.Next(min, max);
                ct.Y = rd.Next(min, max);
                //Console.WriteLine(ct.X + ", " + ct.Y);
                GetName(chars, i);
                
                //ct.Name = chars[c];

                cities.Add(ct);
            }
            return cities;
        }

        private void GetName(char[] c, int x)
        {
            //return new char[];
            int sq = Convert.ToInt32(Math.Pow(c.Length,2));
            int g = (Convert.ToInt32(Math.Floor((double)x / sq)))%c.Length;
            int h = (Convert.ToInt32(Math.Floor((double)(x)/c.Length)))%c.Length;
            int i = x%c.Length;


            Console.WriteLine(x + ": " + g + ":" + h + ":" + i + " - " + c[g].ToString() + c[h].ToString() + c[i].ToString());
            
        }
    }
}
