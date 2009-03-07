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
        public delegate void ReportSolutionArcs(List<Arc> arcs, double dist);
        
        private ReportSolution _reportSolution = null;
        private ReportSolutionArcs _reportSolutionArc = null;

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

        public ReportSolutionArcs ReportArcs
        {
            get
            {
                if (_reportSolutionArc == null)
                {
                    _reportSolutionArc = this.DummyReport;
                }
                return _reportSolutionArc;
            }
            set { _reportSolutionArc = value; }
        }

        /// <summary>
        /// Used as a dummy reporting method for new solution
        /// </summary>
        /// <param name="cts"></param>
        public void DummyReport(List<City> cts, double dist) { }
        public void DummyReport(List<Arc> cts, double dist) { }

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
        /// Checks that two points are within the range
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <returns></returns>
        private bool within(int val1, int val2, int min, int max)
        {
            if ((val1 > min && val1 < max) && (val2 < min && val2 > max)) return true;
            return false;

        }



        public bool Collides(int cur, List<Arc> arcs)
        {
            arcs[cur].Collides = false;
            arcs[cur].FrmCity.Collides = false;

            for (int x = 0; x < arcs.Count; x++)
            {
                if (cur == x) { x++; continue; }
                if (arcs[x].inRegionX(0, arcs[cur].MinX)) continue; // reg x1
                if (arcs[x].inRegionX(arcs[cur].MaxX, Int32.MaxValue)) continue; // reg x3
                if (arcs[x].inRegionY(0, arcs[cur].MinY)) continue; // reg y1
                if (arcs[x].inRegionY(arcs[cur].MaxY, Int32.MaxValue)) continue;  // reg y3

                Point pt = MathHelper.getIntercept(arcs[cur], arcs[x]);

                if (pt.X <= arcs[cur].MinX || pt.X >= arcs[cur].MaxX) continue;

                arcs[cur].Collides = true;
                arcs[cur].FrmCity.Collides = true;

                return true;
                
            }
            
            return arcs[cur].Collides;
        }
        




        public bool Collides(int cur, List<City> cities)
        {
            List<Arc> arcs = new List<Arc>();
            for (int i = 0; i < cities.Count - 1; i++)
            {
                arcs.Add(new Arc(cities[i], cities[i + 1]));
            }

            
            arcs[cur].Collides = false;
            arcs[cur].FrmCity.Collides = false;

            for (int x = 0; x < arcs.Count; x++)
            {
                if (cur == x) { x++; continue; }
                if (arcs[x].inRegionX(0, arcs[cur].MinX)) continue; // reg x1
                if (arcs[x].inRegionX(arcs[cur].MaxX, Int32.MaxValue)) continue; // reg x3
                if (arcs[x].inRegionY(0, arcs[cur].MinY)) continue; // reg y1
                if (arcs[x].inRegionY(arcs[cur].MaxY, Int32.MaxValue)) continue;  // reg y3

                Point pt = MathHelper.getIntercept(arcs[cur], arcs[x]);

                if (pt.X <= arcs[cur].MinX || pt.X >= arcs[cur].MaxX) continue;
                
                arcs[cur].Collides = true;
                arcs[cur].FrmCity.Collides = true;
                return true;
                
            }
            
            return arcs[cur].Collides;
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
