﻿using System;
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
        GBLibrary.Tool.LogManager logmanager = new GBLibrary.Tool.LogManager(@"c:\temp\tetris\", GBLibrary.Tool.LogManager.LogType.Daily, "", "");
        private Map thisMap ;
        private Timer MainTimer; // 내리는 이벤트를 발생하는 Timer
        private Timer ServeTimer; //지속적으로 화면갱신을 위한 Timer
        private bool isExist = false;
        private Shape mainShape;
        public Panel mapPanel = new Panel();
        public enum Direction { Left,Right,Down,Up }
        public enum ShapeType { A=0,B,C,D,E,F,G}
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

        #endregion


        private void UpdateImage()
        {
            #region draw image

            for (int y = 0; y < thisMap.FormRow; y++)
            {
            
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
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeBImage;
                            break;
                        case 3:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeCImage;
                            break;
                        case 4:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeDImage;
                            break;
                        case 5:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeEImage;
                            break;
                        case 6:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeFImage;
                            break;
                        case 7:
                            mapBox[y, x].Image = Tetris.Properties.Resources.ShapeGImage;
                            break;
                    }

                }

                
            }

            //thisMap.outputArray();
            //Console.WriteLine("executed!!!!!!");

            #endregion

        }

        


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {if(e.KeyCode==Keys.P)
            {

            }


            if (mainShape == null)
            {
                if (Keys.S == e.KeyCode)
                {
                    MessageBox.Show("START");
                    thisMap.reDraw();

                    MainTimer = new Timer();
                    MainTimer.Tick += MainTimer_Tick1;
                    MainTimer.Interval = 300;
                    MainTimer.Start();
                    ServeTimer = new Timer();
                    ServeTimer.Tick += ServeTimer_Tick;
                    ServeTimer.Interval = 80;
                    ServeTimer.Start();

                    return;
                }
            }

            else
            {
                logmanager.writeLine(e.KeyCode.ToString());
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
                    case Keys.Up:
                        if (isPossible(Direction.Up))
                        {
                            DeleteDrawingOriginalPosition();
                            mainShape.rotate();
                            
                        }
                        
                        break;
                    
                }
               
                CalculateDrawingPosition(e.KeyCode);
                

                
            } 



        }

        private void ServeTimer_Tick(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void DeleteDrawingOriginalPosition()
        {
            for (int row = 0; row < mainShape.lengthRow; row++)
            {
                for (int col = 0; col < mainShape.lengthCol; col++)
                {
                    if((mainShape.PointCol + mainShape.LeftPosition < 0)|| (mainShape.PointCol+mainShape.RightPosition >thisMap.FormCol ))
                    {
                        break;
                    }
                    if (0 <= mainShape.PointRow + row)
                    {
                        //Check that the point was 0 or not , if there wasn't 0  , the place point will be 0.
                        if (mainShape.size[row, col] != 0)
                            if (thisMap.FormCol > mainShape.PointCol + col)
                            {
                                thisMap.mapArray[mainShape.PointRow + row, mainShape.PointCol + col] = 0;

                            }

                            
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
                    if ((mainShape.PointCol + mainShape.LeftPosition < 0) || (mainShape.PointCol + mainShape.RightPosition > thisMap.FormCol))
                    {
                        break;
                    }

                    

                    

                    if ((0 <= mainShape.PointRow + row) &&(mainShape.PointRow + row < thisMap.FormRow))
                    {

                        if (mainShape.size[row, col] != 0) {
                             if (thisMap.FormCol > mainShape.PointCol + col)
                            { 
                                thisMap.mapArray[mainShape.PointRow + row, mainShape.PointCol + col] = mainShape.size[row, col];
                            }

                            
                        }

                    }
                }
            }
        }


        private void MainTimer_Tick1(object sender, EventArgs e)
        {
             
          if(isExist==false)
            {
                if(thisMap.isFinish()==true)
                {
                    MainTimer.Stop();
                    mainShape = null;
                    MessageBox.Show("Game Over");
                    return; 
                }
                

                // Check Shape object was created.
                Console.WriteLine("Create Shape");
                Random generateShape = new Random();
                
                switch (generateShape.Next(0,8))
                {
                    case 1:
                        mainShape = new ShapeTypeA();
                        break;

                    case 2:
                        mainShape = new ShapeTypeB();
                        break;
                    case 3:
                        mainShape = new ShapeTypeC();
                        break;
                    case 4:
                        mainShape = new ShapeTypeD();
                        break;
                    case 5:
                        mainShape = new ShapeTypeE();
                        break;
                    case 6:
                        mainShape = new ShapeTypeF();
                        break;
                    case 7:
                        mainShape = new ShapeTypeG();
                        break;
                }
                                                
                isExist = true; 
            }
           else
            {
                Form1_KeyDown(sender, new KeyEventArgs(Keys.Down));                
            }
        

        }

        private bool isPossible(Direction tempDir)
        {
            //START 버튼을 누르지않았을때는 실행이 안된도록
            if (isExist == false)
                return false;

            

            if (tempDir == Direction.Down)
            {
                //아직 도형이 다 안내려온 상태에서는 x축이 허용하는 범위내에서는 이동이 가능하도록 설정
                //it is setted 
                if (mainShape.PointRow + mainShape.DownPosition < 0)
                    return true;

                //메인길이의 마지막을 확인해야되지 않나..
                if (mainShape.PointRow + mainShape.DownPosition + 1 < thisMap.FormRow)
                {

                    for (int col = 0; col < mainShape.lengthCol; col++)
                    {
                        //if (mainShape.PointRow + mainShape.DownPosition < 0)
                        //{
                        //    break;
                        //}

                        //좌항은 메인 Shape의 object값이 0인지 아닌지 확인 , 우항은 전체 맵에서 해당 값에 데이터가 있는지 확인
                        if (mainShape.size[mainShape.DownPosition, col] != 0 && (thisMap.mapArray[mainShape.PointRow + mainShape.DownPosition + 1, mainShape.PointCol  + col] != 0))
                        //if(thisMap.mapArray[mainShape.PointX + x, mainShape.PointY + 1] !=0 && (thisMap.mapArray[mainShape.PointX + x, mainShape.PointY] != 0))
                        {
                            return false;
                        }
                    }

                    return true;
                }


            }

            else if (tempDir == Direction.Left)
            {
                logmanager.writeLine("mainShape.PointCol:" + mainShape.PointCol + "\t mainShape.LeftPosition :" + mainShape.LeftPosition);
                if (mainShape.PointCol + mainShape.LeftPosition - 1 >= 0)
                {


                    for (int row = 0; row < mainShape.lengthRow; row++)
                    {
                        if(mainShape.PointRow + row <0)
                        {
                            continue;
                        }


                        if ((mainShape.size[row, mainShape.LeftPosition] != 0) && (thisMap.mapArray[mainShape.PointRow + row, mainShape.PointCol + mainShape.LeftPosition - 1] != 0))
                        //if (thisMap.mapArray[mainShape.PointX - 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX , mainShape.PointY +y] != 0))
                        {
                            logmanager.writeLine("row : " + row + "\t mainShape.LeftPosition:" + mainShape.LeftPosition + "\t mainShape.PointRow+row:" + mainShape.PointRow
                               + "\t mainShape.pointCol + mainShape.leftPosition -1 :" + mainShape.PointCol + (mainShape.LeftPosition - 1));


                            return false;
                        }

                    }

                    return true;


                }
          

            }
            else if (tempDir == Direction.Right)
            {
                logmanager.writeLine("mainShape.PointCol + mainShape.RightPosition:" + mainShape.PointCol + mainShape.RightPosition + "\t thisMap.FormCol :" + thisMap.FormCol);
                if (mainShape.PointCol + mainShape.RightPosition + 1 < thisMap.FormCol)
                {

                    for (int row = 0; row < mainShape.lengthRow; row++)
                    {
                        if (mainShape.PointRow + row < thisMap.FormCol)
                        {
                            continue;
                        }

                        if ((mainShape.size[row, mainShape.RightPosition] != 0) && (thisMap.mapArray[mainShape.PointRow + row, mainShape.PointCol + mainShape.RightPosition + 1] != 0))
                        //if (thisMap.mapArray[mainShape.PointX + 1, mainShape.PointY + y] != 0 && (thisMap.mapArray[mainShape.PointX, mainShape.PointY + y] != 0))
                        {
                            return false;
                        }
                    }

                    return true;


                }

            }
            else if (tempDir == Direction.Up)
            {
                Shape postShape = mainShape.Getpostshape();

                if (postShape.PointCol + postShape.LeftPosition + 1 >= 0)
                {
                    if (postShape.PointCol + postShape.RightPosition + 1 < thisMap.FormCol)
                    {
                        for (int row = 0; row < postShape.lengthRow; row++)
                        {
                            for(int col = 0; col <postShape.lengthCol; col++) { 
                            if(mainShape.size[row,col] !=0)
                                {
                                    continue;
                                }
                            if ((postShape.size[row, col] != 0) && (thisMap.mapArray[postShape.PointRow + row, postShape.PointCol + col] != 0))
                            {
                                return false;
                            }

                            }
                        }
                        return true;
                    }
                }
 
            }


            return false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}