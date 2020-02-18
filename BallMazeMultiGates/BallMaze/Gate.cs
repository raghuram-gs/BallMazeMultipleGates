using System;
using System.Collections.Generic;
using System.Text;

namespace BallMaze
{
    class Gate
    {
        internal int Direction { get; set; }

        internal Gate(int direction)
        {
            Direction = direction;
        }
    }
}
