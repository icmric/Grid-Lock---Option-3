using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Grid_Lock___Option_3
{
    public partial class Form1 : Form
    {
        PictureBox[,] gameBoard = new PictureBox[7, 7];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int index = 1; //tracks where we are in the array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < j; j++) //rename j & i to x&y or something cleaner
                {
                    gameBoard[i, j] = (PictureBox)Controls.Find("pb" + (index).ToString(), true)[0];
                    index++;
                }
            }
            string[] startingConfigArray = File.ReadAllLines(@"StartingConfig.txt");
            int startingConfigindex = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; i < 7; i++)
                {
                    gameBoard[i, j].BackColor = Color.FromName(startingConfigArray[startingConfigindex]);
                    startingConfigindex++;
                }
            }
        }
    }
}
