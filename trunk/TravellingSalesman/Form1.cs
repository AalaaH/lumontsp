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
        public frmMain()
        {
            InitializeComponent();
        }

        List<City> cities = new List<City>();
        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            cities.Add(new City(10, 15, "syd"));            
            cities.Add(new City(200, 378, "melb"));
            cities.Add(new City(193, 45, "adl"));
            cities.Add(new City(290, 38, "canb"));
            cities.Add(new City(457, 86, "darwin"));
            cities.Add(new City(89, 70, "perth"));
            cities.Add(new City(157, 60, "newcast"));
            cities.Add(new City(536, 200, "gong"));
            cities.Add(new City(274, 300, "miranda"));
            cities.Add(new City(546, 48, "cron"));
            cities.Add(new City(24, 60, "camden"));

            

            list.SetData(cities);
            digraph.Cities = cities;
        }




        private void butSimAnnealing_Click(object sender, EventArgs e)
        {

            Solver.instance.Report = RefreshCities;
            Solver.instance.SimAnneal(ref cities, 1200, 0.001);        
        }

        private void RefreshCities(List<City> cities)
        {            
            digraph.Cities = cities;
            digraph.Refresh();

            list.SetData(cities);
            statusObjective.Text = "Total Distance: " + Solver.instance.TotalDistance(cities);
            
        }

        private void butDiagraph_Click(object sender, EventArgs e)
        {
            digraph.Clear();
            digraph.Cities = cities;
        }

        private void butGenerateProblem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            digraph.Clear();
            cities = Init.instance.GenerateProblem(5, digraph.Width, digraph.Height, digraph.Margin.All);
            list.SetData(cities);
            digraph.Cities = cities;

            Cursor.Current = Cursors.Default;
        }


        private void butBasicFeasible_Click(object sender, EventArgs e)
        {
            //cities = Init.instance.GenerateProblem(50, digraph.Width, digraph.Height, digraph.Margin.All);
            Solver.instance.Report = RefreshCities;
            Solver.instance.SimonsBasicFeasible(ref cities);
            
        }
    }
}
