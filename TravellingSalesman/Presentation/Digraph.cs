using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Presentation
{
    public partial class Digraph : UserControl
    {


        #region Data members



        #endregion

        #region Public methods




        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public Digraph(int width, int height)
        {
            InitializeComponent();
            components = new System.ComponentModel.Container();
            Size = new System.Drawing.Size(width, height);
            BackColor = Color.White; 
        }


        
        public void DrawCities(List<City> cities)
        {
            Graphics dc = CreateGraphics();
            Pen gPen = new Pen(Color.Green);

            int i=0;
            while (i < (cities.Count - 1))
            {
                dc.DrawEllipse(gPen, cities[i].X, cities[i].Y, 1, 1);
                DrawPath(cities[i], cities[i + 1]);
                i++;
            }
        }
        
        private void DrawPath(City startCity, City endCity)
        {
            Pen lGPen = new Pen(Color.LightGray);
            Graphics dc = CreateGraphics();
            dc.DrawLine(lGPen, new Point(startCity.X, startCity.Y), new Point(endCity.X, endCity.Y));
        }

    }
}
