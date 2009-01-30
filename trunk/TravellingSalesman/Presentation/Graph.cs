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
            TotalDistance = new List<double>();
            
            
        }


        #region Data members
        const string yLabel = "Distance";
        const string xLabel = "Iteration";
        #endregion

        #region Public methods




        #endregion

        public void Clear()
        {
            (this.CreateGraphics()).Clear(Color.White);
        }

        private List<double> _totalDistance;
        public List<double> TotalDistance
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
        
        
        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics dc)//, ref List<double> totalDistance)

        {        
            Point graphPoint = new Point();
            Pen myPen = new Pen(Color.Black, 1);
            Pen arrow = new Pen(Color.Black, 1);
            arrow.EndCap = LineCap.ArrowAnchor;
            SolidBrush myBrush = new SolidBrush(Color.Black);
            Font myFont = new Font("Arial", 10);
            Font myFont8 = new Font("Arial", 8);
            double yScale = 0;
            int offset = 10;
            int canvasSizeX = Width - 2 * offset;
            int canvasSizeY = Height - 2 * offset;
            int yLabelWidth = Convert.ToInt32(dc.MeasureString(yLabel, myFont).Width);
            int yLabelHeight = Convert.ToInt32(dc.MeasureString(yLabel, myFont).Height);
            int xlabelHeight = Convert.ToInt32(dc.MeasureString(xLabel, myFont).Height);
            int xlabelWidth = Convert.ToInt32(dc.MeasureString(xLabel, myFont).Width);
            Rectangle graphSpace = new Rectangle(offset + yLabelWidth, offset, canvasSizeX - yLabelWidth, canvasSizeY - xlabelHeight);
            
            dc.DrawString(yLabel, myFont, myBrush, offset, Height / 2 - yLabelHeight);
            dc.DrawString(xLabel, myFont, myBrush, Width / 2 - xlabelWidth, Height - offset - xlabelHeight);

            dc.DrawLine(arrow, graphSpace.Left, graphSpace.Bottom, graphSpace.Left, graphSpace.Top);
            dc.DrawLine(arrow, graphSpace.Left, graphSpace.Bottom, graphSpace.Right, graphSpace.Bottom);
            if (TotalDistance.Count > 0)
            {
                yScale = graphSpace.Height / TotalDistance.First();
                for (int i = 0; i < TotalDistance.Count; i++)
                {
                    if(TotalDistance.Count>graphSpace.Width) graphPoint.X = Convert.ToInt32(graphSpace.Left + 1 + i/(1+(TotalDistance.Count/graphSpace.Width)));
                    else graphPoint.X = Convert.ToInt32(graphSpace.Left + 1 + i);
                    graphPoint.Y = Convert.ToInt32(graphSpace.Top + graphSpace.Height - TotalDistance[i] * yScale);
                    if (i == 0) myPen.Color = Color.Black;
                    else if (TotalDistance[i] > TotalDistance[i - 1]) myPen.Color = Color.Red;
                    else if (TotalDistance[i] < TotalDistance[i - 1]) myPen.Color = Color.Green;
                    else myPen.Color = Color.Black;
                   
                    dc.DrawEllipse(myPen, graphPoint.X, graphPoint.Y, 1, 1);
                    
                    myPen.Color = Color.Black;
                }
                dc.DrawString(Convert.ToString(Math.Round(TotalDistance.Last(),2)), myFont8, myBrush, graphPoint.X+1,graphPoint.Y-6);
            }
        }
        

    }
}
