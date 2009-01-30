using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalesman.Business_Logic;

namespace TravellingSalesman.Data_Logic
{
    /// <summary>
    /// Represents a path (arc) between two nodes (cities)
    /// </summary>
    public class Arc
    {
        #region Data Members
        private City _frmCity;
        private City _toCity;
        private double _distance;
        private double _gradient;
        private double _yintercept;


        private bool _collides;

        public City FrmCity
        {
            get { return _frmCity; }
            set { 
                _frmCity = value;
                Recalc();
            }
        }
        
        public City ToCity
        {
            get { return _toCity; }
            set { 
                _toCity = value;
                Recalc();
            }
        }

        public double Dist
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public double Yintercept
        {
            get { return _yintercept; }
            set { _yintercept = value; }
        }

        public double Grad
        {
            get { return _gradient; }
            set { _gradient = value; }
        }

        public bool Collides
        {
            get { return _collides; }
            set { _collides = value; }
        }

        public double MinX
        {
            get { return Math.Min(FrmCity.X, ToCity.X); }
        }

        public double MaxX
        {
            get { return Math.Max(FrmCity.X, ToCity.X); }
        }


        public double MinY
        {
            get { return Math.Min(FrmCity.Y, ToCity.Y); }
        }

        public double MaxY
        {
            get { return Math.Max(FrmCity.Y, ToCity.Y); }
        }

        #endregion


        public Arc()
        {

        }

        public Arc(City frm, City to)
        {
            FrmCity = frm;
            ToCity = to;
            Recalc();
        }

        private void Recalc()
        {
            if (ToCity == null) return;
            Dist = MathHelper.getDistance(this);
            Grad = MathHelper.getGrad(this);
            Yintercept = MathHelper.getYIntercept(this);
            Collides = false;
        }

        public bool inRegionX(double min, double max)
        {
            if ((FrmCity.X >= min && FrmCity.X <= max) && (ToCity.X >= min && ToCity.X <= max)) return true;
            return false;
        }

        public bool inRegionY(double min, double max)
        {
            if ((FrmCity.Y >= min && FrmCity.Y <= max) && (ToCity.Y >= min && ToCity.Y <= max)) return true;
            return false;
        }


    }
}
