using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;
using TravellingSalesman.Business_Logic;

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

        private static char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S' };

        /// <summary>
        /// Will generate a list of random cities
        /// </summary>
        /// <param name="numCities"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<City> GenerateProblem(int numCities, int maxX, int maxY)
        {
            
            Random rd = new Random();
            
            List<City> cities = new List<City>();
            for (int i = 0; i < numCities; i++)
            {
                City ct = new City();
                ct.X = rd.Next(10, maxX);
                ct.Y = rd.Next(10, maxY);
                ct.Name = GetName(i);

                if (i > 0)
                {
                    ct.Distance = MathHelper.getDistance(ct, cities[i - 1]);
                }
                cities.Add(ct);
            }
            return cities;
        }

        private string GetName(int x)
        {
            //return new name;
            int sq = Convert.ToInt32(Math.Pow(chars.Length,2));
            int g = (Convert.ToInt32(Math.Floor((double)x / sq))) % chars.Length;
            int h = (Convert.ToInt32(Math.Floor((double)(x) / chars.Length))) % chars.Length;
            int i = x % chars.Length;

            return chars[g].ToString() + chars[h].ToString() + chars[i].ToString();

        }
    }
}
