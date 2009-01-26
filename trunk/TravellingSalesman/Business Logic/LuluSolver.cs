﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{
    public sealed partial class Solver
    {


        public void BasicFeasible(ref List<City> cities)
        {
            for (int i = 0; i < cities.Count - 1; i++)
            {
                double curDistance = MathHelper.getDistance(cities[i], cities[i + 1]);
                int toSwap = -1;

                for (int x = i + 2; x < cities.Count; x++)
                {
                    
                    double newDistance = MathHelper.getDistance(cities[i], cities[x]);
                    Debug.WriteLine(cities[i].Name + ":" + cities[x].Name + " - n=" + newDistance + ": o=" + curDistance);

                    if (newDistance < curDistance)
                    {
                        curDistance = newDistance;
                        toSwap = x;
                        Debug.WriteLine("found smaller " + cities[x].Name);
                    }
                }

                if (toSwap > -1)
                {
                    City temp = cities[i+1];
                    cities[i+1] = cities[toSwap];
                    cities[toSwap] = temp;
                    Report(cities);
                }

            }
        }


        public void BasicFeasible2(ref List<City> cities)
        {
            double curDistance = 0;
            int toSwap = -1;

            for (int i = 0; i < cities.Count - 1; i++)
            {
                curDistance = MathHelper.getDistance(cities[i], cities[i + 1]);
                toSwap = -1;

                for (int x = i + 2; x < cities.Count; x++)
                {
                    double newDistance = MathHelper.getDistance(cities[i], cities[x]);
                    Debug.WriteLine(cities[i].Name + ":" + cities[x].Name + " - n=" + newDistance + ": o=" + curDistance);

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

                    Report.Invoke(cities);
                }
            }
        }
    }
}