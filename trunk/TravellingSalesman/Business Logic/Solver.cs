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
        /// Returns y (for y = mx + b)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="m"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double GetLineY(int xVal, double gradient, double yInter)
        {
            return gradient * xVal + yInter;
        }


        /// <summary>
        /// Checks to see if there are any arcs over the arc { cities[c] -> citiec[c+1]}
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        private bool Collides(ref List<City> cities, int c)
        {
            // 1 define region       
            City curCity = cities[c];
            int xPos = Math.Min(cities[c].X, cities[c+1].X);
            int yPos = Math.Min(cities[c].Y, cities[c+1].Y);
            int width = Math.Abs(cities[c].X - cities[c+1].X);
            int height = Math.Abs(cities[c].Y - cities[c+1].Y);

            Rectangle region = new Rectangle(xPos, yPos, width, height);

            List<City> possible = new List<City>();



            // 1. find equation to original arc
            double m = 0;
            if (width > 0) m = -((double)(cities[c + 1].Y - cities[c].Y) / (double)(cities[c + 1].X - cities[c].X));

            double b = cities[c].Y - m * cities[c].X;
            bool hasCollision = false;
            

            // 2 find out if there exists an arc that goes near that region
            for (int i = 0; i<cities.Count-1; i++)
            {
                if(c==i) continue;

                double yLine = GetLineY(cities[c].X, m, b);

                // positive
                if (m > 0)
                {
                    if ((cities[i].Y < yLine) && (cities[i + 1].Y > yLine))
                    {
                        cities[i].Collides = true;
                        hasCollision = true;
                    }

                    if((cities[i].X < curCity.X) && (cities[i+1].X < curCity.X)) {
                        cities[i].Collides = false;
                        hasCollision = false;
                    }

                    if((cities[i].X > curCity.X) && (cities[i+1].X > curCity.X)) {
                        cities[i].Collides = false;
                        hasCollision = false;
                    }
                }
                // negative slope
                else if( m < 0)
                {
                    if ((cities[i].Y > yLine) && cities[i + 1].Y < yLine) cities[i].Collides = true;
                }
               
                else
                {
                    cities[i].Collides = false;
                }
                Report(cities, 0);
                
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
