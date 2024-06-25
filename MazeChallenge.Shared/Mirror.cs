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

        public Mirror(int x, int y, char direction, Enumerables.MirrorType mirrorType, char reflectiveSide)
        {
            X = x;
            Y = y;
            Direction = direction;
            MirrorType = mirrorType;
            ReflectiveSide = reflectiveSide;
        }
        public char Reflect(char orientation)
        {
            if (ReflectiveSide =='B' || ReflectiveSide =='T')
            {
                return orientation switch
                {
                    'H' => 'V',
                    'V' => 'H',
                    _ => throw new InvalidOperationException()
                };
            }
            return orientation;
        }
    }
}
