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
            List<City> cities = Init.instance.GenerateProblem(2000, 0, 100);
            Solver.instance.SimAnneal(ref cities, 20, 0.5);
        }

        private void butDiagraph_Click(object sender, EventArgs e)
        {
            int min = 0;
            int max = 500;
            Digraph dg = new Digraph(max, max);
            dg.Location = new Point(0, 50);
            dg.Dock = DockStyle.Bottom;
            Controls.Add(dg);
            dg.DrawCities(Init.instance.GenerateProblem(50, min, max));


        }
    }
}
