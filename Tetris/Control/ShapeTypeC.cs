using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeC : Shape
    {
        private int[,] shape = { { 0,1,0,0 },
                                      { 0,1,0,0 },
                                      { 0,1,1,0 },
                                      { 0,0,0,0 } };
        private int CenterX;
        private int CenterY;

        public override void rotate()
        {
            throw new NotImplementedException();
        }
    }
}
