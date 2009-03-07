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
    public class Arc : IComparable<Arc>
    {
        #region Data Members
        private City _frmCity;
        private City _toCity;
        private double _distance;
        private double _gradient;
        private double _yintercept;

        #region ACO
        private double _pheremone;

        public double Pheremone
        {
            get { return _pheremone; }
            set { _pheremone = value; }
        }
        #endregion


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



        #region IComparable Members

        public static Comparison<Arc> DistComparison =
        delegate(Arc p1, Arc p2)
        {
            return p1.Dist.CompareTo(p2.Dist);
        };



        #endregion
        public void SwapToFrm()
        {
            City temp = new City();
            temp = FrmCity;
            FrmCity = ToCity;
            ToCity = temp;
        }

        #region IComparable<Arc> Members

        public int CompareTo(Arc other)
        {
            //return Name.CompareTo(other.na);
            throw new NotImplementedException();
        }

        #endregion
    }
    public class ArcPath : IComparable<ArcPath>
    {
        private List<Arc> _arcList;
        private double _totalDistance;

        public double totalDistance
        {
            get { return _totalDistance; }
        }
        public List<Arc> List
        {
            set
            {
                if (_arcList == null) _arcList = new List<Arc>(value);
                else
                {
                    _arcList.Clear;
                    foreach (Arc arc in value)
                        _arcList.Add(arc);
                }
                CalculateTotalDistance();
            }
            get
            {
                return (_arcList);
            }
        }
        private void CalculateTotalDistance()
        {

            _totalDistance = 0;
            foreach (Arc arc in _arcList)
            {
                _totalDistance += arc.Dist;
            }
        }

    }

}
