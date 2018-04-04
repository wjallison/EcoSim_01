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
    public partial class MapBuildingScreen : Form
    {
        Map buildingMap;

        string brush;
        
        //palatte image
        Image pal;

        XmlSerializer xs;// = new XmlSerializer(typeof(Map));
        //[XmlInclude(typeof(LandTile))]
        //public class Tile { }

        public MapBuildingScreen()
        {
            InitializeComponent();

            buildingMap = new Map();
            //Set all tiles to SeaTile 
            for(int i = 0; i < 10; i++)
            {
                buildingMap.tileSet.Add(new List<Tile>());
                for (int j = 0; j < 10; j++)
                {
                    //buildingMap.tileSet[i][j] = new SeaTile(i, j, 1);
                    buildingMap.tileSet[i].Add(new SeaTile(i, j, 1));
                }
            }

            buildingMap.InitializeMapImage();

            mapBox.Image = buildingMap.fullMapImage;

            //label1.Text = buildingMap.debugging;



            //Build palatte box
            BuildPalatteBox();


            //xs = new XmlSerializer(typeof(Map));
            xs = new XmlSerializer(typeof(List<List<Tile>>));


        }

        public void BuildPalatteBox()
        {
            //ocean         //impassableOcean
            //field         //wet field
            //hills         //iron hills
            //gold hills    //barren
            //shallow beach //deep beach
            //harbor        //mountain

            string baseLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/PalatteBackground.jpg";
            pal = Bitmap.FromFile(baseLocation);
            Graphics gra = Graphics.FromImage(pal);

            string path = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/Tiles/";
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(50, 50));

            gra.DrawImage(Image.FromFile(path + "Ocean 0 2.jpg"), rect);
            rect.X = 51; 
            gra.DrawImage(Image.FromFile(path + "OceanImpassable.jpg"), rect);

            rect.X = 0; rect.Y = 51;
            gra.DrawImage(Image.FromFile(path + "Field.jpg"), rect);
            rect.X = 51;
            gra.DrawImage(Image.FromFile(path + "WetField.jpg"), rect);

            rect.X = 0; rect.Y = 102;
            gra.DrawImage(Image.FromFile(path + "Hills.jpg"), rect);
            rect.X = 51;
            gra.DrawImage(Image.FromFile(path + "HillsIron.jpg"), rect);

            rect.X = 0; rect.Y = 153;
            gra.DrawImage(Image.FromFile(path + "HillsGold.jpg"), rect);
            rect.X = 51;
            gra.DrawImage(Image.FromFile(path + "Barren.jpg"), rect);

            rect.X = 0; rect.Y = 204;
            //gra.DrawImage(Image.FromFile(path + ""))
            rect.X = 51;
            //

            rect.X = 0; rect.Y = 255;
            gra.DrawImage(Image.FromFile(path + "Harbor.jpg"), rect);
            rect.X = 51;
            //

            palatteBox.Image = pal;
        }

        private void palatteBox_Click(object sender, EventArgs e)
        {
            
        }

        private void palatteBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Left Side
            if (e.X < 51)
            {
                if (e.Y < 51)
                {
                    brush = "ocean";
                }
                else if(e.Y < 102)
                {
                    brush = "genericField";
                }
                else if(e.Y < 153)
                {
                    brush = "hills";
                }
                else if(e.Y < 204)
                {
                    brush = "goldHills";
                }
                else if(e.Y < 255)
                {
                    brush = "shallowBeach";
                }
                else if (e.Y < 306)
                {
                    brush = "harbor";
                }
            }
            else
            {
                if (e.Y < 51)
                {
                    brush = "impassableOcean";
                }
                else if (e.Y < 102)
                {
                    brush = "wetField";
                }
                else if (e.Y < 153)
                {
                    brush = "ironHills";
                }
                else if (e.Y < 204)
                {
                    brush = "barren";
                }
                else if (e.Y < 255)
                {
                    brush = "deepBeach";
                }
                else if (e.Y < 306)
                {
                    brush = "mountain";
                }
            }
        }

        private void mapBox_MouseClick(object sender, MouseEventArgs e)
        {
            int i = (e.X - 1) / (GlobalClass1.graphicTileSize+1);
            int j = (e.Y - 1) / (GlobalClass1.graphicTileSize + 1);
            switch (brush)
            {
                case "ocean":
                    buildingMap.tileSet[(e.X-1)/ (GlobalClass1.graphicTileSize + 1)][(e.Y-1)/ (GlobalClass1.graphicTileSize + 1)] = new SeaTile(i,j,1);
                    break;
                //case "impassableOcean":
                //    buildingMap.tileSet[(e.X - 1) / 51][(e.Y - 1) / 51] =
                case "genericField":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "field");
                    break;
                case "hills":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "hills");
                    break;
                case "goldHills":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "hillsGold");
                    break;
                case "shallowBeach":
                    //
                    break;
                case "harbor":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new HarborTile(i,j);
                    break;
                case "impassableOcean":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new SeaTile(i, j, 10);
                    break;
                case "wetField":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "wetField");
                    break;
                case "ironHills":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "hillsIron");
                    break;
                case "barren":
                    buildingMap.tileSet[(e.X - 1) / (GlobalClass1.graphicTileSize + 1)][(e.Y - 1) 
                        / (GlobalClass1.graphicTileSize + 1)] = new LandTile(i, j, "barren");
                    break;
                case "deepBeach":
                    //
                    break;
                case "mountain":
                    //
                    break;
            }

            buildingMap.RefreshMapImage();
            mapBox.Image = buildingMap.fullMapImage;
            //mapchange
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.TextWriter tw = new System.IO.StreamWriter(saveFileDialog1.FileName);
                //xs.Serialize(tw, buildingMap);

                xs.Serialize(tw, buildingMap.tileSet);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName != "")
            {
                using (var sr = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    //buildingMap = (Map)xs.Deserialize(sr);
                    buildingMap.tileSet = (List<List<Tile>>)xs.Deserialize(sr);

                    buildingMap.RefreshMapImage();

                    mapBox.Image = buildingMap.fullMapImage;
                }

            }
        }
    }
}
