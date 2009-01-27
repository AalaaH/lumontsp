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
       
        public void BasicFeasible(ref List<City> cities, int start)
        {
            Timer.instance.Start();
            for (int i = start; i < cities.Count - 1; i++)
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



        /// <summary>
        /// Solves using Simulated Annealing
        /// </summary>
        /// <param name="cities">list of cities</param>
        /// <param name="temp">temperature</param>
        /// <param name="delta"></param>
        public void SimAnneal(ref List<City> cities, double temp, double delta)
        {
            int numCities = cities.Count;

            int MAX_ITER = 200;
            int lBound = 3, uBound = numCities + 1;

            double curD = TotalDistance(cities);

            Random rd = new Random();

            for (int i = 0; i < MAX_ITER; i++)
            {

                int r1 = 0, r2 = 0;
                
                // change temperature
                temp -= delta;

                for (int c = 0; c < cities.Count; c++)
                {
                    // find random c1 and c2 to swap
                    r1 = rd.Next(lBound, uBound);
                    while (r2 != 21) r2 = rd.Next(lBound, uBound);

                    // step a
                    if (r2 < r1)
                    {
                        int tempR = r1;
                        r1 = r2;
                        r2 = tempR;
                    }

                    // step b
                    double newD = GetNewDistance(cities, r1, r2, curD);
                    bool accept = false;
                    
                    if (newD < curD) // if new solution better we accept
                    {
                        accept = true;
                        Console.WriteLine("accept");
                        City tempCity = cities[r1];
                        cities[r1] = cities[r2];
                        cities[r2] = tempCity;
                        curD = newD;
                        Report.Invoke(cities);
                    }

                    else
                    {
                        if (Accept(newD, curD, temp)) // calc prob to accept increase
                        {
                            accept = true;
                            Console.WriteLine("accept");
                            City tempCity = cities[r1];
                            cities[r1] = cities[r2];
                            cities[r2] = tempCity;
                            curD = newD;
                            Report.Invoke(cities);
                        }
                    }
                }


            }
        }


    }
}