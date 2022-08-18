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
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++) //rename j & i to x&y or something cleaner
                {
                    gameBoard[i, j] = (PictureBox)Controls.Find("pb" + (index).ToString(), true)[0];
                    index++;
                }
            }
            List<string> startingConfigArray = new List<string>();
            StreamReader reader = new StreamReader(@"StartingConfig.csv");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                startingConfigArray.Add(line);
            }

            int startingConfigindex = 0;
            gameBoard[0, 0].BackColor = Color.FromName(startingConfigArray[startingConfigindex]);
            startingConfigindex++;
            for (int r = 0; r < 7; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    gameBoard[r, c].BackColor = Color.FromName(startingConfigArray[startingConfigindex]);
                    startingConfigindex++;

                }
            }

        }
        // handels Up and left movment
        private void MovePlus(object sender, EventArgs e, string colour, String move)
        {
            //loops thorugh gameboard checking all picture boxes one at a time from top left to bottom right
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int c = 0; c < 7; c++) //Coloums
                {
                    if (move == "Up")
                    {
                        if (r - 1 >= 0)
                        {
                            //Makes sure the square that colour will move into is blank
                            if (gameBoard[r, c].BackColor == Color.Green)
                            {
                                if (gameBoard[r - 1, c].BackColor == Color.White)
                                {
                                    gameBoard[r - 1, c].BackColor = Color.FromName(colour);
                                    gameBoard[r, c].BackColor = Color.White;
                                }
                            }
                        }
                    }
                    if (move == "Left")
                    {
                        if (c > 0)
                        {
                            if (gameBoard[r, c].BackColor == Color.Green && colour == "Green")
                            {
                                if (gameBoard[r, c - 1].BackColor == Color.White)
                                {
                                    gameBoard[r, c].BackColor = Color.White;
                                    gameBoard[r, c - 1].BackColor = Color.FromName(colour);
                                }
                            }
                            else if (gameBoard[r, c].BackColor != Color.Green && colour != "Green")
                            {
                                if (Convert.ToString(gameBoard[r, c + 1].BackColor) == colour && Convert.ToString(gameBoard[r + 1, c].BackColor) != colour)
                                {
                                    if (gameBoard[r, c - 1].BackColor == Color.White)
                                    {
                                        gameBoard[r, c].BackColor = Color.White;
                                        gameBoard[r, c - 1].BackColor = Color.FromName(colour);
                                    }
                                }
                            }

                        }
                    }
                
                }
            }
        }
        //deals with Right and Down movment. Scans from bottom left to top right to avoid the blocks riding the checker
        private void MoveMinus(object sender, EventArgs e, string color, String move)
        {
            bool moveLock = false; //Locks or unlocks movment
            //loops thorugh gameboard checking all pictireboxes one at a time
            for (int r = 6; r >= 0; r--) //Rows
            {
                for (int c = 6; c >= 0; c--) //Coloums
                {
                    if (Color.FromName(cbColour.Text) == Color.Green)
                    {
                        if (move == "Right")
                        {
                            if (c <= 6)
                            {
                                if (gameBoard[r, c].BackColor == Color.Green)
                                {
                                    if (gameBoard[r, c + 1].BackColor == Color.White)
                                    {
                                            gameBoard[r, c].BackColor = Color.White;
                                            gameBoard[r, c + 1].BackColor = Color.FromName(color);
                                    }
                                }
                            }
                        }
                        if (move == "Down")
                        {
                            if (r + 1 <= 5)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    //Makes sure the square that colour will move into is blank
                                    if (gameBoard[r, c].BackColor == Color.Green)
                                    {
                                        if (gameBoard[r + 1, c].BackColor == Color.White)
                                        {
                                            gameBoard[r + 1, c].BackColor = Color.FromName(color);
                                            gameBoard[r, c].BackColor = Color.White;

                                        }
                                    }
                                }

                            }
                        }


                    }
                }
            }
        }
        
        private void btnUp_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "Up";
            MovePlus(this, e, colour, move);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "Left";
            MovePlus(this, e, colour, move);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "Down";
            MoveMinus(this, e, colour, move);
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "Right";
            MoveMinus(this, e, colour, move);
        }
    }

}


