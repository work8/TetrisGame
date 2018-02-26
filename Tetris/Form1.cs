using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private const int FormX = 12;
        private const int FormY = 24;

        public Form1()
        {
            InitializeComponent();

            InitializeMap();

            
            
        }

        #region Initialize map
        private void InitializeMap()
        {
            Panel mapPanel = new Panel();
            this.Controls.Add(mapPanel);
            mapPanel.Location = new Point(12, 12);
            mapPanel.Size = new Size(FormX * 20, FormY * 20);
            mapPanel.Padding = new Padding(0);
            PictureBox[,] mapBox = new PictureBox[FormX, FormY];

            for (int y = 0; y < FormY; y++)
            { 
                for (int x=0; x<FormX; x++)
                    {
                    mapBox[x, y] = new PictureBox();
                    mapBox[x, y].Visible = false;
                    mapPanel.Controls.Add(mapBox[x, y]);
                    mapBox[x, y].Size = new Size(20, 20);
                    mapBox[x, y].Image = Tetris.Properties.Resources.ShapeImage;
                    mapBox[x, y].Location = new Point(0 + x * 20, 0 + y * 20);
                    //mapBox[x, y].
                    mapBox[x, y].Visible = true;
                }
            }
        
        }

        #endregion


    }
}
