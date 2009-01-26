using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void Debug(object msg)
        {
            Console.WriteLine(msg.ToString());
        }

        private void butSimAnnealing_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            digraph.Clear();
            List<City> cities = Init.instance.GenerateProblem(50, digraph.Width, digraph.Height, digraph.Margin.All);
            list.SetData(cities);
            digraph.DrawCities(cities);

            Cursor.Current = Cursors.Default;

            Solver.instance.Report = RefreshCities;
            Solver.instance.SimAnneal(ref cities, 1200, 0.001);        
        }

        private void RefreshCities(List<City> cities)
        {
            // Console.WriteLine("RefreshDigraph report");
            digraph.Clear();
            digraph.DrawCities(cities);
            list.SetData(cities);
            statusObjective.Text = "Total Distance: " + Solver.instance.TotalDistance(cities);
        }

        private void butDiagraph_Click(object sender, EventArgs e)
        {
            digraph.Clear();
            digraph.DrawCities(Init.instance.GenerateProblem(50, digraph.Width, digraph.Height, digraph.Margin.All));
        }

        List<City> cities = null;

        private void butGenerateProblem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            digraph.Clear();
            cities = Init.instance.GenerateProblem(5, digraph.Width, digraph.Height, digraph.Margin.All);
            list.SetData(cities);
            digraph.DrawCities(cities);

            Cursor.Current = Cursors.Default;
        }


        private void butBasicFeasible_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            digraph.Clear();
            List<City> cities = Init.instance.GenerateProblem(5, digraph.Width, digraph.Height, digraph.Margin.All);
            list.SetData(cities);
            digraph.DrawCities(cities);

            Cursor.Current = Cursors.Default;
            Solver.instance.Report = RefreshCities;
            Solver.instance.SimonsBasicFeasible(ref cities);
        }
    }
}
