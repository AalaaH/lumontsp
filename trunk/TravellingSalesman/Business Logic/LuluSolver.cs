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
            double curDistance = 0;
            for (int i = start; i < cities.Count - 1; i++)
            {
                curDistance = MathHelper.getDistance(cities[i], cities[i + 1]);
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
                    
                    Report(cities, TotalDistance(cities));
                    Timer.instance.Pause();
                }

            }
            Timer.instance.Stop();
            Console.WriteLine("Timer Lu:" + Timer.instance.elapsedTime());
            Report(cities, TotalDistance(cities));
        }


        public void LocalSearch(ref List<City> cities)
        {
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

            int MAX_ITER = 100;
            int lBound = 1, uBound = numCities-1;           
            double curD = 0;

            Random rd = new Random();

            for (int i = 0; i < MAX_ITER; i++)
            {

                int r1 = 0, r2 = 0;
                
                // change temperature
                temp -= delta;

                for (int c = 0; c < cities.Count; c++)
                {
                    // find random c1 and c2 to swap
                    r1 = rd.Next(lBound, uBound-1);
                    r2 = rd.Next(lBound, uBound-1);
                                       
                    while (r1 == r2) r2 = rd.Next(lBound, uBound);

                    // step a
                    if (r2 < r1)
                    {
                        int tempR = r1;
                        r1 = r2;
                        r2 = tempR;
                    }

                    // step b
                    // curD = distance frm prev node for both r1's
                    curD = MathHelper.getDistance(cities[r1 - 1], cities[r1]) + MathHelper.getDistance(cities[r2 + 1], cities[r2]);
                    double newD = MathHelper.getDistance(cities[r1], cities[r2 + 1]) + MathHelper.getDistance(cities[r1-1], cities[r2]);
                    bool accept = false;
                    
                    if (newD < curD) accept = true;// if new solution better we accept
                    if (temp > 0.01)
                    {
                        if (Accept(newD, curD, temp)) accept = true;
                    }

                    if (accept)
                    {
                        int max = Convert.ToInt32(Math.Round((double)((r2 - r1) / 2)));
                        for (int s = 0; s <max; s++)
                        {
                            City tempC = cities[r1 + s];
                            cities[r1 + s] = cities[r2 - s];
                            cities[r2 - s] = tempC;                            
                        }
                    }
                }
                Report(cities, TotalDistance(cities));
            }
            int k = 0;
            while (k < cities.Count - 1)
            {
                Collides(k, cities);
                k++;
            }

        }


        /// <summary>
        /// Find bfs using greedy
        /// </summary>
        /// <param name="cities"></param>
        private void GreedySolve(ref List<City> cities)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void GeneticAlgorithm(ref List<City> cities)
        {


        }

    }
}