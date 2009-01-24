using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    public sealed class Solver
    {

        #region Simulated Annealing
        private static Solver _solver = null;
        
        private void debug(string msg)
        {
            Console.WriteLine(msg);
        }

        public static Solver instance
        {
            get {
                if (_solver == null) return _solver = new Solver();
                else return _solver;
            }

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

            int i = 0;
            while (temp > 0.01)
            {                                
                Random rd = new Random();
                int r1 = rd.Next(0, numCities);
                int r2 = rd.Next(0, numCities);

                double curD = Distance(cities);
                double newD = this.TrySwapNodesDistance(cities[r1], cities[r2]);

                // change temperature
                temp -= delta;
                debug("");
                debug("iter=" + i.ToString());
                debug("temp=" + temp.ToString());
                debug("curD=" + curD.ToString());
                debug("newD=" + newD.ToString());

                if (curD < newD)
                {
                    if (Accept(newD, curD, temp)) // if we accept we swap nodes
                    {
                        City tempCity = cities[r1];
                        cities[r1] = cities[r2];
                        cities[r2] = tempCity;
                    }
                }
                i++;
            }
        }

        /// <summary>
        /// Randomly swaps two nodes
        /// </summary>
        /// <param name="cts"></param>
        private void SwapNodes(ref List<City> cts)
        {
            Random rd = new Random();
            int r1 = rd.Next(0, cts.Count);
            int r2 = rd.Next(0, cts.Count);

            City temp = cts[r2];
            cts[r2] = cts[r1];
            cts[r1] = temp;            
        }


        private double TrySwapNodesDistance(City c1, City c2)
        {
            return new double();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        private void SwapNodes(ref City c1, ref City c2)
        {
            City temp = c1;
            c1 = c2;
            c2 = temp;
        }


        /// <summary>
        /// Returns the total distance around the network
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        private double Distance(List<City> cities)
        {
            double distance = 0.00;

            for (int i = 0; i < cities.Count-1; i++)
            {
                distance += Math.Sqrt((cities[i].X - cities[i].X) ^ 2 + (cities[i+1].Y - cities[i+1].Y) ^ 2);
                    
                    //MathHelper.getDistance(cities[i], cities[i + 1]);
            }
            return distance;
        }


        /// <summary>
        /// whether to accept the increase in SimAnneal or not
        /// </summary>
        /// <param name="distNew">the new distance</param>
        /// <param name="distOld">the old distance before this iteration</param>
        /// <param name="temp">current temperature</param>
        /// <returns>boolean to accept or not</returns>
        private bool Accept(double distNew, double distOld, double temp)
        {
            double prob = new Random().NextDouble();
            
            if (prob < Math.Exp(-5 * (distNew - distOld) / temp)) return true;

            return false;
        }


        /*If (temperature > 0.01) Then
        Prob = Rnd()
        If (Prob < Exp(-5 * (dist_new - dist_old) / temperature)) Then
           accept = 1
        End If */
        #endregion

        public void LocalSearch(ref List<City> cities)
        {
        }

        public void BasicFeasible(ref List<City> cities)
        {

        }


    }
}
