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
                // optimise option not all are needed :for(int j=i+1;j<cities.Count;j++)
                for (int j = 0; j < cities.Count; j++)
                {
                    Arc arcTemp = new Arc(cities[i], cities[j]);
                    arcTemp.Pheremone = 0;
                    matrix.Add(arcTemp);
                }
            }
        }

        public void updateMatrix(ArcPath arcList, double pheremoneLevel)
        {
            for(int i = 0; i<arcList.List.Count; i++)
            {
                foreach (Arc arc in matrix)
                {
                    if ((arc.FrmCity.Name == arcList.List[i].FrmCity.Name)&&(arc.ToCity.Name == arcList.List[i].ToCity.Name)) arc.Pheremone += pheremoneLevel;
                    //else if (arc.FrmCity.Name == arcList[i+1].Name && arc.ToCity.Name == arcList[i].Name) arc.Pheremone += pheremoneLevel;
                    //if (arc.Pheremone != 0) Console.WriteLine(arc.FrmCity.Name+" --> "+arc.ToCity.Name+" level "+arc.Pheremone);
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
            List<Arc> arcs = new List<Arc>(matrix.FindAll(delegate(Arc a1) 
            {
                if ((a1.FrmCity.Name == curCity.Name) && (!visitedCities.Contains(a1.ToCity.Name)) && (a1.FrmCity != a1.ToCity))
                {
                    a1.Dist += (MathHelper.getRandom() * Solver.instance.bestAverageDistance)/(Solver.instance.Iteration);
                    return true;
                }
                return false;
            }));
            arcs.Sort(delegate(Arc a1, Arc a2)
            {
                
                return (a1.Dist.CompareTo(a2.Dist));
            });
            return arcs;
        }
    }

    public sealed partial class Solver
    {
        
        #region Data members
        const double PHEREMONE = 0.5;
        const double EVAPERATIONRATE = 2;
        const int ITERATIONS = 500;
        public int Iteration = 1;
        public double bestAverageDistance = 0;
        #endregion


        public void AntColonyOptimisation(ref List<City> cities)
        {            
            List<ArcPath> pathArcList = new List<ArcPath>();
            List<string> cityNameList = new List<string>();
            ArcPath arcPath = new ArcPath();
            ArcMatrix.Instance.createMatrix(cities);
            
            //populate first Arc List
            for (int i = 0; i < cities.Count(); i++)
            {
                Arc temp = new Arc();
                temp.FrmCity = (City)cities[i].Clone();
                temp.ToCity = (City)cities[(i+1) % cities.Count].Clone();
                arcPath.List.Add(temp);
                cityNameList.Add(temp.FrmCity.Name);
            }
            pathArcList.Add(arcPath);
            bestAverageDistance = arcPath.averageDistance;
            ConstructAntSolution(ref pathArcList,ref cityNameList);
            pathArcList.Remove(arcPath);
            for (int i = 1; i < ITERATIONS - 1; i++)
            {
                PheromoneUpdate(ref pathArcList);
                pathArcList = new List<ArcPath>(pathArcList.GetRange(0, 1));
                bestAverageDistance = pathArcList.First().averageDistance;
                ConstructAntSolution(ref pathArcList, ref cityNameList);
                Iteration++;
                ReportAntSoltion(ref pathArcList);
            }
        }
        private void ReportAntSoltion(ref List<ArcPath> pathArcList)
        {
            pathArcList.Sort();
            pathOrder(ref pathArcList);
            List<City> reportCityList = new List<City>();
            foreach (Arc arc in pathArcList[0].List)
            {
                reportCityList.Add((City)arc.FrmCity.Clone());
            }
            pathArcList[0].recalc();
            Report(reportCityList, pathArcList[0].totalDistance);
        }
        private void pathOrder(ref List<ArcPath> pathArcList)
        {
            for (int i = 0; i < pathArcList[0].List.Count()-1; i++)
            {
                ArcPath temp = new ArcPath(pathArcList[0].List);
                SwapArcs(ref temp, temp.List.FindIndex(delegate(Arc arc) { if (arc.FrmCity.Name == temp.List[i].ToCity.Name)return true; else return false; }), i + 1);
                pathArcList.Insert(0, temp);
            }
        }

        private void ConstructAntSolution(ref List<ArcPath> pathArcList, ref List<string> cityNameList)
        {
            //Construction Ants Solutions manages a colony of ants
            //that cooperatively and interactively visit adjacent states
            //of the considered problem by moving through feasi-
            //ble neighbor nodes of the graph. The movements are
            //based on a local ant-decision rule that makes use of
            //pheromone trails and heuristic information. In this
            //way, ants incrementally build solutions to the problem.
            foreach (string cityName in cityNameList)
            {
                ArcPath tempArcPath = new ArcPath(CreateAntPath(pathArcList[0], pathArcList[0].List.FindIndex(delegate(Arc a1) { if (a1.FrmCity.Name == cityName)return true; return false; })));
                pathArcList.Add(tempArcPath);
            }
        }

        private List<Arc> CreateAntPath(ArcPath path, int startCity)
        {
            List<Arc> currentPath = new List<Arc>();
            List<string> visitedCities = new List<string>();
            SwapArcs(ref path, 0, startCity);
            for (int i = 0; i < path.List.Count; i++)
            {
                Arc tempArc = new Arc();
                if (i + 1 < path.List.Count)
                {
                    tempArc.FrmCity = (City)path.List[i].FrmCity.Clone();
                    visitedCities.Add(tempArc.FrmCity.Name);
                    tempArc.ToCity = (City)(findNearestCity(path.List[i].FrmCity, visitedCities)).Clone();
                    currentPath.Add(tempArc);
                    SwapArcs(ref path, i + 1, path.List.FindIndex(delegate(Arc a1) { if (a1.FrmCity.Name == tempArc.ToCity.Name)return true; return false; }));
                }
                else
                {
                    tempArc.FrmCity = (City)path.List[i].FrmCity.Clone();
                    tempArc.ToCity = (City)path.List[0].FrmCity.Clone();
                    currentPath.Add(tempArc);
                    visitedCities.Add(tempArc.FrmCity.Name);
                }

            }
            
            return (currentPath);

        }
        private void SwapArcs(ref ArcPath arcList, int oldIndex, int newIndex)
        {
            Arc tempArc = new Arc();
            tempArc = (Arc)arcList.List[oldIndex].Clone();
            arcList.List[oldIndex] = (Arc)arcList.List[newIndex].Clone();
            arcList.List[newIndex] = tempArc;
        }
        private City findNearestCity(City FromCity, List<string> visitedCities)
        {
            int range = 3;
            List<Arc> nearestArcs = new List<Arc>(ArcMatrix.Instance.getNearestCities(FromCity, visitedCities));
            // add Pheremone to calculation
            if (range > nearestArcs.Count)
                range = nearestArcs.Count;
            nearestArcs = new List<Arc>(nearestArcs.GetRange(0, range));
            nearestArcs.Sort(delegate(Arc a1, Arc a2)
            {
                return (a1.Pheremone.CompareTo(a2.Pheremone));
            });
            nearestArcs.Reverse();
            return (nearestArcs[0].ToCity);
        }

        private void PheromoneUpdate(ref List<ArcPath> pathArcList)
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
            EvaporateTrails();
            DepostitTrails(ref pathArcList);
        }
        private void EvaporateTrails()
        {
            ArcMatrix.Instance.EvaporateMatrix(EVAPERATIONRATE);
        }

        private void DepostitTrails(ref List<ArcPath> pathList)
        {

            pathList.Sort();
            ArcMatrix.Instance.updateMatrix(pathList[1], (PHEREMONE/pathList[1].averageDistance) );
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
            return (City)curArc.ToCity.Clone();
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