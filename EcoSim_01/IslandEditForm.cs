using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoSim_01
{
    public partial class IslandEditForm : Form
    {
        IDictionary<Commodity, int> commodDict = new Dictionary<Commodity, int>();

        public IslandEditForm()
        {
            InitializeComponent();
        }
        public IslandEditForm(ref Island i)
        {
            InitializeComponent();

            if (i.active)
            {
                activeCheckBox.Checked = true;

            }
            else { }


        }
    }
}
