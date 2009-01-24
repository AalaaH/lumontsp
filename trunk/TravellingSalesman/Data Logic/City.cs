using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellingSalesman.Data_Logic
{
    // data logic - represents a city (node)
    public class City
    {
        private int _xPos;
        private int _yPos;
        private int _cost;
        private string _name;

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

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
