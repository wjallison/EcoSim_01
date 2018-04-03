﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EcoSim_01
{
    class Map
    {
        public List<List<Tile>> tileSet = new List<List<Tile>>();
        public List<Island> islandList = new List<Island>();

        public string baseMapLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/MapBackground.jpg";
        public System.Drawing.Image fullMapImage;// = Image.FromFile(baseMapLocation);
        System.Drawing.Graphics gra;

        public string debugging;


        public bool Includes(Coordinates c)
        {
            if(c.x < tileSet.Count() && c.y < tileSet[0].Count())
            {
                return true;
            }
            else { return false; }
        }

        public void InitializeMapImage()
        {
            fullMapImage = Bitmap.FromFile(baseMapLocation);
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
            Bitmap bit = new Bitmap(t.localCanvas);
            gra.DrawImage(bit, new Rectangle(new Point(t.coord.graphicsX, t.coord.graphicsY),new Size(GlobalClass1.graphicTileSize,GlobalClass1.graphicTileSize)));
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

    class Tile
    {
        public int x, y;
        public Coordinates coord;
        //passable: pathfinding cost for passing through tile.  1 minimum, 9 maximum, 10 impassable
        public int passable;

        //Art Asset
        protected string imgLocation = System.IO.Directory.GetCurrentDirectory() + "/ArtAssets/Tiles/";
        public Image localCanvas;
        Graphics gra;



        


    }

    class SeaTile : Tile
    {
        public string type;
        //public bool passable;
        public List<Ship> occupants;

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
            localCanvas = Image.FromFile(imgLocation);

            //Console.Write(localCanvas.Height);

        }
    }

    class LandTile : Tile
    {
        string type;
        //building art asset
        string buildingType;

        

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

            localCanvas = Image.FromFile(imgLocation);
        }
    }

    class HarborTile : Tile
    {
        List<Ship> occupants;

        public HarborTile(int i, int j)
        {
            x = i;
            y = j;
            coord.set(i, j);

            passable = 5;

            imgLocation += "Harbor.jpg";

            localCanvas = Image.FromFile(imgLocation);
        }




        
    }
}
