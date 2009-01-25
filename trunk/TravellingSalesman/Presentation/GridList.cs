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
    public partial class GridList : UserControl
    {
        public GridList()
        {
            InitializeComponent();
        }

        public void SetData(List<City> cities)
        {
            this.dgvList.DataSource = cities;
        }
    }
}
