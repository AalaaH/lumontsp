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

        private List<City> _cts;
        public List<City> Cities
        {
            get { return _cts; }
            set { _cts = value; }
        }

        
        private void DrawCities()
        {
            Graphics dc = CreateGraphics();
            Font fArial = new Font("Arial", 8);

            if (Cities != null)
            {
                
                Pen gPen = new Pen(Color.DarkOrange, 3);
                

                int i = 0;
                while (i < (Cities.Count - 1))
                {
                    DrawPath(Cities[i], Cities[i + 1]);
                    dc.DrawEllipse(gPen, Cities[i].X - 2, Cities[i].Y - 2, 5, 5);
                    if (i == 0)
                        dc.DrawEllipse(new Pen(Color.DarkGreen, 3), Cities[i].X - 2, Cities[i].Y - 2, 5, 5);

                    dc.DrawString(Cities[i].Name, fArial, Brushes.Black, new PointF(Cities[i].X, Cities[i].Y));
                    i++;
                }

                dc.DrawEllipse(gPen, Cities[Cities.Count - 1].X - 2, Cities[Cities.Count - 1].Y - 2, 5, 5);
            }
            else
            {
                dc.DrawString("NO CITIES TO DRAW", new Font("Arial", 16), Brushes.Black, Width / 2, Height / 2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawCities();
        }

        
        private void DrawPath(City startCity, City endCity)
        {
            Pen lGPen = new Pen(Color.LightGray,2);
            Graphics dc = CreateGraphics();
            dc.SmoothingMode = SmoothingMode.HighQuality;
            dc.DrawLine(lGPen, new Point(startCity.X , startCity.Y ), new Point(endCity.X , endCity.Y ));
        }

    }
}
