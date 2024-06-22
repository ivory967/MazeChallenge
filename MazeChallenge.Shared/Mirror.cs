using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeChallenge.Shared
{
    public class Mirror
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; } // Right(R) of Left (L)
        public Enumerables.MirrorType MirrorType { get; set; }
        public char ReflectiveSide { get; set; } //Top (T) or Bottom (B)
    }
}
