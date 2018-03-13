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

        private int CenterCol;
        private int CenterRow;

        public int PointCol
        {
            get;
            set;
        }
        public int PointRow
        {
            get;
            set;
        }
          public int lengthCol
        {
            get { return shapeBox.GetLength(0); }
        }

        public int lengthRow
        {
            get { return shapeBox.GetLength(1); }
        }
        
        public abstract void rotate();
        
        public void down()
        {
            PointRow++;
        }

        public void left()
        {
            PointCol--;
        }

        public void right()
        {
            PointCol++;
        }

        public int[,] size()
        {
            return shapeBox;
        }

  

    }
}
