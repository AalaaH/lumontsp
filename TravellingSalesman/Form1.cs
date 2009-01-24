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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Controls.Add(digraph);


            
        }
        private void Debug(object msg)
        {
            Console.WriteLine(msg.ToString());
        }

        private void butSimAnnealing_Click(object sender, EventArgs e)
        {
            List<City> cities = Init.instance.GenerateProblem(50, 0, 100);
            Solver.instance.SimAnneal(ref cities, 20, 0.5);
        }
    }
}
