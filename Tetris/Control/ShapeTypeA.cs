using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeA : Shape
    {
        private int[,] shape = { { 0,1,0,0 },
                                      { 0,1,0,0 },
                                      { 0,1,0,0 },
                                      { 0,1,0,0 } };
       
        
        
       public ShapeTypeA()
        {
            shapeBox = shape;
            calculatePosition();
        }

    }
}
