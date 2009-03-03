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
            foreach (City a in cities)
            {
                foreach (City b in cities)
                {
                    Arc arcTemp = new Arc(a, b);
                    arcTemp.Pheremone = 0;
                    matrix.Add(arcTemp);
                }
            }
        }

        public void updateMatrix(List<City> cities, double pheremoneLevel)
        {
            for(int i = 0; i<cities.Count-1; i++)
            {
                foreach (Arc arc in matrix)
                {
                    if (arc.FrmCity == cities[i] && arc.ToCity == cities[i + 1]) arc.Pheremone += pheremoneLevel;
                    else if (arc.FrmCity == cities[i+1] && arc.ToCity == cities[i]) arc.Pheremone += pheremoneLevel;
                    //if (arc.Pheremone != 0) Console.WriteLine(arc.FrmCity.Name+"-->"+arc.ToCity.Name+" level "+arc.Pheremone);
                }
            }
        }

        public List<Arc> getNearestCities(City curCity)
        {
            List<Arc> arcs = matrix.FindAll(delegate(Arc a1) { 
                if (a1.FrmCity.Name == curCity.Name) 
                    return true;
                return false;
            });

            arcs.Sort(delegate (Arc a1, Arc a2) { 
                return (a1.Dist.CompareTo(a2.Dist));
            });

            return arcs.GetRange(0, 5);
        }
    }




    public sealed partial class Solver
    {

        public void AntColonyOptimisation(ref List<City> cities)
        {
            bool goodSolution = false;
            int counter = 0;
            List<List<City>> pathList = new List<List<City>>();
            ArcMatrix.Instance.createMatrix(cities);
            List<City> path = new List<City>();

            while (!goodSolution)
            {
                
                
                for(int i=0;i<cities.Count()-1;i++)//i=number of ants
                {
                    pathList.Add(ConstructAntSolution(ref cities,i));
                }
                PheromoneUpdate(ref pathList,ref cities);
                
                if (counter > 2) goodSolution = true;
                else counter++;
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
            int nextCity;
            nextCity = findNearest(path.GetRange(startCity,path.Count-startCity));//problem here
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

            
            
            for(int i =0;i<nearestArcs.Count();i++)//(Arc curArc in nearestArcs)
            {
                if (cities.Contains(nearestArcs[i].ToCity))
                {
                    // does contain

                }
                else 
                {
                    nearestArcs.Remove(nearestArcs[i]);
                }

            }
            foreach (Arc patharc in nearestArcs)
            {
                totalDistance = +patharc.Dist;
            }
            avePath = totalDistance / nearestArcs.Count();
            
            //add randomness and attractiveness 
            for (int i = 0; i < nearestArcs.Count() - 1; i++)
            {
                modifier = nearestArcs[bestArc].Pheremone*avePath - nearestArcs[i].Pheremone*avePath - MathHelper.getRandom() * avePath;
                if ((nearestArcs[i].Dist + modifier)< nearestArcs[bestArc].Dist)
                {
                    bestArc = i;
                }
            }
            
            index = cities.IndexOf(nearestArcs[bestArc].ToCity);
            
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
             */
            DepostitTrails(ref pathList,ref cities);
        }
        private void DepostitTrails(ref List<List<City>> pathList, ref List<City> cities)
        {
            int shortestPathIndex = 0;
            
            for (int i = 0; i < pathList.Count(); i++)
            {
               
                if (TotalDistance(pathList[i]) < TotalDistance(pathList[shortestPathIndex]))
                {
                    shortestPathIndex = i;
                    Console.WriteLine(TotalDistance(pathList[i]));
                }
            }
            ArcMatrix.Instance.updateMatrix(pathList[shortestPathIndex],1);//perio levels here
            CopyListCityList(pathList[shortestPathIndex], ref cities);
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
        private void CopyListCityList(List<City> citiesOld, ref List<City> citiesNew)
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
