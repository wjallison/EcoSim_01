using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;

namespace EcoSim_01
{
    public partial class PathfindingTesting : Form
    {
        Map testingMap;

        XmlSerializer xs;

        public PathfindingTesting()
        {
            InitializeComponent();

            openFileDialog1.ShowDialog();

            if(openFileDialog1.FileName != "")
            {
                using (var sr = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    //buildingMap = (Map)xs.Deserialize(sr);
                    testingMap.tileSet = (List<List<Tile>>)xs.Deserialize(sr);

                    testingMap.RefreshMapImage();

                    mapBox.Image = testingMap.fullMapImage;
                }
            }
        }

        private void mapBox_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
