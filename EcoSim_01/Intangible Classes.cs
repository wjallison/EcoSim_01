using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim_01
{
    class Coordinates
    {
        public int x, y;
        public int[] c = new int[2];
        public int graphicsX, graphicsY;

        public void set(int i,int j)
        {
            x = i; y = j;
            c[0] = i; c[1] = j;

            graphicsX = x * (GlobalClass1.graphicTileSize +1);
            graphicsY = y * (GlobalClass1.graphicTileSize+1);
        }
        public Coordinates() { }

        public Coordinates(int i, int j)
        {
            x = i; y = j;
            c[0] = i; c[1] = j;

            graphicsX = x * (GlobalClass1.graphicTileSize + 1);
            graphicsY = y * (GlobalClass1.graphicTileSize + 1);
        }

        public Coordinates iterVect(Coordinates c,int i)
        {
            if (i == 0) { return new Coordinates(c.x + 1, c.y); }
            else if (i == 1) { return new Coordinates(c.x, c.y + 1); }
            else if (i == 2) { return new Coordinates(c.x - 1, c.y); }
            else if (i == 3) { return new Coordinates(c.x, c.y - 1); }
            else { return new Coordinates(c.x, c.y); }
        }
    }

    class PathfindingTile
    {
        public Tile t;
        //vect is to record direction from which the tile was accessed
        public Coordinates vect;
        public int counter;
        public bool touched = false;
        public bool destination;

        public PathfindingTile()
        {

        }

        public PathfindingTile(Tile tIn, int dir, bool touching = false)
        {
            t = tIn;


            if(t.passable != 10)
            {
                counter = t.passable;
            }
            else { counter = -1; }

            if (dir == 0) { vect.set(1, 0); }
            else if(dir == 1) { vect.set(0, 1); }
            else if(dir == 2) { vect.set(-1, 0); }
            else if(dir == 3) { vect.set(0, -1); }
            else { vect.set(0, 0); }

            touched = touching;
        }

        public void Touch(int dir)
        {
            counter = t.passable;

            if (dir == 0) { vect.set(1, 0); }
            else if (dir == 1) { vect.set(0, 1); }
            else if (dir == 2) { vect.set(-1, 0); }
            else if (dir == 3) { vect.set(0, -1); }
            else { vect.set(0, 0); }

            touched = true;
        }
    }

    class Ship
    {
        string name;
        int id;

        public Coordinates coord;
        int ticsToTravel;
        int progress;
        int holdSize;
        int holdingSize;
        IDictionary<Commodity, int> cargo;
        int health;
        float firepower;
        float manpower;
        //art asset

        public void PathFind(List<Tile> destList, Map map)
        {
            //List<List<PathfindingTile>> activeList = new List<List<PathfindingTile>>();
            List<PathfindingTile> activeList = new List<PathfindingTile>();
            List<List<PathfindingTile>> fullList = new List<List<PathfindingTile>>();
            List<Tile> destinations = destList;

            //Build list<list> of entire map
            for (int i = 0; i < map.tileSet.Count(); i++)
            {
                fullList.Add(new List<PathfindingTile>());
                for (int j = 0; j < map.tileSet[0].Count(); j++)
                {
                    fullList[i].Add(new PathfindingTile(map.tileSet[i][j], -1));
                }
            }

            activeList.Add(fullList[coord.x][coord.y]);

            while(destinations.Count() > 0)
            {
                foreach (PathfindingTile p in activeList)
                {
                    if(p.counter == 0)
                    {
                        //
                    }



                    p.counter--;
                }
            }
            
        }
    }

    class Commodity
    {
        string name;
        int sizePUnit;
        int minCost, maxCost;
        float avgCost;

    }

    class Building
    {
        string name;
        int ticsToProduce;
        int progress;
    }
}
