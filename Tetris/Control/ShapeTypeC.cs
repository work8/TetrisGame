using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeC : Shape
    {
        private int[,] shape = { { 0,3,0,0 },
                                      { 0,3,0,0 },
                                      { 0,3,3,0 },
                                      { 0,0,0,0 } };


        public ShapeTypeC()
        {
            shapeBox = shape;
            calculatePosition();
        }
    }
}
