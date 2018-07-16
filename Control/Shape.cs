using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Control
{
   public class Shape
    {
        protected int[,] shapeBox;

        


        private int CenterCol;
        private int CenterRow;

        public int LeftPosition
        {
            get; set;
        }
        public int RightPosition
        {
            get; set;
        }
        public int UpPosition
        {
            get; set;
        }
        public int DownPosition
        {
            get; set;
        }

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

        public int[,] size
        {
            get { return shapeBox; }
        }


        public Shape()
        {
            PointCol = 5;
            PointRow = -3;
            

        }

        public Shape(int[,] newshapebox, int PointCol , int PointRow) 
        {
            this.PointRow = PointRow;
            this.PointCol = PointCol;
            this.shapeBox = newshapebox;
            calculatePosition();
        }

        public Shape Getpostshape()
        {
            int[,] tempShape = new int[this.lengthRow, this.lengthCol];

            for (int col = 0; col < this.lengthCol; col++)
            {
                for (int row = 0; row < this.lengthRow; row++)
                {
                    tempShape[col, lengthRow - 1 - row] = shapeBox[row, col];
                }
            }

            return new Shape(tempShape, this.PointCol,this.PointRow);
        }
        

        public  void rotate()
        {
            int[,] tempShape = new int[this.lengthRow, this.lengthCol];

            for (int col = 0; col < this.lengthCol; col++)
            { 
                for (int row = 0; row < this.lengthRow; row++)
                {
                    tempShape[col, lengthRow - 1 - row] = shapeBox[row, col];
                }
            }

            shapeBox = tempShape;


            calculatePosition();
        }

        protected void calculatePosition()
        {
            LeftPosition = 65536;
            RightPosition = 0;
            UpPosition = 0;
            DownPosition = 0;

            for (int row= 0; row <lengthRow; row++) { 
                for(int col = 0; col < lengthCol; col ++)
                    {
                        if(shapeBox[row,col]!=0)
                        {
                            if (col <LeftPosition)
                                LeftPosition = col;
                            if (col > RightPosition || RightPosition == 0)
                            RightPosition = col;
                            if (row <= UpPosition)
                            UpPosition = row;
                            if (row > DownPosition || DownPosition == 0)
                            DownPosition = row;
                        }
                    }
            }
        }
        
        
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



      

  

    }
}
