using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace EcoSim_01
{
    public class Map
    {
        public List<List<Tile>> tileSet = new List<List<Tile>>();
        List<Island> islandList = new List<Island>();

        public string baseMapLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/MapBackground.jpg";
        public System.Drawing.Image fullMapImage;// = Image.FromFile(baseMapLocation);
        System.Drawing.Graphics gra;

        public string debugging;


        bool Includes(Coordinates c)
        {
            if(c.x < tileSet.Count() && c.y < tileSet[0].Count())
            {
                return true;
            }
            else { return false; }
        }

        public void InitializeMapImage()
        {
            fullMapImage = Image.FromFile(baseMapLocation);
            gra = Graphics.FromImage(fullMapImage);

            for (int i = 0; i < tileSet.Count(); i++)
            {
                for (int j = 0; j < tileSet[0].Count(); j++)
                {
                    DrawTile(tileSet[i][j]);
                }
            }
            //debugging = Convert.ToString(tileSet[1][1].coord.graphicsX);
            //DrawTile(tileSet[0][0]);
            //DrawTile(tileSet[1][1]);
        }

        public void RefreshMapImage()
        {
            fullMapImage = Image.FromFile(baseMapLocation);
            gra = Graphics.FromImage(fullMapImage);
            for (int i = 0; i < tileSet.Count(); i++)
            {
                for (int j = 0; j < tileSet[0].Count(); j++)
                {
                    DrawTile(tileSet[i][j]);
                }
            }
        }

        public void DrawTile(Tile t)
        {
            //Bitmap bit = new Bitmap(t.localCanvas);
            //gra.DrawImage(bit, new Rectangle(new Point(t.coord.graphicsX, t.coord.graphicsY),new Size(GlobalClass1.graphicTileSize,GlobalClass1.graphicTileSize)));


            Image bit = Image.FromFile(t.imgLocation);

            //gra.DrawImage(t.localCanvas, new Rectangle(new Point(t.coord.graphicsX, t.coord.graphicsY), new Size(GlobalClass1.graphicTileSize, GlobalClass1.graphicTileSize)));

            gra.DrawImage(bit, 
                new Rectangle(
                    new Point(t.coord.graphicsX, t.coord.graphicsY), 
                    new Size(GlobalClass1.graphicTileSize, GlobalClass1.graphicTileSize)));
        }

        public void DrawPathTestShip(Ship s)
        {
            Image bit = Image.FromFile(s.graphicsFileLocation);

            gra.DrawImage(bit,
                new Rectangle(
                    new Point(s.coord.graphicsX + GlobalClass1.graphicTileSize/3, s.coord.graphicsY+GlobalClass1.graphicTileSize/4),
                    new Size(GlobalClass1.graphicTileSize / 3, GlobalClass1.graphicTileSize / 2)));
        }

        public bool IsHarbor(int i, int j)
        {
            
            if (tileSet[i][j].isHarbor)
            {
                return true;
            }
            else { return false; }
        }
    }



    class Island
    {
        List<Tile> associatedTiles = new List<Tile>();
        List<Building> buildingList = new List<Building>();

        bool forSale;
        bool active;
        bool playerOwned;

        int money;
        IDictionary<Commodity, int> commoditiesHeld;
        IDictionary<Commodity, int> commodityBuyPrice;
        IDictionary<Commodity, int> commoditySellPrice;


    }


    [XmlInclude(typeof(LandTile))]
    [XmlInclude(typeof(SeaTile))]
    [XmlInclude(typeof(HarborTile))]
    public class Tile
    {
        public int x, y;
        public Coordinates coord;
        //passable: pathfinding cost for passing through tile.  1 minimum, 9 maximum, 10 impassable
        public int passable;
        public bool isHarbor = false;
        public List<Ship> occupants;

        //Art Asset
        public string imgLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/Tiles/";
        //public Bitmap localCanvas;
        //Graphics gra;

    }



    public class SeaTile : Tile
    {
        public string type;
        //public bool passable;

        public SeaTile(int i,int j,int pass)
        {
            type = "g";
            x = i;
            y = j;
            passable = pass;
            //coord.set(i, j);
            coord = new Coordinates(i, j);

            imgLocation += "Ocean 0 2.jpg";
            //imgLocation = "Ocean.jpg";
            //localCanvas = (Bitmap)Image.FromFile(imgLocation);

            //Console.Write(localCanvas.Height);

        }

        public SeaTile() { }
    }

    public class LandTile : Tile
    {
        string type;
        //building art asset
        string buildingType;


        public LandTile() { }
        public LandTile(int i,int j, string t)
        {
            type = t;
            x = i;
            y = j;
            //coord.set(i, j);
            coord = new Coordinates(i, j);

            passable = 10;

            if (t == "barren")
            {
                imgLocation += "Barren.jpg";
            }
            else if (t == "field")
            {
                imgLocation += "Field.jpg";
            }
            else if (t == "hills")
            {
                imgLocation += "Hills.jpg";
            }
            else if (t == "hillsGold")
            {
                imgLocation += "HillsGold.jpg";
            }
            else if (t == "hillsIron")
            {
                imgLocation += "HillsIron.jpg";
            }
            else if (t== "wetField")
            {
                imgLocation += "WetField.jpg";
            }
            else
            {

            }

            //localCanvas = (Bitmap)Image.FromFile(imgLocation);
        }
    }

    public class HarborTile : Tile
    {
        List<Ship> occupants;

        public HarborTile() { }
        public HarborTile(int i, int j)
        {
            x = i;
            y = j;
            isHarbor = true;
            //coord.set(i, j);
            coord = new Coordinates(i, j);

            passable = 5;

            imgLocation += "Harbor.jpg";

            //localCanvas = (Bitmap)Image.FromFile(imgLocation);
        }




        
    }
}
