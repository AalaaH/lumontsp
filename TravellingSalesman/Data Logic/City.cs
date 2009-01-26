using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellingSalesman.Data_Logic
{
    // data logic - represents a city (node)
    public class City
    {
        private string _name;
        private int _xPos;
        private int _yPos;
        
        private double _distance;
        private double _cost;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        public int X
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        public int Y
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        /// <summary>
        /// Represents the distance to the next city
        /// </summary>
        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public City()
        {
        }

        public City(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name; 
        }


    }
}
