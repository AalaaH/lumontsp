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
        
        public void DrawCities(List<City> Cities)
        {
         /*   int i=0;   
            while there is more cites + 1
            {
                DrawPath(cities[i],cities[i+1]);
                i++;
            }
          */
        }
        
        private void DrawPath(City StartCity, City EndCity)
        {
            /*
             * DrawArc(StartCity,EndCity);
             */
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = CreateGraphics();
            Pen GreenPen = new Pen(Color.Green, 2);

            dc.DrawEllipse(GreenPen, 0, 0, 10, 10);
        }
    }
}
