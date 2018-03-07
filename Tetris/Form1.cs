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
        public enum Direction { Left,Right,Down }
        private Direction currentDirection = Direction.Down;
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

                }

                
            }

            thisMap.outputArray();
            Console.WriteLine("executed!!!!!!");

         
            
        }


        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (mainShape == null)
            {
                if (Keys.S == e.KeyCode)
                {
                    MessageBox.Show("START");

                    MainTimer = new Timer();
                    MainTimer.Tick += MainTimer_Tick1;
                    MainTimer.Interval = 500;
                    MainTimer.Start();
                    return;
                }
            }

            else
            { 
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        mainShape.left();
                        break;
                    case Keys.Right:
                        mainShape.right();
                        break;
                    case Keys.Down:
                        mainShape.down();
                        break;
                }
            }



        }
        
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            //if (e.KeyChar.Equals('S'))
            //{
            //    MessageBox.Show("START");

            //    MainTimer = new Timer();
            //    MainTimer.Tick += MainTimer_Tick1;
            //    MainTimer.Interval = 100;
            //    MainTimer.Start();

            //}
                        
        }

        private void MainTimer_Tick1(object sender, EventArgs e)
        {
             
          if(isExist==false)
            { // Check Shape object was created.
                Console.WriteLine("Create Shape");
                mainShape = new ShapeTypeA();
                isExist = true; 
            }
           else
            {
                //Check that that is possible to move Shape object.
                if (isPossible(currentDirection))
                {
                    for (int row = 0; row < mainShape.size().GetLength(1); row++)
                    {
                        for (int col = 0; col < mainShape.size().GetLength(0); col++)
                        {
                            if (0 <= mainShape.PointY - row)
                            {
                                
                                thisMap.mapArray[mainShape.PointX + col, mainShape.PointY - row] = mainShape.size()[col,mainShape.lengthY - row - 1];

                            }
                        }
                    }
                    
                    mainShape.PointY++;
                    for (int row= 0 ; row < mainShape.size().GetLength(1); row++) { 
                        for(int col= 0; col < mainShape.size().GetLength(0); col++)
                        {
                            if(0<=mainShape.PointY - row)
                            {
                                if(thisMap.mapArray[mainShape.PointX + col , mainShape.PointY - row] == 0) { 

                                thisMap.mapArray[mainShape.PointX + col, mainShape.PointY - row] = mainShape.size()[col, mainShape.lengthY - row - 1];

                               }
                            }
                        }
                    }
                    
                }
                else
                {
                    isExist = false;

                }
                currentDirection = Direction.Down;
                UpdateImage();
            }
        

        }

        private bool isPossible(Direction tempDir)
        {
            if (tempDir == Direction.Down) { 
                if ((0<=mainShape.PointX)&& (mainShape.PointX + 1 < thisMap.FormX - mainShape.size().GetLength(1)))
                {
                    if ((0 <= mainShape.PointY) && (mainShape.PointY +1  < thisMap.FormY))
                    {
                        Console.WriteLine("MainShape.pointY : {0} , thisMap.FormY : {1}", mainShape.PointY, thisMap.FormY);

                        
                            for(int x =0; x<mainShape.size().GetLength(1); x++)
                            {
                            if (mainShape.size()[x,mainShape.size().GetLength(1) - 1] != 0 && (thisMap.mapArray[mainShape.PointX + x, mainShape.PointY + 1] != 0))
                            //if(thisMap.mapArray[mainShape.PointX + x, mainShape.PointY + 1] !=0 && (thisMap.mapArray[mainShape.PointX + x, mainShape.PointY] != 0))
                            {
                                return false;
                                }
                            }

                            return true;
                    }

                }
            }

            else if(tempDir == Direction.Left)
            {
                if ((0 <= mainShape.PointX) && (mainShape.PointX + 1 < thisMap.FormX - mainShape.size().GetLength(1)))
                {
                    if ((0 <= mainShape.PointY) && (mainShape.PointY + 1 < thisMap.FormY))
                    {
                        
                        for (int y = 0; y < mainShape.size().GetLength(2); y++)
                        {
                            if (thisMap.mapArray[mainShape.PointX - 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX , mainShape.PointY +y] != 0))
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                }

            }
            else if(tempDir == Direction.Right)
            {
                if ((0 <= mainShape.PointX) && (mainShape.PointX + 1 < thisMap.FormX - mainShape.size().GetLength(1)))
                {
                    if ((0 <= mainShape.PointY) && (mainShape.PointY + 1 < thisMap.FormY))
                    {
                        Console.WriteLine("MainShape.pointY : {0} , thisMap.FormY : {1}", mainShape.PointY, thisMap.FormY);


                        for (int y = 0; y < mainShape.size().GetLength(2); y++)
                        {
                            if (thisMap.mapArray[mainShape.PointX + 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX, mainShape.PointY + y] != 0))
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                }




            }

            return false;
            
            
        }

      
    }
}
