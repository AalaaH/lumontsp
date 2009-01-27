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

        private List<City> ori_cities = new List<City>();
        private List<City> cities;


        public frmMain()
        {
            InitializeComponent();
            // ori_cities = Init.instance.GenerateProblem(200, digraph.Width, digraph.Height, digraph.Margin.All);
            cities = new List<City>(ori_cities);
            ResetCities();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);            
        }




        private void butSimAnnealing_Click(object sender, EventArgs e)
        {

            Solver.instance.Report = RefreshCities;
            Solver.instance.SimAnneal(ref cities, 20, 0.05);        
        }

        private void RefreshCities(List<City> cities, double distance)
        {            
            digraph.Cities = cities;
            digraph.Refresh();

            list.SetData(cities);
            list.Refresh();
            statusObjective.Text = "Total Distance: " + distance.ToString();
            
            lblDistance.Text = distance.ToString();
            lblDistance.Refresh();
            Debug.WriteLine("distance=" + distance.ToString());
            
        }

        private void butDiagraph_Click(object sender, EventArgs e)
        {
            digraph.Clear();
            digraph.Cities = cities;
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

            cities = Init.instance.GenerateProblem(numCities, digraph.Width, digraph.Height, digraph.Margin.All);
            
            list.SetData(cities);
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
            Solver.instance.Report = RefreshCities;
            Solver.instance.SimonsNotSoBasic(ref cities);
            
        }

        private void ResetCities()
        {            
            cities.Clear();            
            cities.Add(new City(10, 15, "syd"));
            cities.Add(new City(100, 78, "melb"));
            cities.Add(new City(893, 45, "adl"));
            cities.Add(new City(290, 38, "canb"));
            cities.Add(new City(457, 86, "darwin"));
            cities.Add(new City(289, 70, "perth"));
            cities.Add(new City(957, 60, "newcast"));
            cities.Add(new City(536, 200, "gong"));
            cities.Add(new City(274, 300, "miranda"));
            cities.Add(new City(546, 48, "cron"));
            cities.Add(new City(24, 83, "camden"));

            cities.Add(new City(648, 357, "nyc"));
            cities.Add(new City(363, 312, "wangi"));
            cities.Add(new City(256, 27, "ashfield"));
            cities.Add(new City(590, 512, "town hall"));
            cities.Add(new City(345, 423, "penrith"));
            cities.Add(new City(410, 434, "northead"));
            cities.Add(new City(670, 275, "parra"));

            cities.Add(new City(64, 409, "strathfield"));
            cities.Add(new City(563, 412, "homebush"));
            cities.Add(new City(156, 377, "newtown"));
            cities.Add(new City(899, 412, "hurstville"));
            cities.Add(new City(245, 323, "wolli creek"));
            cities.Add(new City(410, 334, "mosman"));
            cities.Add(new City(770, 75, "north sydney"));


            cities.Add(new City(876, 564, "tasmania"));
            cities.Add(new City(243, 567, "hobart"));
            cities.Add(new City(43, 276, "england"));
            cities.Add(new City(866, 29, "colarado"));
            cities.Add(new City(750, 562, "wollstonecraft"));
            cities.Add(new City(427, 407, "yoga fire"));
            cities.Add(new City(43, 451, "hadouken"));

            cities.Add(new City(576, 214, "sonic boom"));
            cities.Add(new City(323, 167, "lighning kick"));
            cities.Add(new City(503, 276, "hunter hill"));
            cities.Add(new City(56, 569, "philli"));
            cities.Add(new City(450, 362, "copenhagen"));
            cities.Add(new City(127, 407, "egypt"));
            cities.Add(new City(133, 251, "india"));
            
            // cities = new List<City>(ori_cities);
            list.SetData(cities);
            digraph.Cities = cities;
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

        
    }
}
