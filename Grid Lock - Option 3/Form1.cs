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
        public bool moveLock = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            stopwatch.Visible = false;
            int index = 1; //tracks where we are in the array
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
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
        private void MovePlus(object sender, EventArgs e, string colour, string move)
        {
            //loops thorugh gameboard checking all picture boxes one at a time from top left to bottom right
            for (int r = 0; r < 7; r++) //Rows
            {
                for (int c = 0; c < 7; c++) //Coloums
                {
                    if (move == "Up" && r > 0)
                    {
                        if (moveLock == false)
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
                        else if (Convert.ToString(gameBoard[3, 6].BackColor) == "Green")
                        {
                            MessageBox.Show("Test");
                        }
                    }
                    if (move == "Left" && c > 0)
                    {
                        if (r != 6 && c != 2 || r != 7 && c != 3)
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
                        else if (r == 6 && c == 2 && r + 1 == 7 && c == 3)
                        {
                            MessageBox.Show("Test");
                        }
                    }

                }
            }
        }
        //deals with Right and Down movment. Scans from bottom left to top right to avoid the blocks riding the checker
        private void MoveMinus(object sender, EventArgs e, string colour, string move)
        {
            //loops thorugh gameboard checking all pictireboxes one at a time
            for (int r = 6; r >= 0; r--) //Rows
            {
                for (int c = 6; c >= 0; c--) //Coloums
                {
                    if (Color.FromName(cbColour.Text) == Color.Green)
                    {
                        if (move == "Right" && c <= 6)
                        {
                            if (Convert.ToString(gameBoard[2, 5].BackColor) != "Green" && Convert.ToString(gameBoard[3, 5].BackColor) != "Green")
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
        private void btnUp_Click(object sender, EventArgs e) //?? how can i use keys to do this? pressing any key automaticaly selects and uses the cb and does not read the input to use. tryed the function recomended but only selected objects on screen
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (msec < 10 && moveLock == false)
            {
                msec++;
            }
            if (msec == 10 && moveLock == false)
            {
                msec = 0;
                sec++;
            }
            else if (sec == 60 && moveLock == false)
            {
                sec = 0;
                min++;
            }
            stopwatch.Text = Convert.ToString(min) + ":" + Convert.ToString(sec) + ":" + Convert.ToString(msec);
            if (Convert.ToString(gameBoard[3, 6].BackColor) == "Color " + "[" + "Green" + "]" && moveLock == false)
            {
                moveLock = true;
                MessageBox.Show("Congrats, you won! you completed the level in " + min + " minutes, " + sec + " secconds and " + msec + " milisecconds. Close this window to progress to the next level");
                string lvlComplete = "true";
                btnLevel_Click(this, e, lvlComplete);
            }
        }
        private void btnBegin_Click(object sender, EventArgs e)
        {
            msec = 0;
            sec = 0;
            min = 0;
            stopwatch.Visible = true;
            btnBegin.Visible = false;
            moveLock = false;
        } //?? only happy if all thigns sending to it send the same values, is there a way around this iwthout using global variables? // not nessesary but would like to know
        private void btnDarkSwitch_Click(object sender, EventArgs e)
        {
            if (btnDarkSwitch.Text == "Dark Mode")
            {
                btnDarkSwitch.Text = "Light Mode";
                BackColor = SystemColors.Control;
                lblColourSelect.ForeColor = SystemColors.ControlText;
                gbGameArea.ForeColor = SystemColors.ControlText;
                gbControls.ForeColor = SystemColors.ControlText;
                btnBegin.ForeColor = SystemColors.ControlText;
                btnBegin.BackColor = SystemColors.Control;
                btnDarkSwitch.ForeColor = SystemColors.ControlText;
                btnDarkSwitch.BackColor = SystemColors.Control;
            }
            else if (btnDarkSwitch.Text == "Light Mode")
            {
                btnDarkSwitch.Text = "Dark Mode";
                BackColor = Color.FromArgb(40, 40, 40);
                lblColourSelect.ForeColor = SystemColors.Control;
                gbGameArea.ForeColor = SystemColors.Control;
                gbControls.ForeColor = SystemColors.Control;
                btnBegin.ForeColor = SystemColors.Control;
                btnBegin.BackColor = Color.FromArgb(40, 40, 40);
                btnDarkSwitch.BackColor = SystemColors.ControlText;
                btnDarkSwitch.ForeColor = SystemColors.Control;
            }
        }

        private void btnLevel_Click(object sender, EventArgs e, string lvlComplete)
        {
            if (btnLevel.Text == "Level 1" || lvlComplete == "true")
            {
                List<string> startingConfigArray = new List<string>();
                StreamReader reader = new StreamReader(@"level_2.csv");
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
                btnLevel.Text = "Level 2";
                btnBegin.Visible = true;
            }
            else if (btnLevel.Text == "Level 2" || lvlComplete == "true")
            {
                List<string> startingConfigArray = new List<string>();
                StreamReader reader = new StreamReader(@"level_3.csv");
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
                btnLevel.Text = "Level 1"; // change if lvl 3 is added
                btnBegin.Visible = true;
            }
            msec = 0;
            sec = 0;
            min = 0;
        } 
    }
}




