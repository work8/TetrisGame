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
            mapPanel.Size = new Size(thisMap.FormCol * 20, thisMap.FormRow * 20);
            mapPanel.Padding = new Padding(0);
            this.Controls.Add(mapPanel);
            mapBox = new PictureBox[thisMap.FormRow, thisMap.FormCol];

            for (int y = 0; y < thisMap.FormRow; y++)
            {
                for (int x = 0; x < thisMap.FormCol; x++)
                {
                    mapBox[y, x] = new PictureBox();
                    mapBox[y, x].Visible = false;
                    mapPanel.Controls.Add(mapBox[y, x]);
                    mapBox[y, x].Size = new Size(20, 20);
                    mapBox[y, x].Image = Tetris.Properties.Resources.ShapeImage;
                    mapBox[y, x].Location = new Point(0 + x * 20, 0 + y * 20);
                    mapBox[y, x].Visible = true;

                }
            }

            UpdateImage();





            


        }

        private void UpdateImage()
        {
            Console.WriteLine("updateImage Executed");
            for (int y = 0; y < thisMap.FormRow; y++)
            {
                Console.WriteLine("updateImage Executed- 1");
                for (int x = 0; x < thisMap.FormCol; x++)
                {
                    switch (thisMap.mapArray[y, x])
                    {
                        case 0:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeImage;
                            break;
                        case 1:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeAImage;
                            break;
                        case 2:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeImage;
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
                        if (isPossible(Direction.Left))
                        {
                            DeleteDrawingOriginalPosition();
                            mainShape.left();
                        }
                            break;
                    case Keys.Right:
                        if (isPossible(Direction.Right))
                        {
                            DeleteDrawingOriginalPosition();
                            mainShape.right();
                        }
                        break;

                    case Keys.Down:
                        if (isPossible(Direction.Down)) {
                            DeleteDrawingOriginalPosition();
                            mainShape.down();

                        }
                        else
                        {
                            isExist = false;
                        }
                        break;
                }
                CalculateDrawingPosition(e.KeyCode);
                UpdateImage();


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
        private void DeleteDrawingOriginalPosition()
        {
            for (int row = 0; row < mainShape.lengthRow; row++)
            {
                for (int col = 0; col < mainShape.lengthCol; col++)
                {
                    if (0 <= mainShape.PointRow - row -1)
                    {
                        //Check that the point was 0 or not , if there wasn't 0  , the place point will be 0.
                        if (mainShape.size()[col, mainShape.lengthRow - row - 1] != 0)
                            thisMap.mapArray[mainShape.PointCol + col, mainShape.PointRow - row] = 0;

                    }
                }
            }
        }
        private void CalculateDrawingPosition(Keys temp)
        {
          
            for (int row = 0; row < mainShape.lengthRow; row++)
            {
                for (int col = 0; col < mainShape.lengthCol; col++)
                {
                    if ((0 <= mainShape.PointRow + row) &&(mainShape.PointRow + row < thisMap.FormRow))
                    {
                        

                            thisMap.mapArray[mainShape.PointCol + col, mainShape.PointRow + row] = mainShape.size()[col, row];

                        
                    }
                }
            }
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
                Form1_KeyDown(sender, new KeyEventArgs(Keys.Down));                
            }
        

        }

        private bool isPossible(Direction tempDir)
        {
            if (isExist == false)
             return false;
            if (mainShape.PointRow < 0)
                return true;
            

            if (tempDir == Direction.Down)
            { 
                if (mainShape.PointRow +1  < thisMap.FormRow)
                    {
                                                
                            for(int col =0; col<mainShape.lengthCol; col++)
                            {//좌항은 메인 Shape의 object값이 0인지 아닌지 확인 , 우항은 전체 맵에서 해당 값에 데이터가 있는지 확인
                            if (mainShape.size()[col, mainShape.lengthRow - 1] != 0 && (thisMap.mapArray[mainShape.PointCol + col, mainShape.PointRow + 1] != 0))
                            //if(thisMap.mapArray[mainShape.PointX + x, mainShape.PointY + 1] !=0 && (thisMap.mapArray[mainShape.PointX + x, mainShape.PointY] != 0))
                            {
                                return false;
                                }
                            }

                            return true;
                    }

                
             }

            else if(tempDir == Direction.Left)
            {
                if (mainShape.PointCol -1 >= 0)
                {
                    
                        
                        for (int row = 0; row < mainShape.lengthRow; row++)
                        {
                            if ((mainShape.size()[0,row] != 0) && (thisMap.mapArray[mainShape.PointCol - 1, mainShape.PointRow +row ] !=0))                            
                            //if (thisMap.mapArray[mainShape.PointX - 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX , mainShape.PointY +y] != 0))
                            {
                                return false;
                            }
                        }

                        return true;
                    

                }

            }
            else if(tempDir == Direction.Right)
            {
                if (mainShape.PointCol + 1 <= thisMap.FormCol - mainShape.lengthCol )
                {

                    for (int row = 0; row < mainShape.lengthRow; row++)
                        {
                            if ((mainShape.size()[mainShape.lengthCol - 1, row] != 0) && (thisMap.mapArray[mainShape.PointCol + mainShape.lengthCol ,row ] !=0))
                            //if (thisMap.mapArray[mainShape.PointX + 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX, mainShape.PointY + y] != 0))
                            {
                                return false;
                            }
                        }

                        return true;
                    

                }




            }

            return false;
            
            
        }

      
    }
}
