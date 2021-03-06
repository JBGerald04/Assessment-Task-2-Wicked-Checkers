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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            var form = new frmGame(false, false, false);
            form.Show();
            this.Hide();
        }

        private void btnHowTP_Click(object sender, EventArgs e)
        {
            var form = new frmHTP("Menu");
            form.Show();
            this.Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var form = new frmOptions("Menu");
            form.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}