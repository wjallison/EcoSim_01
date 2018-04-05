using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim_01
{
    public class Coordinates
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
        public Coordinates iterVect(int i)
        {
            if (i == 0) { return new Coordinates(x + 1, y); }
            else if (i == 1) { return new Coordinates(x, y + 1); }
            else if (i == 2) { return new Coordinates(x - 1, y); }
            else if (i == 3) { return new Coordinates(x, y - 1); }
            else { return new Coordinates(x, y); }
        }

        public bool Equals(Coordinates c)
        {
            if (x == c.x && y == c.y) { return true; }
            else { return false; }
        }
    }

    public class PathfindingTile
    {
        public Tile t;
        //vect is to record direction from which the tile was accessed
        public Coordinates vect;
        //vect may be replaced by the following:
        public int dir;
        public Coordinates coord;
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

    public class Ship
    {
        public string name;
        public string id;

        public Coordinates coord;
        public int ticsToTravel;
        public int progress;
        public int holdSize;
        public int holdingSize;
        IDictionary<Commodity, int> cargo;
        public int health;
        public float firepower;
        public float manpower;
        //art asset
        public string graphicsFileLocation;

        public void PathFind(List<Tile> destList, Map map)
        {
            //List<List<PathfindingTile>> activeList = new List<List<PathfindingTile>>();
            PathfindingTile startTile = new PathfindingTile();
            List<PathfindingTile> activeList = new List<PathfindingTile>();
            List<List<PathfindingTile>> fullList = new List<List<PathfindingTile>>();
            //List<Tile> destinations = destList;

            List<Coordinates> destCoords = new List<Coordinates>();

            foreach(Tile d in destList) { destCoords.Add(d.coord); }

            //Build list<list<PathfindingTile>> of entire map
            for (int i = 0; i < map.tileSet.Count(); i++)
            {
                fullList.Add(new List<PathfindingTile>());
                for (int j = 0; j < map.tileSet[0].Count(); j++)
                {
                    fullList[i].Add(new PathfindingTile(map.tileSet[i][j], -1));
                }
            }

            //Add starting position to active list
            activeList.Add(fullList[coord.x][coord.y]);


            while(destCoords.Count() > 0)
            {
                for (int activeIndex = 0; activeIndex < activeList.Count(); activeIndex++)
                {
                    if (activeList[activeIndex].counter == 0)
                    {
                        //check if neighbor is in activelist.
                            //If not, add to activelist and assign vector.
                        //check if neighbor is a destination.  If so, remove from destination list


                        //Check if neighbor is in activelist                        
                        for (int i = 0; i<4; i++)
                        {
                            int xP = activeList[activeIndex].coord.iterVect(i).x;
                            int yP = activeList[activeIndex].coord.iterVect(i).y;

                            bool inListAlready = false;

                            for(int checkIndex = 0; checkIndex < activeList.Count(); checkIndex++)
                            {
                                if (activeList[checkIndex].coord.Equals(activeList[activeIndex].coord.iterVect(i)))
                                {
                                    inListAlready = true;
                                }
                            }

                            if (!inListAlready)
                            {
                                //add to active list
                                activeList.Add(fullList[xP][yP]);
                                //assign direction from which it was accessed
                                activeList.Last().dir = i;
                                
                                //Check if it's a destination
                                for(int destInd = 0; destInd < destCoords.Count(); destInd++)
                                {
                                    if (destCoords[destInd].Equals(activeList.Last().coord))
                                    {
                                        destCoords.RemoveAt(destInd);
                                        break;
                                    }
                                }
                            }
                            //if (t.coord.Equals(fullList[xP][yP]))
                            //{

                            //}
                        }
                        
                    }

                    activeList[activeIndex].counter--;
                }
            }
            
        }

        //public bool test(List<PathfindingTile> active, PathfindingTile current)
        //{
            
        //}
    }

    public class Commodity
    {
        string name;
        int sizePUnit;
        int minCost, maxCost;
        float avgCost;

    }

    public class Building
    {
        string name;
        int ticsToProduce;
        int progress;
    }
}
