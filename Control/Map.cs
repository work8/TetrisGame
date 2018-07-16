using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.Control
{
    public class Map
    {
        public  int FormCol
        {
            get;set;
        }
        public  int FormRow
        {
            get; set;
        }

        public int[,] mapArray;
        
        public Map()
        {
            #region Map 초기화

            
            FormCol = 12;
            FormRow = 24;
            mapArray = new int[FormRow, FormCol];
            for (int y = 0; y < FormRow; y++)
            {
                for (int x = 0; x < FormCol; x++)
                {
                    mapArray[y, x] = 0;            
                   
                }
            }
            #endregion
        }



        public void outputArray()
        {            
            for (int y = 0;  y < this.FormRow; y++)
            {
                
                for (int x = 0; x < this.FormCol; x++)
                {
                    Console.Write(this.mapArray[y, x] + "\t");
                }
                Console.WriteLine();
            }

        }

        public bool isFinish()
        {
            for (int col = 0;  col<mapArray.GetLength(1); col++)
            {
                if(mapArray[0, col] != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void reDraw()
        {
            for (int row = 0; row < mapArray.GetLength(0); row++) { 
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    mapArray[row, col] = 0;
                }
            
            }
            return; 
       }
    }
}
