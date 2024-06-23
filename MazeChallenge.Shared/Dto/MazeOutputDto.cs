using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge.Shared.Dto
{
    public class MazeOutputDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Start_X { get; set; }
        public int Start_Y { get; set; }
        public int End_X { get; set; }
        public int End_Y { get; set; }
        public char Orientation { get; set; }


    }
}
