using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
   public abstract class Shape
    {
        protected  int[,] shapeBox;

        private int CenterX;
        private int CenterY;

        public int PointX
        {
            get;
            set;
        }
        public int PointY
        {
            get;
            set;
        }

        public abstract void rotate();
        
        public void down()
        {
            PointY++;
        }
        
        public int[,] size()
        {
            return shapeBox;
        }
        
    }
}
