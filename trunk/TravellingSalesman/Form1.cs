using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using TravellingSalesman.Business_Logic;
using TravellingSalesman.Data_Logic;
using TravellingSalesman.Presentation;

namespace TravellingSalesman
{
    public partial class frmMain : Form
    {

        private BackgroundWorker bg_worker = new BackgroundWorker();
        private List<City> ori_cities = new List<City>();
        private List<City> cities;


        public frmMain()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();
            bg_worker.DoWork+=new DoWorkEventHandler(bg_worker_DoWork);
            // ori_cities = Init.instance.GenerateProblem(200, digraph.Width, digraph.Height, digraph.Margin.All);
            cities = new List<City>(ori_cities);
            
            ResetCities();
             
        }


        public void bg_worker_DoWork(object sender, DoWorkEventArgs e)
        {
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);            
        }




        private void butSimAnnealing_Click(object sender, EventArgs e)
        {
            double temp = 20;
            double delta = 0.5;
            try
            {
                temp = Convert.ToDouble(txtTemp.Text);
                delta = Convert.ToDouble(txtDelta.Text);
            }
            catch { }
            Solver.instance.Report = RefreshCities;
            Solver.instance.SimAnneal(ref cities, 25, 0.5);        
        }

        private void RefreshCities(List<City> cities, double distance)
        {
            List<Arc> arcs = new List<Arc>();
            for (int x = 0; x < cities.Count - 1; x++)
            {
                Arc temp = new Arc(cities[x], cities[x + 1]);
                temp.Collides = cities[x].Collides;
                
                arcs.Add(temp);
                
            }

            distance  = Solver.instance.TotalDistance(cities);
            digraph.Arcs = arcs;
            digraph.Cities = cities;
            digraph.Refresh();

            //list.SetData(cities);
            //list.Refresh();
            statusObjective.Text = "Total Distance: " + distance.ToString();

            lblDistance.Text = distance.ToString(); // Solver.instance.TotalDistance(cities).ToString();
            graph.TotalDistance.Add(distance);
            graph.Refresh();

            lblDistance.Refresh();
            
        }

        private void butDiagraph_Click(object sender, EventArgs e)
        {
            digraph.Clear();
            digraph.Cities = cities;
        }

        private int Factorial(int n)
        {
            int total = 0;
            int i = n;
            while (i > 0) { total *= i; i--; } return total;
        }

        private void butGenerateProblem_Click(object sender, EventArgs e)
        {
            int numCities = 50;
            try
            {
                numCities = Convert.ToInt32(txtNumCities.Text);
            }
            catch { }
            Cursor.Current = Cursors.WaitCursor;
            digraph.Clear();

            cities = Init.instance.GenerateProblem(numCities, digraph.Width, digraph.Height, 5);
            
            //list.SetData(cities);
            digraph.Cities = cities;
            digraph.Refresh();

            Cursor.Current = Cursors.Default;
        }


        private void butBasicFeasible_Click(object sender, EventArgs e)
        {
            // cities = Init.instance.GenerateProblem(200, digraph.Width, digraph.Height, digraph.Margin.All);
            Solver.instance.Report = RefreshCities;
            Solver.instance.BasicFeasible(ref cities, 0);
        }

        private void butSimBFS_Click(object sender, EventArgs e)
        {
            //cities = Init.instance.GenerateProblem(200, digraph.Width, digraph.Height, digraph.Margin.All);
            //Solver.instance.Report = RefreshCities;
            //Solver.instance.SimonsNotSoBasic(ref cities);
            Solver.instance.AntColonyOptimisation(ref cities);
        }

        private void ResetCities()
        {            
            cities.Clear();            
            cities.Add(new City(10, 15, "syd"));
            cities.Add(new City(100, 78, "melb"));
            cities.Add(new City(393, 45, "adl"));
            cities.Add(new City(290, 38, "canb"));
            cities.Add(new City(457, 86, "darwin"));
            cities.Add(new City(289, 70, "perth"));
            cities.Add(new City(457, 60, "newcast"));
            cities.Add(new City(536, 200, "gong"));
            cities.Add(new City(274, 300, "miranda"));
            cities.Add(new City(546, 48, "cron"));
            cities.Add(new City(24, 83, "camden"));

            cities.Add(new City(148, 357, "nyc"));
            cities.Add(new City(363, 312, "wangi"));
            cities.Add(new City(256, 27, "ashfield"));
            cities.Add(new City(490, 112, "town hall"));
            cities.Add(new City(345, 423, "penrith"));
            cities.Add(new City(110, 434, "northead"));
            cities.Add(new City(270, 275, "parra"));

            cities.Add(new City(64, 409, "strathfield"));
            cities.Add(new City(263, 412, "homebush"));
            cities.Add(new City(156, 377, "newtown"));
            cities.Add(new City(199, 412, "hurstville"));
            cities.Add(new City(245, 323, "wolli creek"));
            cities.Add(new City(310, 334, "mosman"));
            cities.Add(new City(470, 75, "north sydney"));


            cities.Add(new City(376, 364, "tasmania"));
            cities.Add(new City(243, 167, "hobart"));
            cities.Add(new City(43, 276, "england"));
            cities.Add(new City(166, 29, "colarado"));
            cities.Add(new City(250, 262, "wollstonecraft"));
            cities.Add(new City(327, 407, "yoga fire"));
            cities.Add(new City(43, 451, "hadouken"));

            cities.Add(new City(176, 214, "sonic boom"));
            cities.Add(new City(323, 167, "lighning kick"));
            cities.Add(new City(303, 276, "hunter hill"));
            cities.Add(new City(56, 369, "philli"));
            cities.Add(new City(250, 362, "copenhagen"));
            cities.Add(new City(127, 407, "egypt"));
            cities.Add(new City(133, 251, "india"));
            
            // cities = new List<City>(ori_cities);

            List<Arc> arcs = new List<Arc>();
            for (int x = 0; x < cities.Count - 1; x++) arcs.Add(new Arc(cities[x], cities[x + 1]));

            //list.SetData(cities);
            digraph.Cities = cities;
            digraph.Arcs = arcs;
            digraph.Refresh();
        }

        private void butReset_Click(object sender, EventArgs e)
        {

            ResetCities();
        }

        private void butSwapNodes_Click(object sender, EventArgs e)
        {
            
            RefreshCities(cities, 0);
        }

        private void butSimNSB_Click(object sender, EventArgs e)
        {
            Solver.instance.Report = RefreshCities;
            Solver.instance.SimonsNotSoBasic(ref cities);
        }

        private void graph_Load(object sender, EventArgs e)
        {

        }

        public void mouseClick(int xPos, int yPos)
        {
            xMouse.Text = xPos.ToString();
            yMouse.Text = yPos.ToString();
        }

        private void butCollision_Click(object sender, EventArgs e)
        {
            digraph.mouseReport = mouseClick;
            List<Arc> arcs = new List<Arc>();

            cities.Clear();
            cities = Init.instance.GenerateProblem(10, digraph.Width, digraph.Height, digraph.Margin.All);
            //cities.Add(new City(10, 15, "syd"));
            //cities.Add(new City(100, 78, "melb"));
            //cities.Add(new City(393, 45, "adl"));
            //cities.Add(new City(290, 38, "canb"));
            //cities.Add(new City(457, 86, "darwin"));
            //cities.Add(new City(289, 70, "perth"));


            //cities.Add(new City(176, 214, "sonic boom"));
            //cities.Add(new City(323, 167, "lighning kick"));
            //cities.Add(new City(303, 276, "hunter hill"));
            //cities.Add(new City(56, 369, "philli"));
            //cities.Add(new City(250, 362, "copenhagen"));
            //cities.Add(new City(127, 407, "egypt"));
            //cities.Add(new City(133, 251, "india"));

            for (int i = 0; i < cities.Count - 1; i++)
            {
                //arcs.Add(new Arc(cities[i], cities[i + 1]));
                Solver.instance.Collides(i, cities);
            }
            
            /*for (int i = 0; i < arcs.Count; i++)
            {
                Solver.instance.Collides(i, arcs);
            }*/

            digraph.Cities = cities;
            //digraph.Arcs = arcs;
            digraph.Refresh();



        }

        private void list_Load(object sender, EventArgs e)
        {

        }

        
    }
}
