using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assessment_Task_2_Wicked_Checkers
{
    public partial class frmGame : Form
    {

        // Variables
        private int _ticks;
        int rows, direction = -1, x, y, SFCount = 0, SSCount = 0, CheckerKillCount = 0;
        PictureBox[,] pictureBoxes;
        string player = "", checker = "SF", checkerQ = "", lastCheckerClicked = "", rightMoveCoord = "", leftMoveCoord = "", rightMoveCoordQ = "", leftMoveCoordQ = "", killCoordL = "", killCoordR = "", killCoordLQ = "", killCoordRQ = "";

        private void lblMain_Click(object sender, EventArgs e)
        {
            var form = new frmMenu();
            form.Show();
            this.Hide();
        }

        private void lblPlay_Click(object sender, EventArgs e)
        {
            // Play again, hiding the win screen, resetting the checkerboard, setting the winning checker to the first to play again, and resetting the death count.
            W.Visible = false;
            pnlGame.Controls.Clear();
            GenerateCheckerBoard();
            if (SSCount == 12) checker = "SF";
            else if (SFCount == 12) checker = "SS";
            SFDeathCount.Text = "0";
            SSDeathCount.Text = "0";
            SSCount = 0;
            SFCount = 0;
        }

        bool CheckerKill = false, GStats, GTimer, GPlayer;

        private void timer_Tick(object sender, EventArgs e)
        {
            _ticks++;
        }

        public frmGame(bool GameStats, bool GameTimer, bool GamePlayer)
        {
            GStats = GameStats;
            GTimer = GameTimer;
            GPlayer = GamePlayer;
            InitializeComponent();
            SwapPlayer();
            GenerateCheckerBoard();
        }

        private void Checker_Click(object sender, EventArgs e)
        {
            // Start Timer if yes in options
            if (GTimer == true)
            {
                Timer();
            }
            PictureBox clickedPictureBox = sender as PictureBox;

            // If there is nothing in the picturebox, return
            if (clickedPictureBox.Image == null) return;

            // Clear the extra highlighted squares
            HLCoordinate();

            // Seting the x & y coordinates
            x = Convert.ToInt32(clickedPictureBox.Name.Split(' ')[0]);
            y = Convert.ToInt32(clickedPictureBox.Name.Split(' ')[1]);
            player = clickedPictureBox.Name.Split(' ')[2];

            // Check checker clicked is a checker
            if (player == checker || player == checkerQ)
            {
                lastCheckerClicked = clickedPictureBox.Name;

                // Setting the direction of the player (down(1) = SS, up(-1) = SF)
                if (player == "SS" || player == "SSQ") direction = 1;
                else if (player == "SF" || player == "SFQ") direction = -1;

                // Highlighting squares to the left & right, and jump left & right
                try
                {
                    // Highlight move option to the right
                    if (pictureBoxes[x + direction, y + 1].Image == null)  //Normal move forward
                    {
                        pictureBoxes[x + direction, y + 1].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + direction, y + 1].Name = (x + direction) + " " + (y + 1) + " HLBlue";
                        rightMoveCoord = (x + direction) + " " + (y + 1);
                    }

                    // Checking if enemy is to the right, highlight square after jump
                    else if (pictureBoxes[x + direction, y + 1].Name.Split(' ')[2] != checker
                          && pictureBoxes[x + direction, y + 1].Name.Split(' ')[2] != checkerQ
                          && pictureBoxes[x + (direction * 2), y + 2].Image == null) //Jump forward 
                    {
                        pictureBoxes[x + (direction * 2), y + 2].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + (direction * 2), y + 2].Name = (x + (direction * 2)) + " " + (y + 2) + " HLBlue";
                        rightMoveCoord = (x + (direction * 2)) + " " + (y + 2);
                        killCoordR = (x + direction) + " " + (y + 1) + " " + pictureBoxes[x + direction, y + 1].Name.Split(' ')[2];
                    }
                }
                catch { }

                try
                {
                    // Highlight the option to the left                        
                    if (pictureBoxes[x + direction, y - 1].Image == null)
                    {
                        pictureBoxes[x + direction, y - 1].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + direction, y - 1].Name = (x + direction) + " " + (y - 1) + " HLBlue";
                        leftMoveCoord = (x + direction) + " " + (y - 1);
                    }

                    //  Checking if enemy is to the left, highlight square after jump
                    else if (pictureBoxes[x + direction, y - 1].Name.Split(' ')[2] != checker
                          && pictureBoxes[x + direction, y - 1].Name.Split(' ')[2] != checkerQ
                          && pictureBoxes[x + (direction * 2), y - 2].Image == null)
                    {
                        pictureBoxes[x + (direction * 2), y - 2].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + (direction * 2), y - 2].Name = (x + (direction * 2)) + " " + (y - 2) + " HLBlue";
                        leftMoveCoord = (x + (direction * 2)) + " " + (y - 2);
                        killCoordL = (x + direction) + " " + (y - 1) + " " + pictureBoxes[x + direction, y - 1].Name.Split(' ')[2];
                    }
                }
                catch { }
            }

            // If the player is a queen piece, allow for highlight in the other direction
            if (player == checkerQ)
            {
                // Switch direction of highlight
                direction *= -1;

                // Highlighting squares to the left & right, and jump left & right
                try
                {
                    // Highlight the option to the right
                    if (pictureBoxes[x + direction, y + 1].Image == null)
                    {
                        pictureBoxes[x + direction, y + 1].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + direction, y + 1].Name = (x + direction) + " " + (y + 1) + " HLBlue";
                        rightMoveCoordQ = (x + direction) + " " + (y + 1);
                    }

                    // Checking if enemy is to the right, highlight square after jump
                    else if (pictureBoxes[x + direction, y + 1].Name.Split(' ')[2] != checker
                          && pictureBoxes[x + direction, y + 1].Name.Split(' ')[2] != checkerQ
                          && pictureBoxes[x + (direction * 2), y + 2].Image == null) //Jump forward 
                    {
                        pictureBoxes[x + (direction * 2), y + 2].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + (direction * 2), y + 2].Name = (x + (direction * 2)) + " " + (y + 2) + " HLBlue";
                        rightMoveCoordQ = (x + (direction * 2)) + " " + (y + 2);
                        killCoordRQ = (x + direction) + " " + (y + 1) + " " + pictureBoxes[x + direction, y + 1].Name.Split(' ')[2];
                    }
                }
                catch { }
                try
                {
                    // Highlight the option to the left
                    if (pictureBoxes[x + direction, y - 1].Image == null)
                    {
                        pictureBoxes[x + direction, y - 1].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + direction, y - 1].Name = (x + direction) + " " + (y - 1) + " HLBlue";
                        leftMoveCoordQ = (x + direction) + " " + (y - 1);
                    }

                    //  Checking if enemy is to the left, highlight square after jump
                    else if (pictureBoxes[x + direction, y - 1].Name.Split(' ')[2] != checker
                          && pictureBoxes[x + direction, y - 1].Name.Split(' ')[2] != checkerQ
                          && pictureBoxes[x + (direction * 2), y - 2].Image == null)
                    {
                        pictureBoxes[x + (direction * 2), y - 2].Image = Properties.Resources.HLBlue;
                        pictureBoxes[x + (direction * 2), y - 2].Name = (x + (direction * 2)) + " " + (y - 2) + " HLBlue";
                        leftMoveCoordQ = (x + (direction * 2)) + " " + (y - 2);
                        killCoordLQ = (x + direction) + " " + (y - 1) + " " + pictureBoxes[x + direction, y - 1].Name.Split(' ')[2];
                    }
                }
                catch { }

                // Set the direction back to the default (down(1) = SS, up(-1) = SF)
                direction *= -1;
            }

            //Check if the player chose to move
            else if (player == "HLBlue")
            {
                // Swap players turn
                SwapPlayer();

                // Setting the original checkers position to (x y player)
                x = Convert.ToInt32(lastCheckerClicked.Split(' ')[0]);
                y = Convert.ToInt32(lastCheckerClicked.Split(' ')[1]);
                player = lastCheckerClicked.Split(' ')[2];

                // Renaming the clicked picturebox to integers (x, y)
                int ClickedX = Convert.ToInt32(clickedPictureBox.Name.Split(' ')[0]);
                int ClickedY = Convert.ToInt32(clickedPictureBox.Name.Split(' ')[1]);

                // Replacing the square with the moving checker
                // Move Seashell checker
                if (player == "SS")
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SS;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = clickedPictureBox.Name.Replace("HLBlue", "SS");
                }

                // Move Starfish checker
                else if (player == "SF")
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SF;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = clickedPictureBox.Name.Replace("HLBlue", "SF");
                }

                // Move SeashellQueen checker
                if (player == "SSQ")
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SSQ;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = clickedPictureBox.Name.Replace("HLBlue", "SSQ");
                }

                // Move StarfishQueen checker
                else if (player == "SFQ")
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SFQ;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = clickedPictureBox.Name.Replace("HLBlue", "SFQ");
                }

                // Delete original checker
                pictureBoxes[x, y].Image = null;

                // Check if they are Queenable?
                // If the Seashell has reached the bottom of the board, change to Queen
                if (player == "SS" && ClickedX == 7)
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SSQ;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = $"{ClickedX} {ClickedY} SSQ";
                }

                // If the Starfish has reached the top of the board, change to Queen
                if (player == "SF" && ClickedX == 0)
                {
                    pictureBoxes[ClickedX, ClickedY].Image = Properties.Resources.SFQ;
                    pictureBoxes[ClickedX, ClickedY].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[ClickedX, ClickedY].Name = $"{ClickedX} {ClickedY} SFQ";
                }

                // Are we killing another checker?  
                if (direction == -1)
                {
                    if (killCoordR != "")
                    {
                        int killXR = Convert.ToInt32(killCoordR.Split(' ')[0]);
                        int killYR = Convert.ToInt32(killCoordR.Split(' ')[1]);
                        if (ClickedX + 2 == x && ClickedY - 2 == y)
                        {
                            pictureBoxes[killXR, killYR].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                    if (killCoordL != "")
                    {
                        int killXL = Convert.ToInt32(killCoordL.Split(' ')[0]);
                        int killYL = Convert.ToInt32(killCoordL.Split(' ')[1]);
                        if (ClickedX + 2 == x && ClickedY + 2 == y)
                        {
                            pictureBoxes[killXL, killYL].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                }
                else if (direction == 1)
                {
                    if (killCoordR != "")
                    {
                        int killXR = Convert.ToInt32(killCoordR.Split(' ')[0]);
                        int killYR = Convert.ToInt32(killCoordR.Split(' ')[1]);
                        if (ClickedX - 2 == x && ClickedY - 2 == y)
                        {
                            pictureBoxes[killXR, killYR].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                    if (killCoordL != "")
                    {
                        int killXL = Convert.ToInt32(killCoordL.Split(' ')[0]);
                        int killYL = Convert.ToInt32(killCoordL.Split(' ')[1]);
                        if (ClickedX - 2 == x && ClickedY + 2 == y)
                        {
                            pictureBoxes[killXL, killYL].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                }
                if (player == "SFQ")
                {
                    if (killCoordRQ != "")
                    {
                        int killXRQ = Convert.ToInt32(killCoordRQ.Split(' ')[0]);
                        int killYRQ = Convert.ToInt32(killCoordRQ.Split(' ')[1]);
                        if (ClickedX - 2 == x && ClickedY - 2 == y)
                        {
                            pictureBoxes[killXRQ, killYRQ].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                    if (killCoordLQ != "")
                    {
                        int killXLQ = Convert.ToInt32(killCoordLQ.Split(' ')[0]);
                        int killYLQ = Convert.ToInt32(killCoordLQ.Split(' ')[1]);
                        if (ClickedX - 2 == x && ClickedY + 2 == y)
                        {
                            pictureBoxes[killXLQ, killYLQ].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                }
                if (player == "SSQ")
                {
                    if (killCoordRQ != "")
                    {
                        int killXRQ = Convert.ToInt32(killCoordRQ.Split(' ')[0]);
                        int killYRQ = Convert.ToInt32(killCoordRQ.Split(' ')[1]);
                        if (ClickedX + 2 == x && ClickedY - 2 == y)
                        {
                            pictureBoxes[killXRQ, killYRQ].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                    if (killCoordLQ != "")
                    {
                        int killXLQ = Convert.ToInt32(killCoordLQ.Split(' ')[0]);
                        int killYLQ = Convert.ToInt32(killCoordLQ.Split(' ')[1]);
                        if (ClickedX + 2 == x && ClickedY + 2 == y)
                        {
                            pictureBoxes[killXLQ, killYLQ].Image = null;
                            CheckerKill = true;
                            CheckerKillCount++;
                        }
                    }
                }

                // If the checker has jumped, have another turn
                if (CheckerKill == true)
                {
                    SwapPlayer();
                }

                // Adding the kill count to the checker's team
                if (player == "SF" || player == "SFQ")
                {
                    SFCount += CheckerKillCount;
                }
                else if (player == "SS" || player == "SSQ")
                {
                    SSCount += CheckerKillCount;
                }

                // Adding the score to the counter
                SSDeathCount.Text = SSCount + "";
                SFDeathCount.Text = SFCount + "";

                // If all checkers are killed from the other team, go-to win screen
                if (SSCount == 12)
                {
                    Win("SS");
                }
                else if (SFCount == 12)
                {
                    Win("SF");
                }

                // Clear the kill coordinates
                killCoordR = "";
                killCoordL = "";
                killCoordRQ = "";
                killCoordLQ = "";

                // Clear the left and right highlights
                rightMoveCoord = "";
                rightMoveCoordQ = "";
                leftMoveCoord = "";
                leftMoveCoordQ = "";

                // Clear the checker kill count
                CheckerKillCount = 0;

                // Revert the checker kill state 
                CheckerKill = false;
            }
        }

        private void Win(string winner)
        {
            W.Visible = true;
            pbWin.Image = Properties.Resources.SunsetStory;
            pbWin.SizeMode = PictureBoxSizeMode.StretchImage;
            if (winner == "SF")
            {
                lblCheckerWinTxt.Text = " Starfish Win!!";
                pbCheckerWin.Image = Properties.Resources.trophiestarfwin;
                pbCheckerWin.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (winner == "SS")
            {
                lblCheckerWinTxt.Text = "Seashells Win!!!";
                pbCheckerWin.Image = Properties.Resources.trophieseaswin;
                pbCheckerWin.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void SwapPlayer()
        {
            // Swap the the checker to the other player, and update the player turn picturebox to the current player
            if (checker == "SS" || checkerQ == "SSQ")
            {
                checker = "SF";
                checkerQ = "SFQ";
                PlayerTurn.Image = Properties.Resources.SF;
            }
            else if (checker == "SF" || checkerQ == "SFQ")
            {
                checker = "SS";
                checkerQ = "SSQ";
                PlayerTurn.Image = Properties.Resources.SS;
            }
        }

        private void Checker_MouseHover(object sender, EventArgs e)
        {
            // When the mouse hovers over a checker, set the background colour to grey
            PictureBox p = sender as PictureBox;
            if (p.Image != null) p.BackColor = Color.FromArgb(255, 64, 64, 64);
        }

        private void Checker_MouseLeave(object sender, EventArgs e)
        {
            // When the mouse leaves a picturebox, set the background back to original colour
            PictureBox p = sender as PictureBox;
            if (p.Image != null) p.BackColor = Color.CadetBlue;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            lblTick.Text = _ticks.ToString();
        }
        private void Timer()
        {
            lblTimer.Show();
            lblTick.Show();
            timer.Start();
        }

        private void GenerateCheckerBoard()
        {
            // Generates a 8 x 8 board, with checkers on the coloured squares
            rows = 8;
            pictureBoxes = new PictureBox[rows, rows];
            int left = 2, top = 2;
            Color[] colors = new Color[] { Color.White, Color.Black };
            for (int x = 0; x < rows; x++)
            {
                left = 2;
                if (x % 2 == 0) { colors[0] = Color.FloralWhite; colors[1] = Color.CadetBlue; }
                else { colors[0] = Color.CadetBlue; colors[1] = Color.FloralWhite; }
                for (int y = 0; y < rows; y++)
                {
                    pictureBoxes[x, y] = new PictureBox();
                    pictureBoxes[x, y].BackColor = colors[(y % 2 == 0) ? 1 : 0];
                    pictureBoxes[x, y].Location = new Point(left, top);
                    pictureBoxes[x, y].Size = new Size(95, 95);
                    left += 95;
                    pictureBoxes[x, y].Name = x + " " + y;
                    if (x < (rows / 2) - 1 && pictureBoxes[x, y].BackColor == Color.CadetBlue) { pictureBoxes[x, y].Image = Properties.Resources.SS; pictureBoxes[x, y].Name += " SS"; }
                    else if (x > (rows / 2) && pictureBoxes[x, y].BackColor == Color.CadetBlue) { pictureBoxes[x, y].Image = Properties.Resources.SF; pictureBoxes[x, y].Name += " SF"; }
                    pictureBoxes[x, y].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[x, y].MouseHover += Checker_MouseHover;
                    pictureBoxes[x, y].MouseLeave += Checker_MouseLeave;
                    pictureBoxes[x, y].Click += Checker_Click;
                    pnlGame.Controls.Add(pictureBoxes[x, y]);
                }
                top += 95;
            }
        }

        public void HLCoordinate()
        {
            // If the coordinate is highlighted, clear the square
            if (rightMoveCoord != "")
            {
                int x, y;
                x = Convert.ToInt32(rightMoveCoord.Split(' ')[0]);
                y = Convert.ToInt32(rightMoveCoord.Split(' ')[1]);
                pictureBoxes[x, y].Image = null;
            }
            if (leftMoveCoord != "")
            {
                int x, y;
                x = Convert.ToInt32(leftMoveCoord.Split(' ')[0]);
                y = Convert.ToInt32(leftMoveCoord.Split(' ')[1]);
                pictureBoxes[x, y].Image = null;
            }
            if (rightMoveCoordQ != "")
            {
                int x, y;
                x = Convert.ToInt32(rightMoveCoordQ.Split(' ')[0]);
                y = Convert.ToInt32(rightMoveCoordQ.Split(' ')[1]);
                pictureBoxes[x, y].Image = null;
            }
            if (leftMoveCoordQ != "")
            {
                int x, y;
                x = Convert.ToInt32(leftMoveCoordQ.Split(' ')[0]);
                y = Convert.ToInt32(leftMoveCoordQ.Split(' ')[1]);
                pictureBoxes[x, y].Image = null;
            }
        }
    }
}