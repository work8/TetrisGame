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
        private int CenterX = 1;
        private int CenterY = 2;

        public override void rotate()
        {
            throw new NotImplementedException();
        }
    }
}
