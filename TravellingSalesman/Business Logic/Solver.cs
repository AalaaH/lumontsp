using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;


using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    /// <summary>
    /// Tries to solve a network(List) of Cities TSP by using Local Search/ Simulated Annealing
    public sealed partial class Solver
    {

        #region Reporting

        public delegate void ReportSolution(List<City> cities, double dist);
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

        /// <summary>
        /// Used as a dummy reporting method for new solution
        /// </summary>
        /// <param name="cts"></param>
        public void DummyReport(List<City> cts, double dist) { }

        #endregion

        #region Simulated Annealing
        private static Solver _solver = null;

        /// <summary>
        /// Solver is a singleton
        /// </summary>
        public static Solver instance
        {
            get {
                if (_solver == null) return _solver = new Solver();
                else return _solver;
            }

        }





        private double GetDistBeforeAfterCity(List<City> cts, int c)
        {
            double d = 0;
            if (c > 0)
                d += MathHelper.getDistance(cts[c], cts[c - 1]);
            if (c < cts.Count-1)
                d += MathHelper.getDistance(cts[c], cts[c + 1]);
            return d;
        }


        private double GetNewDistance(List<City> cts, int c1, int c2, double curDistance)
        {
            // to min calculations we get new distance by
            // curDistance - (old distances involving c1 an c2) + (new distances involving c1 and c2)
            // this improves performance for networks with large numbers of nodes

            /*if ((c2 - c1) > 2)
            {
                double dis = curDistance - GetDistBeforeAfterCity(cts, c1) - GetDistBeforeAfterCity(cts, c2); // distance - the two cities

                // swap cities
                City temp = cts[c1];
                cts[c1] = cts[c2];
                cts[c2] = temp;

                return dis + GetDistBeforeAfterCity(cts, c1) + GetDistBeforeAfterCity(cts, c2); // total distance after swap
            } 
            return TotalDistance(cts); */
            City temp = cts[c1];
            return TotalDistance(cts);
        }


        #region Utility methods

        /// <summary>
        /// Checks to see if there are any arcs over the arc { cities[c] -> citiec[c+1]}
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        private bool Collides(List<City> cities, int c)
        {
            // 1 define region
            Rectangle region;
            if (cities[c+1].X > cities[c].X) {
                //region = new Rectangle(cities[c].X, cities
            }
            return false;
            
        }
        #endregion


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
            distance += MathHelper.getDistance(cities.Last(), cities[0]);
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
            double sim = Math.Exp(-5 * (distNew - distOld) / temp);
            if (prob < sim) return true;

            return false;
        }




        #endregion

    }
}
