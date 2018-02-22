using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
   public abstract class Shape
    {
        private int[,] shape;
        private int CenterX;
        private int CenterY;

        public abstract void rotate();
        
    }
}
