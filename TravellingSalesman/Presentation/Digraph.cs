using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
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


        public delegate void MouseReport(int x, int y);
        public MouseReport mouseReport;

        #endregion

        public Digraph()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.MouseDown+=new MouseEventHandler(Digraph_MouseDown); 
            
        }

        public void Digraph_MouseDown(object sender, MouseEventArgs e)
        {
            if(mouseReport!=null) mouseReport.Invoke(e.X, e.Y);
        }


        public void Clear()
        {
            (this.CreateGraphics()).Clear(Color.White);
        }

        private List<City> _cts;
        public List<City> Cities
        {
            get 
            { 
                return _cts; 
            }
            set 
            { 
                _cts = value;
                Refresh();
            }
        }

        private List<Arc> _arcs;
        public List<Arc> Arcs
        {
            get
            {
                return _arcs;
            }
            set
            {
                _arcs = value;
                Refresh();
            }
        }

        private void DrawArcs(Graphics dc)
        {
            Font fArial = new Font("Arial", 8);

            if (Arcs != null && Arcs.Count > 0)
            {
                Pen gPen = new Pen(Color.DarkRed, 3);

                int i = 0;
                Arc arc;

                while (i < (Arcs.Count))
                {
                    arc = Arcs[i];
                    DrawArc(dc, arc);

                    dc.DrawEllipse(gPen, arc.FrmCity.X - 2, arc.FrmCity.Y - 2, 5, 5);
                    if (i == 0)
                        dc.DrawEllipse(new Pen(Color.DarkGreen, 3), arc.FrmCity.X - 2, arc.FrmCity.Y - 2, 5, 5);

                    if (arc.Collides)
                    {
                        dc.DrawEllipse(new Pen(Color.Red, 3), arc.FrmCity.X - 2, arc.FrmCity.Y - 2, 5, 5);
                    }

                    dc.DrawString(arc.FrmCity.Name, fArial, Brushes.Black, new PointF(arc.FrmCity.X, arc.FrmCity.Y));
                    i++;
                }
                arc = Arcs[i - 1];
                dc.DrawString(arc.ToCity.Name, fArial, Brushes.Black, new PointF(arc.ToCity.X, arc.ToCity.Y));

                dc.DrawEllipse(gPen, arc.ToCity.X - 2, arc.ToCity.Y - 2, 5, 5);
            }
            else
            {
                dc.DrawString("NO CITIES TO DRAW", new Font("Arial", 16), Brushes.Black, (Width / 2) - 100, Height / 2);
            }
        }


        private void DrawCities(Graphics dc)
        {
            Font fArial = new Font("Arial", 8);

            if (Cities!=null && Cities.Count>0)
            {
                Pen gPen = new Pen(Color.DarkRed, 3);
                
                int i = 0;
                while (i < (Cities.Count - 1))
                {
                    DrawPath(dc, Cities[i], Cities[i + 1]);
                    dc.DrawEllipse(gPen, Cities[i].X - 2, Cities[i].Y - 2, 5, 5);
                    if (i == 0)
                        dc.DrawEllipse(new Pen(Color.DarkGreen, 3), Cities[i].X - 2, Cities[i].Y - 2, 5, 5);

                    if(Cities[i].Collides)
                        dc.DrawEllipse(new Pen(Color.Red, 3), Cities[i].X - 2, Cities[i].Y - 2, 5, 5);

                    dc.DrawString(Cities[i].Name, fArial, Brushes.Black, new PointF(Cities[i].X, Cities[i].Y));
                    i++;
                }
                DrawPath(dc, Cities[0], Cities.Last());
                dc.DrawString(Cities[i].Name, fArial, Brushes.Black, new PointF(Cities[i].X, Cities[i].Y));

                dc.DrawEllipse(gPen, Cities[Cities.Count - 1].X - 2, Cities[Cities.Count - 1].Y - 2, 5, 5);
            }
            else
            {
                dc.DrawString("NO CITIES TO DRAW", new Font("Arial", 16), Brushes.Black, (Width / 2)-100, Height / 2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawCities(e.Graphics);
            //DrawArcs(e.Graphics);
            
        }


        private void DrawArc(Graphics dc, Arc arc)
        {
            Pen colorPen = new Pen(Color.DarkGray, 2);
            if (arc.Collides) colorPen.Color = Color.Red;
            dc.DrawLine(colorPen, new Point(arc.FrmCity.X, arc.FrmCity.Y), new Point(arc.ToCity.X, arc.ToCity.Y));
        }
        
        private void DrawPath(Graphics dc, City startCity, City endCity)
        {
            Pen colorPen = new Pen(Color.DarkGray, 2);
            if (startCity.Collides) colorPen.Color = Color.Red;
            
            
            /*if (startCity.Distance > 100)
                colorPen.Color = System.Drawing.Color.Green;
            if (startCity.Distance > 200)
                colorPen.Color = System.Drawing.Color.Orange;
            if (startCity.Distance > 300)
                colorPen.Color = System.Drawing.Color.Red;*/
            dc.DrawLine(colorPen, new Point(startCity.X , startCity.Y ), new Point(endCity.X , endCity.Y ));
        }
       
        

    }
}
