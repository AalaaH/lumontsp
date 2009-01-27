using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    public sealed partial class Solver
    {
        public void SimonsNotSoBasic(ref List<City> cities)
        {
            //int longestTravelStartingCity = FindLongestDistance(ref cities);
            SimonsBasicFeasible(ref cities);
            double distance = TotalDistance(cities);
            double curDistance = TotalDistance(cities);
            
            Timer.instance.Start();
            int counter=1;
            while (counter<10000)
            {
                double averageDistance = TotalDistance(cities) / cities.Count;
                while (curDistance >= distance)
                {


                    for (int i = 1; i < cities.Count; i++)
                    {
                        CalculateDistances(ref cities, i - 1);
                        quickSortRnd(ref cities, i, cities.Count - 1, averageDistance);
                        
                    }
                    curDistance = TotalDistance(cities);
                    counter++;
                    
                }
                Console.WriteLine(counter);
                counter++;
                Timer.instance.Pause();
                Report(cities, curDistance);
                Timer.instance.Pause();
                distance = curDistance;
            }
            Timer.instance.Stop();
            Console.WriteLine("Timer Simon: " + Timer.instance.elapsedTime());
            Report(cities, curDistance);            
        }

        private int partitionRnd(ref List<City> cities, int left, int right, double average)
        {
            //findMedianOfMedians(ref cities, left, right); not needed for our moving target
            int pivotIndex = left, index = left, i;
            double pivotValue = cities[pivotIndex].Distance + average * MathHelper.getRandom();
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


        private void quickSortRnd(ref List<City> cities, int left, int right, double average)
        {

            int pivotIndex = 0;


            if (left >= right)
                return;

            pivotIndex = partitionRnd(ref cities, left, right, average);
            //CalculateDistances(ref cities, left);
            quickSort(ref cities, left, pivotIndex - 1);
            //quickSort(ref cities, pivotNewIndex + 1, right); not need only conserned with shorter values

        }
    }
}
