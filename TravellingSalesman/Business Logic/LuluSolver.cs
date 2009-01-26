using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    public sealed partial class Solver
    {
       


        public void BasicFeasible(ref List<City> cities)
        {
            Timer.instance.Start();
            for (int i = 0; i < cities.Count - 1; i++)
            {
                double curDistance = MathHelper.getDistance(cities[i], cities[i + 1]);
                int toSwap = -1;

                for (int x = i + 2; x < cities.Count; x++)
                {                    
                    double newDistance = MathHelper.getDistance(cities[i], cities[x]);
                    if (newDistance < curDistance)
                    {
                        curDistance = newDistance;
                        toSwap = x;
                    }
                }
                if (toSwap > -1)
                {
                    City temp = cities[i+1];
                    cities[i+1] = cities[toSwap];
                    cities[toSwap] = temp;
                    Timer.instance.Pause();
                    Report(cities);
                    Timer.instance.Pause();
                }

            }
            Timer.instance.Stop();
            Console.WriteLine("Timer Lu:" + Timer.instance.elapsedTime()); 
            Report(cities);
        }
    }
}