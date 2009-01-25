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
            int i=0;
            while (i <= (cities.Count - 1))
            {
                Graphics dc = CreateGraphics();
                Pen GPen = new Pen(Color.Green);
                dc.DrawEllipse(GPen, cities[i].X, cities[i].Y, 1, 1);
                DrawPath(cities[i], cities[i + 1]);
                i++;
            }
        }
        
        private void DrawPath(City startCity, City endCity)
        {
            Pen LGPen = new Pen(Color.LightGray);
            Graphics dc = CreateGraphics();
            dc.DrawLine(LGPen, new Point(startCity.X, startCity.Y), new Point(endCity.X, endCity.Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics dc = e.Graphics;
            Pen GreenPen = new Pen(Color.Green, 2);

            dc.DrawEllipse(GreenPen, 0, 0, 10, 10);
        }
    }
}
