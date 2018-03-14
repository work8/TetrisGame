using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeF : Shape
    {
        private int[,] shape = { { 0,0,0,0 },
                                      { 0,0,6,6 },
                                      { 0,6,6,0 },
                                      { 0,0,0,0 } };
        public ShapeTypeF()
        {
            shapeBox = shape;
            calculatePosition();
        }
    }
}
