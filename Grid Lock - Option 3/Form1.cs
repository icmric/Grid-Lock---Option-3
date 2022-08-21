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
       public int msec;
       public int sec;
       public int min;
        private void Form1_Load(object sender, EventArgs e)
        {
            stopwatch.Visible = false;
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
        private void MovePlus(object sender, EventArgs e, string colour, String move, bool moveLock)
        {
            //loops thorugh gameboard checking all picture boxes one at a time from top left to bottom right
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int c = 0; c < 7; c++) //Coloums
                {
                    if (move == "Up" && r > 0)
                    {
                        //checks the selected square and checks if it matches the selected colour
                        if (gameBoard[r, c].BackColor == Color.Green && colour == "Green")
                        {
                            //checks if the squares it will move into are blank
                            if (gameBoard[r - 1, c].BackColor == Color.White && gameBoard[r - 1, c - 1].BackColor == Color.White && gameBoard[r + 1, c + 1].BackColor == Color.White) // how do i check both blocks above green to not split it?
                            {
                                gameBoard[r - 1, c].BackColor = Color.Green;
                                gameBoard[r, c].BackColor = Color.White;
                            }
                        }
                        //if the colour is not green it will run this. this section is needed as green has diffrent movment rules
                        else if (gameBoard[r, c].BackColor != Color.Green && colour != "Green")
                        {
                            //checks if the currently selected square is the selected colour
                            if (Convert.ToString(gameBoard[r, c].BackColor) == "Color " + "[" + colour + "]")
                            {
                                //makes sure the square it will move into is blank
                                if (gameBoard[r - 1, c].BackColor == Color.White)
                                {
                                    //makes sure the 
                                    if (Convert.ToString(gameBoard[r, c - 1].BackColor) != "Color " + "[" + colour + "]" && Convert.ToString(gameBoard[r, c + 1].BackColor) != "Color " + "[" + colour + "]")
                                    {
                                    gameBoard[r, c].BackColor = Color.White; // sets the square to blank
                                    gameBoard[r - 1, c].BackColor = Color.FromName(colour); //sets the square ahead the new colour
                                    }

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
                                if (gameBoard[r, c - 1].BackColor == Color.White && gameBoard[r - 1, c - 1].BackColor == Color.White)
                                {
                                    gameBoard[r, c].BackColor = Color.White;
                                    gameBoard[r, c - 1].BackColor = Color.Green;
                                }
                            }
                            else if (gameBoard[r, c].BackColor != Color.Green && colour != "Green")
                            {
                                if (Convert.ToString(gameBoard[r, c].BackColor) == "Color " + "[" + colour + "]")
                                {
                                    if (gameBoard[r, c - 1].BackColor == Color.White)
                                    {
                                        if (Convert.ToString(gameBoard[r - 1, c].BackColor) != "Color " + "[" + colour + "]" && Convert.ToString(gameBoard[r + 1, c].BackColor) != "Color " + "[" + colour + "]")
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
        }
        //deals with Right and Down movment. Scans from bottom left to top right to avoid the blocks riding the checker
        private void MoveMinus(object sender, EventArgs e, string colour, String move)
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
                                if (gameBoard[r, c].BackColor == Color.Green && colour == "Green")
                                {
                                    if (gameBoard[r, c + 1].BackColor == Color.White)
                                    {
                                            gameBoard[r, c].BackColor = Color.White;
                                            gameBoard[r, c + 1].BackColor = Color.Green;
                                    }
                                }
                                else if (gameBoard[r, c].BackColor != Color.Green && colour != "Green")
                                {
                                    if (Convert.ToString(gameBoard[r, c].BackColor) == "Color " + "[" + colour + "]")
                                    {
                                        if (gameBoard[r, c + 1].BackColor == Color.White)
                                        {
                                            if (Convert.ToString(gameBoard[r - 1, c].BackColor) != "Color " + "[" + colour + "]" && Convert.ToString(gameBoard[r - 1, c].BackColor) != "Color " + "[" + colour + "]")
                                            {
                                                gameBoard[r, c].BackColor = Color.White;
                                                gameBoard[r, c + 1].BackColor = Color.FromName(colour);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (move == "Down")
                        {
                            if (r <= 6)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    //Makes sure the square that colour will move into is blank
                                    if (gameBoard[r, c].BackColor == Color.Green && colour == "Green")
                                    {
                                        if (gameBoard[r + 1, c].BackColor == Color.White)
                                        {
                                            gameBoard[r + 1, c].BackColor = Color.FromName(colour);
                                            gameBoard[r, c].BackColor = Color.White;

                                        }
                                    }
                                    else if (gameBoard[r, c].BackColor != Color.Green && colour != "Green" && colour != "Green")
                                    {
                                        if (Convert.ToString(gameBoard[r, c].BackColor) == "Color " + "[" + colour + "]")
                                        { 
                                            if (gameBoard[r + 1, c].BackColor == Color.White)
                                            {
                                                if (Convert.ToString(gameBoard[r + 1, c].BackColor) != "Color " + "[" + colour + "]" && Convert.ToString(gameBoard[r + 1, c].BackColor) != "Color " + "[" + colour + "]")
                                                {
                                                    gameBoard[r, c].BackColor = Color.White;
                                                    gameBoard[r + 1, c].BackColor = Color.FromName(colour);
                                                }
                                            }
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
            bool moveLock = false;
            MovePlus(this, e, colour, move, moveLock); //?? why does this care about paramters not sent to it? also occours in other MovePlus senders
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            string colour = cbColour.Text;
            string move = "Left";
            bool moveLock = false;
            MovePlus(this, e, colour, move, moveLock);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (msec < 10)
            {
                msec++;
            }
            if (msec == 10)
            {
                msec = 0;
                sec++;
            }
            else if (sec == 60)
            {
                sec = 0;
                min++;
            }
            stopwatch.Text = Convert.ToString(min) + ":" + Convert.ToString(sec) + ":" + Convert.ToString(msec);
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            bool moveLock = false; //?? this needs to be only refrenced here and no where else otherwide movment can take place before game has started, is there a way to do wthis without gobal varibles?
            string colour = null;
            string move = null;
            MovePlus(this, e, colour, move, moveLock);
            msec = 0;
            sec = 0;
            min = 0;
            stopwatch.Visible = true;
            btnBegin.Visible = false;
        }
    }

}


