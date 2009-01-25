﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    public sealed class Solver
    {

        #region Reporting

        public delegate void ReportSolution(List<City> cities);
        private ReportSolution _reportSolution = null;

        public ReportSolution Report
        {
            get {
                if (_reportSolution == null)
                {
                    _reportSolution = this.DummyReport;                   
                }
                return _reportSolution;
            }
            set { _reportSolution = value; }
        }

        public void DummyReport(List<City> cts)
        {
            Console.WriteLine("dummy report");
        }

        #endregion

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
            double curD = TotalDistance(cities);

            int numCities = cities.Count;

            int i = 0;
            while (temp > 0.01)
            {                                
                Random rd = new Random();
                int r1 = rd.Next(1, numCities-1);
                int r2 = rd.Next(1, numCities-1);
                
                double newD = GetNewDistance(cities, r1, r2, curD);

                // change temperature
                temp -= delta;
                debug("");
                debug("iter=" + i.ToString());
                debug("temp=" + temp.ToString());
                debug("curD=" + curD.ToString());
                debug("newD=" + newD.ToString());


                
                if (newD < curD) // if new solution better we accept
                {
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
                        Console.WriteLine("accept");
                        City tempCity = cities[r1];
                        cities[r1] = cities[r2];
                        cities[r2] = tempCity;
                        curD = newD;
                        Report.Invoke(cities);

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
            int r1 = rd.Next(1, cts.Count);
            int r2 = rd.Next(1, cts.Count);

            City temp = cts[r2];
            cts[r2] = cts[r1];
            cts[r1] = temp;            
        }


        private double GetDistBeforeAfterCity(List<City> cts, int c)
        {
            double d = 0;
            if (c > 0)
                d += MathHelper.getDistance(cts[c], cts[c - 1]);
            if (c < cts.Count)
                d += MathHelper.getDistance(cts[c], cts[c + 1]);
            return d;
        }


        private double GetNewDistance(List<City> cts, int c1, int c2, double curDistance)
        {
            // to min calculations we get new distance by
            // curDistance - (old distances involving c1 an c2) + (new distances involving c1 and c2)
            // this improves performance for networks with large numbers of nodes

            if ((c2 - c1) > 2)
            {
                double dis = curDistance - GetDistBeforeAfterCity(cts, c1) - GetDistBeforeAfterCity(cts, c2); // distance - the two cities

                // swap cities
                City temp = cts[c1];
                cts[c1] = cts[c2];
                cts[c2] = temp;

                return dis + GetDistBeforeAfterCity(cts, c1) + GetDistBeforeAfterCity(cts, c2); // total distance after swap
            } 
            return TotalDistance(cts);
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
        public double TotalDistance(List<City> cities)
        {
            double distance = 0.00;

            for (int i = 0; i < cities.Count-1; i++)
            {
                distance+= MathHelper.getDistance(cities[i], cities[i + 1]);
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
            double curDistance = 0;
            int toSwap = -1;

            for (int i = 0; i < cities.Count-1; i++)
            {
                curDistance = MathHelper.getDistance(cities[i], cities[i + 1]);
                toSwap = -1;

                for (int x = i+2; x < cities.Count; x++)
                {
                    double newDistance = MathHelper.getDistance(cities[i], cities[x]);
                    debug(cities[i].Name+":"+cities[x].Name+" - n=" + newDistance + ": o=" + curDistance);

                    if (newDistance < curDistance)
                    {
                        Report.Invoke(cities);
                        curDistance = newDistance;
                        toSwap = x;                       
                    }

                    if (toSwap > 0)
                    {
                        City temp = cities[i];
                        cities[i] = cities[toSwap];
                        cities[toSwap] = temp; 
                    }

                    // if we want to report current list;
                    // Report.Invoke(cities);
                }
            }
        }

        

    }
}