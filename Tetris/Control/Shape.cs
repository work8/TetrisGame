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
          public int lengthX
        {
            get { return shapeBox.GetLength(0); }
        }

        public int lengthY
        {
            get { return shapeBox.GetLength(1); }
        }
        
        public abstract void rotate();
        
        public void down()
        {
            PointY++;
        }

        public void left()
        {
            PointX--;
        }

        public void right()
        {
            PointX++;
        }

        public int[,] size()
        {
            return shapeBox;
        }

  

    }
}
