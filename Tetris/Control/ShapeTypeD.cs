using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeD : Shape
    {
        private int[,] shape = { { 0,0,4,0 },
                                      { 0,0,4,0 },
                                      { 0,4,4,0 },
                                      { 0,0,0,0 } };

        public ShapeTypeD()
        {
            shapeBox = shape;
            calculatePosition();
        }
    }
}
