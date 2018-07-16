﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
    public class ShapeTypeG : Shape
    {
        private int[,] shape = { { 0,0,0,0 },
                                      { 0,7,0,0 },
                                      { 7,7,7,0 },
                                      { 0,0,0,0 } };

        public ShapeTypeG()
        {
            shapeBox = shape;
            calculatePosition();
        }

    }
}