﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeB : Shape
    {
        private int[,] shape = { { 0,0,0,0 },
                                      { 0,2,2,0 },
                                      { 0,2,2,0 },
                                      { 0,0,0,0 } };
        private int CenterX;
        private int CenterY;

        public override void rotate()
        {
            throw new NotImplementedException();
        }
    }
}
