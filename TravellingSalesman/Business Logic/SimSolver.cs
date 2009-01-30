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

            double distance = TotalDistance(cities);
            double curDistance = TotalDistance(cities);
            
            Timer.instance.Start();
            int counter=1;
            List<City> cityTemp = null;
            int maxIterations = 200*cities.Count;
            int temperature = 1000;
            int lastBestTemp=0;

            CalculateDistances(ref cities, 0, cities.Count-1);
            while (counter < maxIterations)
            {                
                double averageDistance = TotalDistance(cities) / cities.Count;
               
                while (curDistance >= distance)
                {


                    for (int i = 1; i < cities.Count; i++)
                    {
                        CalculateDistances(ref cities, i - 1,i+20);
                        quickSortRnd(ref cities, i, cities.Count - 1, averageDistance, temperature);
                        
                    }
                    curDistance = TotalDistance(cities);
                    
                    if (curDistance<distance) CopyCityList(ref cities,ref cityTemp);
                                        
                    counter++;
                    temperature--;
                    if (counter > maxIterations) break;
                    Timer.instance.Pause();
                    Report(cities, curDistance);
                    Timer.instance.Pause();
                    if (temperature == 0) temperature = lastBestTemp;
                    
                }
               // Console.WriteLine(counter);
                counter++;
                lastBestTemp = temperature;

                Timer.instance.Pause();
                Report(cities, curDistance);
                Timer.instance.Pause();
                distance = curDistance;
            }
            Timer.instance.Stop();
            Console.WriteLine("Timer Simon: " + Timer.instance.elapsedTime());

            if (cityTemp != null)
            {
                CopyCityList(ref cityTemp,ref cities);
            }

            Report(cities, curDistance);            
        }

        private int partitionRnd(ref List<City> cities, int left, int right, double average, int temperature)
        {
            
            int pivotIndex = left, index = left, i;
            double pivotValue = cities[pivotIndex].Distance + ((average + temperature) * MathHelper.getRandom());
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


        private void quickSortRnd(ref List<City> cities, int left, int right, double average, int temperature)
        {

            int pivotIndex = 0;


            if (left >= right)
                return;

            pivotIndex = partitionRnd(ref cities, left, right, average,temperature);
            quickSortRnd(ref cities, left, pivotIndex - 1, average, temperature); //whats going on with average here
            //quickSortRnd(ref cities, pivotIndex + 1, right, average, temperature); //not needed only conserned with shorter values

        }
        private void swapCity(ref List<City> cities, int index1, int index2)
        {
            City temp = cities[index1];
            cities[index1] = cities[index2];
            cities[index2] = temp;
        }
        private void CalculateDistances(ref List<City> cities, int startCity,int endCity)
        {
            cities[0].Distance = MathHelper.getDistance(cities[0], cities.Last());
            if (endCity > cities.Count) endCity = cities.Count;
            for (int i = startCity + 1; i < endCity; i++)
            {
                cities[i].Distance = MathHelper.getDistance(cities[startCity], cities[i]);
            }
        }
        private void CopyCityList(ref List<City> citiesOld, ref List<City> citiesNew)
        {
            if (citiesNew == null)
            {
                citiesNew = new List<City>(citiesOld);
            }
            else
            {
                citiesNew.Clear();
                foreach (City c in citiesOld) citiesNew.Add((City)c);

            }
        }

    }
}
