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
        Map testingMap = new Map();

        XmlSerializer xs;

        bool shipPlaced = false;

        public PathfindingTesting()
        {
            InitializeComponent();

            xs = new XmlSerializer(typeof(List<List<Tile>>));

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
            /* Steps:
             * 
             * Create ship object on tile clicked
             * 
             * Set list of 'islands' (harbors) as destinations
             * 
             * Initialize pathfinding
             * 
             * Report:
             * distance to each
             * path to each
             *      highlight tiles?  
             *      different colors for different harbors?  
             *      Click on harbor to highlight path?
             * Time for algorithm to run
             * 
             */
            int i = (e.X - 1) / (GlobalClass1.graphicTileSize + 1);
            int j = (e.Y - 1) / (GlobalClass1.graphicTileSize + 1);

            if (!shipPlaced) //Default, creates ship and runs above steps
            {

            }
            else
            {
                if (testingMap.IsHarbor(i,j)) //clicked on harbor tile, highlights path to harbor
                {

                }
            }
        }

        public void PrepareReport()
        {

        }
    }
}
