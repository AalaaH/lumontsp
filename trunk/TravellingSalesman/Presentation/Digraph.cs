using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TravellingSalesman.Data_Logic;

namespace TravellingSalesman.Presentation
{
    public partial class Digraph : UserControl
    {


        #region Data members

        #endregion

        #region Public methods




        #endregion

        public Digraph()
        {
            InitializeComponent();
            
        }


        public void Clear()
        {
            (this.CreateGraphics()).Clear(Color.White);
        }

        
        public void DrawCities(List<City> cities)
        {
            Graphics dc = CreateGraphics();
            Pen gPen = new Pen(Color.DarkOrange, 3);
            Font fArial = new Font("Arial", 8);

            int i=0;
            while (i < (cities.Count - 1))
            {
                DrawPath(cities[i], cities[i + 1]);                     
                dc.DrawEllipse(gPen, cities[i].X - 2, cities[i].Y - 2, 5, 5);
                if (i == 0) 
                    dc.DrawEllipse(new Pen(Color.DarkGreen, 3), cities[i].X - 2 , cities[i].Y - 2 , 5, 5);

                dc.DrawString(cities[i].Name, fArial, Brushes.Black, new PointF(cities[i].X, cities[i].Y));
                i++;
            }

            dc.DrawEllipse(gPen, cities[cities.Count-1].X - 2 , cities[cities.Count-1].Y - 2 , 5, 5);     
        }
        
        private void DrawPath(City startCity, City endCity)
        {
            Pen lGPen = new Pen(Color.LightGray,1);
            Graphics dc = CreateGraphics();
            dc.SmoothingMode = SmoothingMode.HighQuality;
            dc.DrawLine(lGPen, new Point(startCity.X , startCity.Y ), new Point(endCity.X , endCity.Y ));
        }

    }
}
