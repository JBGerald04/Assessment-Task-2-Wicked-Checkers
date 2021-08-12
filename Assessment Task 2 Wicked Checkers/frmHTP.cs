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
    public partial class frmHTP : Form
    {
        string frmStateH;
        public frmHTP(string frmState)
        {
            frmStateH = frmState;
            InitializeComponent();
            lblHTPText.Text = "To move a piece on the board, you must click on a shell and select a highlighted square.";
            lblHTPText.Text += "\n\nThe shells go first, then the starfish.";
            lblHTPText.Text += "\n\nIf a piece (starfish or seashell) makes it to the other side of the board, they become a queen checker, and are able to move anywhere on the board.";
            lblHTPText.Text += "\n\nWhoever checks all of the 12 opponents checkers wins!";
        }

        private void frmHowTP_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var formM = new frmMenu();
            var formO = new frmGame(false, false, false);

            if (frmStateH == "Menu")
            {
                formM.Show();
                this.Hide();
            }
            else if (frmStateH == "Game")
            {
                formO.Show();
                this.Hide();
            }
        }
    }
}
