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
            if (i == 0 && x < GlobalClass1.mapDim-1) { return new Coordinates(x + 1, y); }
            else if (i == 1 && y < GlobalClass1.mapDim-1) { return new Coordinates(x, y + 1); }
            else if (i == 2 && x > 0) { return new Coordinates(x - 1, y); }
            else if (i == 3 && y > 0) { return new Coordinates(x, y - 1); }
            else { return new Coordinates(x, y); }
        }

        public Coordinates InverseIterVect(int i)
        {
            if (i == 2) { return new Coordinates(x + 1, y); }
            else if (i == 3) { return new Coordinates(x, y + 1); }
            else if (i == 0) { return new Coordinates(x - 1, y); }
            else if (i == 1) { return new Coordinates(x, y - 1); }
            else { return new Coordinates(x, y); }
        }

        public bool BoolEqualCheck(Coordinates c)
        {
            if (x == c.x && y == c.y) { return true; }
            else { return false; }
        }
    }

    public class PathfindingTile
    {
        public Tile t;
        //vect is to record direction from which the tile was accessed
        public Coordinates vect = new Coordinates(0,0);
        //vect may be replaced by the following:
        public int dir;
        public Coordinates coord = new Coordinates(0,0);
        public int counter;
        public int finalCount;
        public bool touched = false;
        public bool destination;

        public PathfindingTile()
        {

        }
        

        public PathfindingTile(Tile tIn, int dir = -1, bool touching = false)
        {
            t = tIn;

            coord.set(t.coord.x, t.coord.y);


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
        IDictionary<Commodity, int> cargo = new Dictionary<Commodity, int>();
        public int health;
        public float firepower;
        public float manpower;

        //art asset
        public string graphicsFileLocation;

        //Decision making assets
        IDictionary<PathfindingTile, int> ports = new Dictionary<PathfindingTile, int>();

        public List<List<PathfindingTile>> courses = new List<List<PathfindingTile>>();

        public string PrintPorts()
        {
            string s = "";
            foreach (PathfindingTile p in ports.Keys)
            {
                s = s + "Harbor at: " + p.coord.x + ", " + p.coord.y + ": " + ports[p].ToString()+"/n";
            }
            return s;
        }

        public PathfindingTile ActiveSearch(List<PathfindingTile> active, Coordinates c)
        {
            foreach(PathfindingTile t in active)
            {
                if(t.coord.BoolEqualCheck(c))
                {
                    return t;
                }
            }
            return new PathfindingTile();
        }

        public void PathFind(List<Tile> destList, Map map, Coordinates startPt)
        {
            //List<List<PathfindingTile>> activeList = new List<List<PathfindingTile>>();
            PathfindingTile startTile = new PathfindingTile(map.tileSet[startPt.x][startPt.y]);
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


            int counter = 0;
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
                                if (activeList[checkIndex].coord.BoolEqualCheck(activeList[activeIndex].coord.iterVect(i)))
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
                                activeList.Last().finalCount = counter;
                                
                                //Check if it's a destination
                                for(int destInd = 0; destInd < destCoords.Count(); destInd++)
                                {
                                    if (destCoords[destInd].BoolEqualCheck(activeList.Last().coord))
                                    {
                                        ports.Add(activeList.Last(), activeList.Last().finalCount);
                                        courses.Add(new List<PathfindingTile>());
                                        courses.Last().Add(activeList.Last());
                                        destCoords.RemoveAt(destInd);
                                        break;
                                    }
                                }
                            }
                        }
                        
                    }
                    activeList[activeIndex].counter--;
                }
                counter++;
            }

            //Add paths to courses

            //foreach (Tile t in destList)
            for(int destInd = 0; destInd < courses.Count(); destInd++)
            {
                //courses.Add(new List<PathfindingTile>());
                //courses.Last().Add();
                Coordinates current = courses[destInd][0].coord;
                while (!current.BoolEqualCheck(coord))
                {

                    courses[destInd].Add(
                        ActiveSearch(
                            activeList,
                            courses[destInd].Last().coord.InverseIterVect(courses[destInd].Last().dir)
                            )
                            );
                    current = courses[destInd].Last().coord;
                }
                courses[destInd].Reverse();
            }


        }

        public int TradeRoute(Map map, Island destA, Island destB, Commodity c)
        {
            Ship hypotheticalShip = new Ship();
            //destX.associatedTiles[0] will always be the harbor tile
            hypotheticalShip.coord = new Coordinates(destA.associatedTiles[0].coord.x, destA.associatedTiles[0].coord.y);
            List<Tile> tempDestList = new List<Tile>();
            tempDestList.Add(destB.associatedTiles[0]);
            hypotheticalShip.PathFind(tempDestList, map, hypotheticalShip.coord);
            //hypotheticalShip.courses[0].Count() is now the distance from A to B

            int numerator = holdSize / c.sizePUnit * (destB.GetBuyPrice(c) - destA.GetSellPrice(c));



            //denominator is time from current position to A plus time from A to B
            int denominator;
            //denominator = PathFind()

            return numerator / denominator;
        }
    }

    public class Commodity
    {
        public string name;
        public int sizePUnit;
        public int minCost, maxCost;
        public float avgCost;

        public Commodity() { }
        public Commodity(string n, int sPU, int minC, int maxC)
        {
            name = n;
            sizePUnit = sPU;
            minCost = minC;
            maxCost = maxC;
        }

    }

    public class Building
    {
        string name;
        int ticsToProduce;
        int progress;
    }
}
