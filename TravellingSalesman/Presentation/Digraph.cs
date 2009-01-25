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
        }

        public void Clear()
        {
            (this.CreateGraphics()).Clear(Color.White);
        }

        
        public void DrawCities(List<City> cities)
        {
            Graphics dc = CreateGraphics();
            Pen gPen = new Pen(Color.DarkOrange, 3);
            Font f = new Font("Arial", 8);

            int i=0;
            while (i < (cities.Count - 1))
            {
                DrawPath(cities[i], cities[i + 1]);                     
                dc.DrawEllipse(gPen, cities[i].X - 2 + offset, cities[i].Y - 2 + offset, 5, 5);
                if (i == 0) dc.DrawEllipse(new Pen(Color.DarkGreen, 3), cities[i].X - 2 + offset, cities[i].Y - 2 + offset, 5, 5);

                dc.DrawString(cities[i].Name, f, Brushes.Black, new PointF(cities[i].X, cities[i].Y));
                i++;
            }

            dc.DrawEllipse(gPen, cities[cities.Count-1].X - 2 + offset, cities[cities.Count-1].Y - 2 + offset, 5, 5);     
        }
        
        private void DrawPath(City startCity, City endCity)
        {
            Pen lGPen = new Pen(Color.LightGray,1);
            Graphics dc = CreateGraphics();
            
            dc.DrawLine(lGPen, new Point(startCity.X + offset, startCity.Y + offset), new Point(endCity.X + offset, endCity.Y + offset));
        }

    }
}
