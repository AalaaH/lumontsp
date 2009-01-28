using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TravellingSalesman.Presentation
{
    public partial class Graph : UserControl
    {
        public Graph()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            (this.CreateGraphics()).Clear(Color.White);
            this.BackColor = Color.Blue;
        }


        #region Data members

        #endregion

        #region Public methods




        #endregion

        public void Clear()
        {
            (this.CreateGraphics()).Clear(Color.White);
        }

        private double _totalDistance;
        public double totalDistance
        {
            get
            {
                return _totalDistance;
            }
            set
            {
                _totalDistance = value;
                Refresh();
            }
        }
        private double _iterationNumber;
        public double iterationNumber
        {
            get
            {
                return _iterationNumber;
            }
            set
            {
                _iterationNumber = value;
                Refresh();
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawGraph(e.Graphics);
        }
        
        private void DrawGraph(Graphics dc)
        {
            totalDistance = 123;
            iterationNumber = 1;

            Point graphPoint = new Point();
            Pen myPen = new Pen(Color.Black, 1);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            Font myFont = new Font("Arial", 12);
            double yScale = 0;
            int offset = 10;
            int canvasSizeX = Width-2*offset;
            int canvasSizeY = Height-2*offset;
            string yLabel = "Total Distance";
            string xLabel = "Iteration";
            int yLabelWidth = Convert.ToInt32(dc.MeasureString(yLabel, myFont).Width);
            int yLabelHeight = Convert.ToInt32(dc.MeasureString(yLabel, myFont).Height);
            int xlabelHeight = Convert.ToInt32(dc.MeasureString(xLabel, myFont).Height);
            int xlabelWidth = Convert.ToInt32(dc.MeasureString(xLabel, myFont).Width);
            Rectangle graphSpace = new Rectangle(offset + yLabelWidth, offset, canvasSizeX - yLabelWidth, canvasSizeY - xlabelHeight);
            yScale = graphSpace.Height / totalDistance;

            graphPoint.X = Convert.ToInt32(graphSpace.Left + iterationNumber);
            graphPoint.Y = Convert.ToInt32(graphSpace.Top + graphSpace.Height - totalDistance * yScale);
            dc.DrawEllipse(myPen, graphPoint.X, graphPoint.Y, 1, 1);
           
            dc.DrawString(yLabel, myFont, myBrush, offset, Height / 2-yLabelHeight);
            dc.DrawString(xLabel, myFont, myBrush, Width/2-xlabelWidth, Height-offset-xlabelHeight);
            dc.DrawRectangle(myPen, graphSpace);
        }
        

    }
}
