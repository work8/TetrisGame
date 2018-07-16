using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeE : Shape
    {
        private int[,] shape = { { 0,0,0,0 },
                                      { 5,5,0,0 },
                                      { 0,5,5,0 },
                                      { 0,0,0,0 } };

        public ShapeTypeE()
        {
            shapeBox = shape;
            calculatePosition();
        }
    }
}
