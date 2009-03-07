using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Business_Logic
{

    public sealed class ArcMatrix
    {

        private List<Arc> matrix = new List<Arc>();

        static ArcMatrix instance = null;
        static readonly object padlock = new object();
        private ArcMatrix()
        {
        }

        public static ArcMatrix Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ArcMatrix();
                    }
                    return instance;
                }
            }

        }

        public void reset()
        {
        }

        /// <summary>
        /// Creates an empty matrix of the cities in the network
        /// </summary>
        /// <param name="cities"></param>
        public void createMatrix(List<City> cities)
        {
            if (matrix != null) matrix.Clear();
            //matrix = new Arc[cities.Count*cities.Count];
            for(int i = 0;i<cities.Count;i++)
            {
                // optimised  not all are needed :for(int j=i+1;j<cities.Count;j++)
                for (int j = 0; j < cities.Count; j++)
                {
                    Arc arcTemp = new Arc(cities[i], cities[j]);
                    arcTemp.Pheremone = 0;
                    matrix.Add(arcTemp);
                    // Console.WriteLine("From: "+arcTemp.FrmCity.Name+"to: "+arcTemp.ToCity.Name+" Distance "+arcTemp.Dist);
                    
                }
            }
        }

        public void updateMatrix(List<City> cities, double pheremoneLevel)
        {
            for(int i = 0; i<cities.Count-1; i++)
            {
                foreach (Arc arc in matrix)
                {
                    if (arc.FrmCity.Name == cities[i].Name && arc.ToCity.Name == cities[i + 1].Name) arc.Pheremone += pheremoneLevel;
                    else if (arc.FrmCity.Name == cities[i+1].Name && arc.ToCity.Name == cities[i].Name) arc.Pheremone += pheremoneLevel;
                    //if (arc.Pheremone != 0) Console.WriteLine(arc.FrmCity.Name+"-->"+arc.ToCity.Name+" level "+arc.Pheremone);
                }
            }
        }
        public void EvaporateMatrix(double rate)
        {
            foreach (Arc arc in matrix)
                {
                    arc.Pheremone = arc.Pheremone/rate;
                }
        }



        public List<Arc> getNearestCities(City curCity, List<string> visitedCities)
        {
            //visitedCities.Add(curCity.Name);
            List<Arc> arcs = new List<Arc>(matrix.FindAll(delegate(Arc a1) {


                if ((a1.FrmCity.Name == curCity.Name)&&(!visitedCities.Contains(a1.ToCity.Name)) && (a1.FrmCity!=a1.ToCity))
                    return true;
                //else if ((a1.ToCity.Name == curCity.Name) && (!visitedCities.Contains(a1.FrmCity.Name)))
                //{
                //    a1.SwapToFrm();
                //    return true;
                //}
                return false;
            }));

            arcs.Sort(delegate(Arc a1, Arc a2)
            {
                return (a1.Dist.CompareTo(a2.Dist));
            });
            
            /*List<Arc> shortArcList = new List<Arc>();
            double shortestDistance = arcs[0].Dist;
            
            foreach (Arc arc in arcs)
            {
                if (arc.Dist <= shortestDistance)
                    shortArcList.Add(arc);
            }
            shortArcList.Reverse();*/

            

            return arcs;
        }
    }

    public sealed partial class Solver
    {
        
        #region Data members
        const double Pheremone = 1;
        const int Iterations = 10;
        #endregion


        public void AntColonyOptimisation(ref List<City> cities)
        {            
            List<List<Arc>> pathArcList = new List<List<Arc>>();
            List<Arc> arcPath = new List<Arc>();
            ArcMatrix.Instance.createMatrix(cities);
            
            //populate first Arc List
            //BasicFeasible(ref cities,0);
            for (int i = 0; i < cities.Count(); i++)
            {
                Arc temp = new Arc();

                temp.FrmCity = (City)cities[i].Clone();
                temp.ToCity = (City)cities[(i+1) % cities.Count].Clone();
                arcPath.Add(temp);
                
            }
            
            pathArcList.Add(arcPath);
            
            ConstructAntSolution(ref pathArcList);
            PheromoneUpdate(ref pathArcList);
            //ReportArcs(pathArcList[1], TotalArcDistance(pathArcList[1]));
            List<City> reportCityList = new List<City>();
            foreach (Arc arc in pathArcList[1])
                reportCityList.Add(arc.FrmCity);
            Report(reportCityList, TotalArcDistance(pathArcList[1]));
            foreach (List<Arc> arcList in pathArcList)
                Console.WriteLine("Start City: " + arcList[0].FrmCity.Name + " Distance: " + TotalArcDistance(arcList));

        }

        private void ConstructAntSolution(ref List<List<Arc>> pathArcList)
        {
            //Construction Ants Solutions manages a colony of ants
            //that cooperatively and interactively visit adjacent states
            //of the considered problem by moving through feasi-
            //ble neighbor nodes of the graph. The movements are
            //based on a local ant-decision rule that makes use of
            //pheromone trails and heuristic information. In this
            //way, ants incrementally build solutions to the problem.
            for (int i = 0; i < pathArcList[0].Count(); i++)
            {
                pathArcList.Add(CreateAntPath(pathArcList[0], i));
            }
        }

        private List<Arc> CreateAntPath(List<Arc> path, int startCity)
        {
            List<Arc> currentPath = new List<Arc>();
            
            List<string> visitedCities = new List<string>();
            
            SwapArcs(ref path, 0, startCity);
            
            for (int i = 0; i < path.Count; i++)
            {
                Arc tempArc = new Arc();
                if (i + 1 < path.Count)
                {
                    tempArc.FrmCity = path[i].FrmCity;
                    visitedCities.Add(tempArc.FrmCity.Name);
                    tempArc.ToCity = findNearestCity(path[i].FrmCity, visitedCities);
                    currentPath.Add(tempArc);
                    SwapArcs(ref path, i + 1, path.FindIndex(delegate(Arc a1) { if (a1.FrmCity.Name == tempArc.ToCity.Name)return true; return false; }));
                }
                else
                {
                    tempArc.FrmCity = path[i].FrmCity;
                    tempArc.ToCity = path[0].FrmCity;
                    currentPath.Add(tempArc);
                    visitedCities.Add(tempArc.FrmCity.Name);
                }

            }
            
            return (currentPath);

        }
        private void SwapArcs(ref List<Arc> arcList, int oldIndex, int newIndex)
        {
            Arc tempArc = new Arc();
            tempArc = arcList[oldIndex];
            arcList[oldIndex] = arcList[newIndex];
            arcList[newIndex] = tempArc;
        }
        private City findNearestCity(City FromCity, List<string> visitedCities)
        {
            List<Arc> nearestArcs = new List<Arc>(ArcMatrix.Instance.getNearestCities(FromCity, visitedCities));
            return (nearestArcs[0].ToCity);
        }

        private void PheromoneUpdate(ref List<List<Arc>> pathArcList)
        {
            EvaporateTrails();
            DepostitTrails(ref pathArcList);
        }
        private void EvaporateTrails()
        {
            double rate = 2;
            ArcMatrix.Instance.EvaporateMatrix(rate);
        }

        private void DepostitTrails(ref List<List<Arc>> pathList)
        {

            //pathList.Sort(delegate

        }


        private void DaemonActions()
        {
            //The Daemon Actions procedure is used to imple-
            //ment centralized actions which cannot be performed by a
            //single ant. Daemon Actions are optional for ACO algo-
            //rithms. The idea is to collect useful global information
            //that can be used to decide whether it is useful or not and
            //to deposit additional pheromone to bias the search process
            //from a non-local perspective.
        }
        public static City ArcToCity(Arc curArc)
        {
            return curArc.ToCity;
        }
        public double TotalArcDistance(List<Arc> arcList)
        {
            double distance = 0;
            foreach (Arc arc in arcList)
            {
                distance += arc.Dist;
            }
            return (distance);
        }

    }
}
/*public void AntColonyOptimisation(ref List<City> cities)
        {
            List<List<City>> pathList = new List<List<City>>();
            ArcMatrix.Instance.createMatrix(cities);
            List<City> path = new List<City>();

            for(int j=0;j<Iterations;j++)
            {
                for(int i=0;i<1;i++)//i=number of ants
                {
                    pathList.Add(ConstructAntSolution(ref cities,i));
                }
                PheromoneUpdate(ref pathList,ref cities);
               // DaemonActions();
            }
            
            
        }

        private List<City> ConstructAntSolution(ref List<City> cities, int startCity)
        {
            //Construction Ants Solutions manages a colony of ants
            //that cooperatively and interactively visit adjacent states
            //of the considered problem by moving through feasi-
            //ble neighbor nodes of the graph. The movements are
            //based on a local ant-decision rule that makes use of
            //pheromone trails and heuristic information. In this
            //way, ants incrementally build solutions to the problem.

            //create a new ant that retuns a trail
            List<City> path = new List<City>(cities);
            swapCity(ref path, 0, startCity);
            for(int i=0;i<cities.Count-1;i++)
            {
                moveAnt(ref path, i);
            }
            return (path);

        }
        private void moveAnt(ref List<City> path,int startCity)
        {
            int nextCity=0;
            nextCity = findNearest(path.GetRange(startCity,path.Count-startCity));//problem here
            //path.FindIndex(ArcMatrix.Instance.getNearestCities(path[startCity])
            if(nextCity>0)swapCity(ref path, startCity+1, nextCity);
        }
        private int findNearest(List<City> cities)
        {
            int index = 0, bestArc=0;
            // List<City> nearestCities = new List<City>(ArcMatrix.Instance.getNearestCities(cites[0]));
            // List<City> nearestCities = ArcMatrix.Instance.getNearestCities(cites[0]).ConvertAll(new Converter<Arc, City>(ArcToCity)) ;
            List<Arc> nearestArcs = ArcMatrix.Instance.getNearestCities(cities[0]);

            double avePath = 0, totalDistance = 0;
            double modifier = 0;
            bool found = false;
            
            
            for(int i =0;i<nearestArcs.Count();i++)//(Arc curArc in nearestArcs)
            {
                found = false;
                foreach (City comCity in cities)
                {
                    if (comCity.Name == nearestArcs[i].ToCity.Name)
                        found = true;
                }
                if (found)
                {
                    // does contain
                    Console.WriteLine(nearestArcs[i].ToCity.Name);

                }
                else 
                {
                    Console.WriteLine("removed: "+nearestArcs[i].ToCity.Name);
                    nearestArcs.Remove(nearestArcs[i]);
                    
                }

            }
            Console.WriteLine("******************************");
            //foreach (Arc patharc in nearestArcs)
            //{
            //    totalDistance = +patharc.Dist;
            //}
            //avePath = totalDistance / nearestArcs.Count();
            
            //add randomness and attractiveness 
            for (int i = 0; i < nearestArcs.Count(); i++)
            {
                //modifier = (nearestArcs[bestArc].Pheremone) * avePath - (nearestArcs[i].Pheremone) * avePath;
                if (nearestArcs[i].Dist < nearestArcs[bestArc].Dist)
                {
                    bestArc = i;
                }
            }


            for (int i = 0; i < cities.Count(); i++)
            {
                if (nearestArcs[bestArc].ToCity.Name == cities[i].Name)
                {

                    index = i;
                }
            }
            return index;
        }

        private void PheromoneUpdate(ref List<List<City>> pathList,ref List<City> cities)
        {
            //Pheromone Update consists of pheromone evaporation
            //and new pheromone deposition. Pheromone evaporation
            //is a process of decreasing the intensity of pheromone trails
            //over time. This process guides ants to explore possible
            //paths, and it avoids too rapid convergence of the algo-
            //rithm toward a suboptimal region. Pheromone Update is
            //used to implement a useful form of forgetting which en-
            //ables the ants to forage the promising area of the search
            //space.
            /*
             * EvaporateTrails(cities)
             * DepositTrails(path)
             *//*
            EvaporateTrails();
            DepostitTrails(ref pathList,ref cities);
        }
        private void EvaporateTrails()
        {
            double rate = 2;

            ArcMatrix.Instance.EvaporateMatrix(rate);
        }

        private void DepostitTrails(ref List<List<City>> pathList, ref List<City> cities)
        {
           // int shortestPathIndex = 0;
            List<int> theShortList = new List<int>();
            theShortList.Add(0);

            for (int i = 0; i < pathList.Count(); i++)
            {
               
                if (TotalDistance(pathList[i]) < TotalDistance(pathList[theShortList.Count-1]))
                {
                    //shortestPathIndex = i;
                    theShortList.Add(i);
                    Report(pathList[i], TotalDistance(pathList[i]));
                }
            }
            //ArcMatrix.Instance.updateMatrix(pathList[shortestPathIndex],1);//perio levels here
            foreach (int i in theShortList)
            {
                ArcMatrix.Instance.updateMatrix(pathList[i], Pheremone);
            }
            //Report(pathList[theShortList[theShortList.Count-1]],TotalDistance(pathList[theShortList[theShortList.Count-1]]));
        }


        private void DaemonActions()
        {
            //The Daemon Actions procedure is used to imple-
            //ment centralized actions which cannot be performed by a
            //single ant. Daemon Actions are optional for ACO algo-
            //rithms. The idea is to collect useful global information
            //that can be used to decide whether it is useful or not and
            //to deposit additional pheromone to bias the search process
            //from a non-local perspective.
        }
        public static City ArcToCity(Arc curArc)
        {
            return curArc.ToCity;
        }
    }
}
*/