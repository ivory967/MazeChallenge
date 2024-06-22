using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge.Shared
{
    public class Map
    {
        public int Width { get; set; } // X converted into width
        public int Height { get; set; } // Y converted into height
        public int X { get; set; } //start X
        public int Y { get; set; } // start Y
        public char Orientation { get; set; } //start orientation Vertical (V) or Horizontal (H)

        public List<Mirror> MapMirrors { get; set; }

    }
}
