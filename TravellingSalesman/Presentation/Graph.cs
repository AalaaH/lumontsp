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
        private double _numberOfIteratoins;
        public double numberOfIteratoins
        {
            get
            {
                return _numberOfIteratoins;
            }
            set
            {
                _numberOfIteratoins = value;
                Refresh();
            }
        }
        
        private void DrawGraph(Graphics dc)
        {
            Pen myPen = new Pen(Color.Black, 5);
            dc.DrawArc(myPen, 10, 10, 100, 100, 90, 10);
            
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }        
    }
}
