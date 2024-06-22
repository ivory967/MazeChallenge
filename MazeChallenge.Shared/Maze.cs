using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MazeChallenge.Shared.Enumerables;

namespace MazeChallenge.Shared
{
    public static class Maze
    {
       
        public static Map InputToMap(string[] lines)
        {
            var map = new Map();
            List<Mirror> mapMirror = new List<Mirror>();
            //first value need to be the start coordinates (i may need to validate the in are inside of the actual grid and cannot be larger than the actual grid)
            //line 0 is starting x and y
            var startCoords = lines[0].Split(",");
            char orientation = startCoords[1].Substring(startCoords[1].Length - 1)[0];
            int _x = int.Parse(startCoords[0]);
            int _y = int.Parse(startCoords[1].Substring(0, startCoords[1].Length - 1));

            //because we dont know where the mirrors end we need a for i to add all possible mirrors 
            List<int> brIndexes = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "--br--")
                    brIndexes.Add(i);
            }
            //add to mirrors not sure how many so let do a list;
            //we need to convert the mirror to coordenates and orientations
            //assuming only one coordinate was sent, if safe to say that mirrors will start at 2 (i should validate this throught the file)
            for (int i = 2; i < brIndexes[1]; i++)
            {
                mapMirror.Add(ConvertToMirror(lines[i]));
            }
            //lets get the size of the map
            var mapSize = lines[brIndexes.Last() - 1].Split(",");
            //lets fill the info of the map
            map.X = _x;
            map.Y = _y;
            map.MapMirrors = mapMirror;
            map.Width = int.Parse(mapSize[0].ToString());
            map.Height = int.Parse(mapSize[1].ToString());
            map.Orientation = orientation;
            //this will give us the map 
            return map;
        }
        private static Mirror ConvertToMirror(string line)
        {
            var parts = line.Split(',');
            int x = int.Parse(parts[0]);
            int y;
            MirrorType mirrortype;
            //so because the instructions says the that can bring nothing and be reflective both sides, we are going to try parse
            //this means that if parse is a number and dont have anything been reflective both sides
            if (int.TryParse(parts[1].ToString(), out y))
            {
                mirrortype = MirrorType.TwoSide;
            }
            else
            {
                //in this part i will add the missing letter to have both, since only two letters are been used should be fine.
                if (!parts[1].Contains("B"))
                {
                    parts[1] = string.Concat(parts[1], "T");
                }
                mirrortype = MirrorType.OneSide;
                y = int.Parse(parts[1].Substring(0, parts[1].Length - 2));
            }

            char direction = parts[1][parts[1].Length - 2];
            char reflectiveSide = mirrortype == MirrorType.OneSide ? parts[1][parts[1].Length - 1] : ' ';

            //create the mirror and add the mirror to the list
            return new Mirror()
            {
                X = x,
                Y = y,
                Direction = direction,
                MirrorType = mirrortype,
                ReflectiveSide = reflectiveSide
            };
        } 
        public static object GetLaserTrajectory(Map map)
        {
            int x = map.X, y = map.Y;
            char orientation = map.Orientation;
            char direction = 'R';
            while (true)
            {
                if (orientation == 'H' && direction == 'R')
                {
                    x++;
                }
                else if (orientation == 'H' && direction == 'L')
                {
                    x--;
                }
                else if (orientation == 'V' && direction == 'R')
                {
                    y++;
                }
                else { y--; }

                //we also need to catch if the pointer escape out of the grid
                if (x < 0 || x >= map.Width || y < 0 || y >= map.Height)
                {
                    return (x < 0 ? 0 : x, y < 0 ? 0 : y, orientation);
                }
                //check if the mirror exist on those coordinates
                //we need to check if the mirror let us go through or not

                foreach (var mirror in map.MapMirrors)
                {
                    if (mirror.X == x && mirror.Y == y)
                    {
                        if (mirror.MirrorType == MirrorType.TwoSide || (mirror.MirrorType == MirrorType.OneSide && (mirror.ReflectiveSide == 'B' && orientation == 'V') || (mirror.ReflectiveSide == 'T' && orientation == 'H')))
                        {
                            orientation = orientation == 'H' ? 'V' : 'H';
                            direction = mirror.Direction;
                        }
                    }
                }
            }
        }

        public static object GetLaserTrajectory(string[]fileContent)
        {
            //get the file info into the mapConverter (InputToMap);
            Map map = InputToMap(fileContent);
            //if map is null return something to let the user know.
            if (map == null) return "null map";
            //actual starting coordinates
            int x = map.X, y = map.Y;
            char orientation = map.Orientation;
            char direction = 'R';
            while (true)
            {
                //in this part we need to play a little bit with the orientation and direction to know if we are minus coordenates or adding
                if (orientation == 'H' && direction == 'R')
                {
                    x++;
                }
                else if (orientation == 'H' && direction == 'L')
                {
                    x--;
                }
                else if (orientation == 'V' && direction == 'R')
                {
                    y++;
                }
                else { y--; }

                //we also need to catch if the pointer escape out of the grid
                if (x < 0 || x >= map.Width || y < 0 || y >= map.Height)
                {
                    //i need to find a better way to return the value before get into the negative but for know no idea.
                    return (x < 0 ? 0 : x, y < 0 ? 0 : y, orientation);
                }
                //check if the mirror exist on those coordinates
                //we need to check if the mirror let us go through or not

                foreach (var mirror in map.MapMirrors)
                {
                    if (mirror.X == x && mirror.Y == y)
                    {
                        if (mirror.MirrorType == MirrorType.TwoSide || (mirror.MirrorType == MirrorType.OneSide && (mirror.ReflectiveSide == 'B' && orientation == 'V') || (mirror.ReflectiveSide == 'T' && orientation == 'H')))
                        {
                            orientation = orientation == 'H' ? 'V' : 'H';
                            direction = mirror.Direction;
                        }
                    }
                }
            }
        }
    }
}
