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
            //string[] startingConfigArray = File.ReadAllLines(@"StartingConfig.txt");
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
        private void MovePlus(object sender, EventArgs e, string color, String move)
        {
            bool moveLock = false; //Locks or unlocks movment
            //loops thorugh gameboard checking all pictireboxes one at a time
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int j = 0; j < 7; j++) //Coloums
                {
                    if (Color.FromName(cbColour.Text) == Color.Green)
                    {
                        if (move == "y-")
                        {
                            if (r - 1 >= 0)
                            { 
                                //Makes sure the square that colour will move into is blank
                                if (gameBoard[r, j].BackColor == Color.Green)
                                {
                                    if (gameBoard[r - 1, j].BackColor == Color.White)
                                    {
                                        gameBoard[r - 1, j].BackColor = Color.FromName(color);
                                        gameBoard[r, j].BackColor = Color.White;
                                    }
                                }
                            }
                        }
                        if (move == "right.")
                        {
                            if (r > 0)
                            {
                               //for (int i = 0; i < 4; i++)
                                //{
                                    if (gameBoard[r, j].BackColor == Color.Green)
                                    {
                                        if (gameBoard[r, j-2].BackColor == Color.White)
                                        {
                                            MessageBox.Show(Convert.ToString(r) + Convert.ToString(j));
                                            gameBoard[r, j--].BackColor = Color.Green;
                                                gameBoard[r, j].BackColor = Color.White;
                                               
                                        }   
                                    }
                                //}
                               
                            }
                        }
                        

                    }
                    /*
                        //check what colour is selected
                        if (gameBoard[r, j].BackColor == Color.FromName(cbColour.Text))
                        {
                            // prevents moving out of gameboard
                            if (r == 0)
                            {
                                moveLock = true;
                            }
                            //moves piece up one square
                            if (r > 0)
                            {
                                gameBoard[r - 1, j].BackColor = Color.FromName(color);
                                gameBoard[r, j].BackColor = Color.White;
                            }
                        }
                       */


                }
            }
        }//handels down and left movment. gots bottom right to top left to avoid pushing a block as far as it can
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
                        if (move == "right")
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
                        if (move == "y+")
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
        /*
        private void MoveDown(object sender, EventArgs e, string color)
        {
            bool moveLock = false; //Locks or unlocks movment
            //loops thorugh gameboard checking all pictireboxes one at a time
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int j = 0; j < 7; j++) //Coloums
                {
                    if (Color.FromName(cbColour.Text) == Color.Green)
                    {
                        if (r + 1 >= 0)
                        {
                            //Makes sure the square that colour will move into is blank
                            if (gameBoard[r, j].BackColor == Color.Green)
                            {
                                if (gameBoard[r + 1, j].BackColor == Color.White)
                                {
                                    gameBoard[r + 1, j].BackColor = Color.FromName(color);
                                    gameBoard[r, j].BackColor = Color.White;
                                }
                            }
                        }

                    }
                    else
                    {
                        //check what colour is selected
                        if (gameBoard[r, j].BackColor == Color.FromName(cbColour.Text))
                        {
                            // prevents moving out of gameboard
                            if (r == 0)
                            {
                                moveLock = true;
                            }
                            //moves piece up one square
                            if (r > 0)
                            {
                                gameBoard[r + 1, j].BackColor = Color.FromName(color);
                                gameBoard[r, j].BackColor = Color.White;
                            }
                        }
                    }


                }
            }
        } */
        /*
        private void MoveLeft(object sender, EventArgs e, string color)
        {

            bool moveLock = false; //Locks or unlocks movment
            //loops thorugh gameboard checking all pictireboxes one at a time
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int j = 0; j < 7; j++) //Coloums
                {
                    if (Color.FromName(cbColour.Text) == Color.Green)
                    {
                        //Makes sure the square that colour will move into is blank
                        if (gameBoard[r, j].BackColor == Color.Green)
                        {
                            if (gameBoard[r, j - 1].BackColor == Color.White)
                            {
                                gameBoard[r, j - 1].BackColor = Color.FromName(color);
                                gameBoard[r, j].BackColor = Color.White;
                            }
                        }
                    }
                    else
                    {
                        //check what colour is selected
                        if (gameBoard[r, j].BackColor == Color.FromName(cbColour.Text))
                        {
                            // prevents moving out of gameboard
                            if (r == 0)
                            {
                                moveLock = true;
                            }
                            //moves piece left one square
                            if (r > 0)
                            {
                                gameBoard[r, j - 1].BackColor = Color.FromName(color);
                                gameBoard[r, j].BackColor = Color.White;
                            }
                        }
                    }


                }


            }
        }
        */
        private void btnUp_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "y-";
            MovePlus(this, e, colour, move);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "x-";
            MovePlus(this, e, colour, move);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "y+";
            MoveMinus(this, e, colour, move);
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "right";
            MoveMinus(this, e, colour, move);
        }
    }

}


