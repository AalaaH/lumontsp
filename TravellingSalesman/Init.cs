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
            char[] chars = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'};
            Random rd = new Random();

            int c = 0;
            List<City> cities = new List<City>();
            for (int i = 0; i < numCities; i++)
            {
                City ct = new City();
                ct.X = rd.Next(min, max);
                ct.Y = rd.Next(min, max);
                
                //ct.Name = chars[c];

                cities.Add(ct);
            }
            return cities;
        }

        private void GetName(char[] c, int x)
        {
            //return new char[];
        }
    }
}
