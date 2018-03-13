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
        private int CenterCol = 1;
        private int CenterRow = 2;
        
        
       public ShapeTypeA()
        {
            PointCol = 5;
            PointRow = -3;

            shapeBox = shape;
        }


        public override void rotate()
        {
        
        }
 
    }
}
