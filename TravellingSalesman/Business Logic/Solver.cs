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
                Debug.WriteLine("");
                Debug.WriteLine("iter=" + i.ToString());
                Debug.WriteLine("temp=" + temp.ToString());
                Debug.WriteLine("curD=" + curD.ToString());
                Debug.WriteLine("newD=" + newD.ToString());


                
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
        public void SwapNodes(ref List<City> cts)
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


        
        private void swapCity(ref List<City> cities,int index1, int index2)
        {
            City temp = cities[index1];
            cities[index1] = cities[index2];
            cities[index2] = temp;
        }

        
        
        private int partition(ref List<City> cities, int left, int right)
        {
            //findMedianOfMedians(ref cities, left, right); not needed for our moving target
            int pivotIndex = left, index = left, i;
            double pivotValue = cities[pivotIndex].Distance;
            swapCity(ref cities, left, right);
            for (i = left; i < right; i++)
            {
                if (cities[i].Distance < pivotValue)
                {
                    swapCity(ref cities, i, index);
                    index++;
                }
            }
            swapCity(ref cities, right, index);
            return index;
        }

        
        private void quickSort(ref List<City> cities, int left, int right)
        {
            
            int pivotIndex = 0;
            

            if (left >= right)
                return;
        
            pivotIndex = partition(ref cities, left, right);
            //CalculateDistances(ref cities, left);
            quickSort(ref cities, left, pivotIndex - 1);
            //quickSort(ref cities, pivotNewIndex + 1, right); not need only conserned with shorter values
          
        }

        private void CalculateDistances(ref List<City> cities, int startCity)
        {
            for (int i = startCity+1; i < cities.Count; i++)
            {
                cities[i].Distance = MathHelper.getDistance(cities[startCity], cities[i]);
                
            }
        }
        


        public void SimonsBasicFeasible(ref List<City> cities)
        {
            Timer.instance.Start();
            for (int i = 1; i < cities.Count; i++)
            {
                CalculateDistances(ref cities, i - 1);
                quickSort(ref cities, i, cities.Count - 1);
                Timer.instance.Pause();
                Report(cities);
                Timer.instance.Pause();
            }

            
            Timer.instance.Stop();
            Console.WriteLine("Timer Simon: " + Timer.instance.elapsedTime()); 
            Report(cities);
        }
  /*
        private double findMedianOfMedians(ref List<City> cities, int left, int right)
        {
            if (left == right)
                return cities[left].Distance;

            int i, shift = 1;
            while (shift <= (right - left))
            {
                for (i = left; i <= right; i += shift * 5)
                {
                    int endIndex = (i + shift * 5 - 1 < right) ? i + shift * 5 - 1 : right;
                    int medianIndex = findMedianIndex(ref cities, i, endIndex, shift);


                    swapCity(ref cities, i, medianIndex);
                }
                shift *= 5;
            }

            return cities[left].Distance;
        }

        int findMedianIndex(ref List<City> cities, int left, int right, int shift)
        {
            int i, groups = (right - left) / shift + 1, k = left + groups / 2 * shift;
            for (i = left; i <= k; i += shift)
            {
                int minIndex = i, j;
                double minValue = cities[minIndex].Distance;
                for (j = i; j <= right; j += shift)
                    if (cities[j].Distance < minValue)
                    {
                        minIndex = j;
                        minValue = cities[minIndex].Distance;
                    }
                swapCity(ref cities, i, minIndex);
            }

            return k;
        }
*/
    }
}
