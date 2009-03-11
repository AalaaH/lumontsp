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
        private double _localPheremone;


        public double Pheremone
        {
            get { return _pheremone; }
            set { _pheremone = value; }
        }
        public double LocalPheremone
        {
            get { return _localPheremone; }
            set { _localPheremone = value; }
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
        public Arc(City frm, City to, double oldPheremone)
        {
            FrmCity = frm;
            ToCity = to;
            Pheremone = oldPheremone;
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
        public object Clone()
        {
            Arc temp = new Arc();
            temp.FrmCity = (City)FrmCity.Clone();
            temp.ToCity = (City)ToCity.Clone();
            temp.Pheremone = Pheremone;
            return temp;
        }

        #endregion
        public void SwapToFrm()
        {
            City temp = new City();
            temp = (City)FrmCity.Clone();
            FrmCity = (City)ToCity.Clone();
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
    /// <summary>
    /// A list of arcs
    /// </summary>
    public class ArcPath : IComparable<ArcPath>
    {
        private List<Arc> _arcList = null;
        private double _totalDistance;
        private double _averageDistance;

        public double averageDistance
        {
            get { return _averageDistance; }
        }

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
                    _arcList.Clear();
                    foreach (Arc arc in value)
                        _arcList.Add(arc);
                }
                recalc();
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
        public ArcPath() 
        { 
            _arcList = new List<Arc>();
        }
        public ArcPath(List<Arc> arcList)
        {
            _arcList = new List<Arc>(arcList);
            recalc();
        }
        public void recalc()
        {
            CalculateTotalDistance();
            CalculateAverageDistance();
        }
        private void CalculateAverageDistance()
        {
            _averageDistance = _totalDistance / _arcList.Count();
        }

        #region IComparable<ArcPath> Members

        int IComparable<ArcPath>.CompareTo(ArcPath other)
        {
            return this.totalDistance.CompareTo(other.totalDistance);
            throw new NotImplementedException();
        }

        public int CompareTo(ArcPath other)
        {
            return this.totalDistance.CompareTo(other.totalDistance);
        }

        #endregion
    }
}
