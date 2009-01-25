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
        int offset = 5;


        #endregion

        #region Public methods




        #endregion

        public Digraph()
        {
            InitializeComponent();
            BackColor = Color.White;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public Digraph(int width, int height)
        {
            InitializeComponent();
            components = new System.ComponentModel.Container();
            Size = new System.Drawing.Size(width + (offset * 2), height + (offset * 2));
            BackColor = Color.White; 
        }


        
        public void DrawCities(List<City> cities)
        {
            Graphics dc = CreateGraphics();
            Pen gPen = new Pen(Color.Green,3);

            int i=0;
            while (i < (cities.Count - 1))
            {
                DrawPath(cities[i], cities[i + 1]);
                dc.DrawEllipse(gPen, cities[i].X - 2 + offset, cities[i].Y - 2 + offset, 5, 5);
                i++;
            }
        }
        
        private void DrawPath(City startCity, City endCity)
        {
            Pen lGPen = new Pen(Color.LightGray,3);
            Graphics dc = CreateGraphics();
            dc.DrawLine(lGPen, new Point(startCity.X + offset, startCity.Y + offset), new Point(endCity.X + offset, endCity.Y + offset));
        }

    }
}
