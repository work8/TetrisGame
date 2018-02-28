using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Control;
namespace Tetris
{
    public partial class Form1 : Form
    {
        private Map thisMap ;
        private Timer MainTimer;
        private bool isExist = false;
        private Shape mainShape;
        public Panel mapPanel = new Panel();
        
        public PictureBox[,] mapBox
        {
            get;
            set;
        }





        public Form1()
        {
            InitializeComponent();

            InitializeMap();

            
            

            
            
        }

        #region Initialize map
        private void InitializeMap()
        {
            thisMap = new Map();
           
            mapPanel.Location = new Point(12, 12);
            mapPanel.Size = new Size(thisMap.FormX * 20, thisMap.FormY * 20);
            mapPanel.Padding = new Padding(0);
            this.Controls.Add(mapPanel);
            mapBox = new PictureBox[thisMap.FormX, thisMap.FormY];

            for (int y = 0; y < thisMap.FormY; y++)
            {
                for (int x = 0; x < thisMap.FormX; x++)
                {
                    mapBox[x, y] = new PictureBox();
                    mapBox[x, y].Visible = false;
                    mapPanel.Controls.Add(mapBox[x, y]);
                    mapBox[x, y].Size = new Size(20, 20);
                    mapBox[x, y].Image = Tetris.Properties.Resources.ShapeImage;
                    mapBox[x, y].Location = new Point(0 + x * 20, 0 + y * 20);
                    mapBox[x, y].Visible = true;

                }
            }

            UpdateImage();





            


        }

        private void UpdateImage()
        {
            Console.WriteLine("updateImage Executed");
            for (int y = 0; y < thisMap.FormY; y++)
            {
                Console.WriteLine("updateImage Executed- 1");
                for (int x = 0; x < thisMap.FormX; x++)
                {
                    switch (thisMap.mapArray[x, y])
                    {
                        case 0:
                            mapBox[x, y].Image = Tetris.Properties.Resources.ShapeImage;
                            break;
                        case 1:
                            mapBox[x, y].Image = Tetris.Properties.Resources.ShapeAImage;
                            break;
                        case 2:
                            mapBox[x, y].Image = Tetris.Properties.Resources.ShapeImage;
                            break;  
                    }

                   // Console.WriteLine("x : {0} , y: {1}", x, y);
                }

                
            }

            thisMap.outputArray();
            Console.WriteLine("executed!!!!!!");

         
            
        }


        #endregion

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
            if (e.KeyChar.Equals('S'))
            {
                MessageBox.Show("START");

                MainTimer = new Timer();
                MainTimer.Tick += MainTimer_Tick1;
                MainTimer.Interval = 1000;
                MainTimer.Start();

            }
            


        }

        private void MainTimer_Tick1(object sender, EventArgs e)
        {
            Console.WriteLine("execute");
          if(isExist==false)
            {
                mainShape = new ShapeTypeA();
                isExist = true; 
            }
           else
            {
                if (isPossible())
                {
                    
                    for (int row= 0 ; row < mainShape.size().GetLength(1); row++) { 
                        for(int col= 0; col < mainShape.size().GetLength(0); col++)
                        {
                            if(0<=mainShape.PointY - row)
                            {
                                thisMap.mapArray[mainShape.PointX + col, mainShape.PointY - row] = mainShape.size()[row, col];
                                
                            }
                        }
                    }
                    
                }
                Console.WriteLine("clear");
                mainShape.PointY++;
                UpdateImage();
            }
        

        }

        private bool isPossible()
        {
            
            return true;
        }
    }
}
