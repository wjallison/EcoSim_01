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
        public List<Island> islandList = new List<Island>();

        public string baseMapLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/MapBackground.jpg";
        internal System.Drawing.Image baseMapImage;
        internal System.Drawing.Image fullMapImage;// = Image.FromFile(baseMapLocation);
        System.Drawing.Graphics gra;

        public string debugging;

        //public Image GetMapImage() { return fullMapImage; }

        //public void SetMapImage(Image i) { fullMapImage = i; }

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
            baseMapImage = Image.FromFile(baseMapLocation);
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
            //Draw the tile
            Image bit = Image.FromFile(t.imgLocation);

            gra.DrawImage(bit, 
                new Rectangle(
                    new Point(t.coord.graphicsX, t.coord.graphicsY), 
                    new Size(GlobalClass1.graphicTileSize, GlobalClass1.graphicTileSize)));

            //Draw the numbers on the seatiles
            if (t.passable > 0)
            {
                //First, passability in upper left
                gra.DrawString(
                    t.passable.ToString(),
                    new Font("Arial", 2),
                    new SolidBrush(Color.Black),
                    new Point(t.coord.graphicsX, t.coord.graphicsY)
                    );

                //Second, the number of ships in the lower right
                if (t.occupants.Any())
                {
                    gra.DrawString(
                    t.occupants.Count().ToString(),
                    new Font("Arial", 2),
                    new SolidBrush(Color.Black),
                    new Point(t.coord.graphicsX + GlobalClass1.graphicTileSize / 2, t.coord.graphicsY + GlobalClass1.graphicTileSize / 2)
                    );
                }
                
            }
            
        }

        public void Highlight(PathfindingTile p, string color)
        {
            Image bit = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/Highlight" + color + ".png");

            gra.DrawImage(bit,
                new Rectangle(
                    new Point(p.coord.graphicsX, p.coord.graphicsY),
                    new Size(GlobalClass1.graphicTileSize, GlobalClass1.graphicTileSize)));
        }

        public void DrawPathTestShip(Ship s)
        {
            Image bit = Image.FromFile(s.graphicsFileLocation);

            gra.DrawImage(bit,
                new Rectangle(
                    new Point(s.coord.graphicsX + GlobalClass1.graphicTileSize/3, s.coord.graphicsY+GlobalClass1.graphicTileSize/4),
                    new Size(GlobalClass1.graphicTileSize / 3, GlobalClass1.graphicTileSize / 2)));
            //gra.DrawString()
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



    public class Island
    {
        public List<Tile> associatedTiles = new List<Tile>();
        public List<Building> buildingList = new List<Building>();

        public bool forSale;
        public bool active;
        public bool playerOwned;

        public int money;
        IDictionary<Commodity, int> commoditiesHeld;
        IDictionary<Commodity, int> commodityBuyPrice;
        IDictionary<Commodity, int> commoditySellPrice;

        public Island() { }
        public Island(HarborTile h)
        {
            associatedTiles.Add(h);
        }

        public void IslandBuilder(ref Map m)
        {
            //Note: must already have a harbor in associatedTiles!!!!!!!!!!!!!!!

            bool notDone = true;
            int islRf = associatedTiles[0].islandRef;

            while (notDone)
            {
                for (int i = 0; i < associatedTiles.Count(); i++)
                {
                    notDone = false;
                    for (int d = 0; d < 4; d++)
                    {
                        if(m.tileSet[associatedTiles[i].coord.iterVect(d).x][associatedTiles[i].coord.iterVect(d).y].passable == -1)
                        {
                            bool inListAlready = false;

                            //for (int checkIndex = 0; checkIndex < activeList.Count(); checkIndex++)
                            //{
                            //    if (activeList[checkIndex].coord.BoolEqualCheck(activeList[activeIndex].coord.iterVect(i)))
                            //    {
                            //        inListAlready = true;
                            //    }
                            //}

                            for(int checkIndex = 0; checkIndex < associatedTiles.Count(); checkIndex++)
                            {
                                if (associatedTiles[checkIndex].coord.BoolEqualCheck(associatedTiles[i].coord.iterVect(d)))
                                {
                                    inListAlready = true;
                                }
                            }

                            if (!inListAlready)
                            {
                                associatedTiles.Add(m.tileSet[associatedTiles[i].coord.iterVect(d).x][associatedTiles[i].coord.iterVect(d).y]);
                                associatedTiles.Last().islandRef = islRf;
                                m.tileSet[associatedTiles[i].coord.iterVect(d).x][associatedTiles[i].coord.iterVect(d).y].islandRef = islRf;
                                notDone = true;
                            }

                        }
                    }
                }

            }



        }

        public void AddCommodity(Commodity c, int num)
        {
            if (commoditiesHeld.Keys.Contains(c))
            {
                commoditiesHeld[c] += num;
            }
            commoditiesHeld.Add(c, num);

            //Refresh buy and sell prices
        }
        //public void RemoveCommodity(Commodity c, int num)
        //{

        //}
        

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
        public List<Ship> occupants = new List<Ship>();
        public int islandRef = -1;

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

            passable = -1;

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
        //List<Ship> occupants;

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
