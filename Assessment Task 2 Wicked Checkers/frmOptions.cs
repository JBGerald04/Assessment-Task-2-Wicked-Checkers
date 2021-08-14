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
    public partial class frmOptions : Form
    {
        string frmStateO;
        bool GameStats, GameTimer, GamePlayer;

        public frmOptions(string frmState)
        {
            frmStateO = frmState;
            InitializeComponent();
        }

        private void lblStory_Click(object sender, EventArgs e)
        {
            pnlStory.Show();
            lblStoryText.Text = "You know when someone wants a vacation? They just take a sick day off of work and go to the beach?";
            lblStoryText.Text += "\n\nWell, The Checkers wanted a holiday, so the Seashells and Starfish offered to fill in.";
            lblStoryText.Text += "\n\nNow they're fighting to see who can take the mantle of the Checker Champion!";
        }

        private void btnBackS_Click(object sender, EventArgs e)
        {
            pnlStory.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            StatOff.Checked = true;
            GameStats = false;
            TimerOff.Checked = true;
            GameTimer = false;
            PlayerSS.Checked = true;
            GamePlayer = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (StatOff.Checked == false) GameStats = true;
            if (TimerOff.Checked == false) GameTimer = true;
            if (PlayerSS.Checked == false) GamePlayer = true;
            var formM = new frmMenu();
            var formO = new frmGame(GameStats, GameTimer, GamePlayer);

            if (frmStateO == "Menu")
            {
                formM.Show();
                this.Hide();
            }
            else if (frmStateO == "Game")
            {
                formO.Show();
                this.Hide();
            }
        }
    }
}