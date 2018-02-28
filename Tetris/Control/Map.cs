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
        public  int FormX
        {
            get;set;
        }
        public  int FormY
        {
            get; set;
        }

        public int[,] mapArray;
        
        public Map()
        {
            FormX = 12;
            FormY = 24;
            mapArray = new int[FormX, FormY];
            for (int y = 0; y < FormY; y++)
            {
                for (int x = 0; x < FormX; x++)
                {
                    mapArray[x, y] = 0;            
                   
                }
            }

        }

        public void outputArray()
        {            
            for (int y = 0;  y < this.FormY; y++)
            {
                
                for (int x = 0; x < this.FormX; x++)
                {
                    Console.Write(this.mapArray[x, y] + "\t");
                }
                Console.WriteLine();
            }

        }
        
    }
}
