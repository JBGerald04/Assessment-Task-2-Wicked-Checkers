
namespace Assessment_Task_2_Wicked_Checkers
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.W = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlay = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SSDeathCount = new System.Windows.Forms.Label();
            this.labPlayerTurn = new System.Windows.Forms.Label();
            this.PlayerTurn = new System.Windows.Forms.PictureBox();
            this.SFDeathCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTick = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.W.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // W
            // 
            this.W.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.W.BackColor = System.Drawing.Color.Gold;
            this.W.Controls.Add(this.label1);
            this.W.Controls.Add(this.lblPlay);
            this.W.Location = new System.Drawing.Point(1084, 421);
            this.W.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.W.Name = "W";
            this.W.Size = new System.Drawing.Size(154, 40);
            this.W.TabIndex = 25;
            this.W.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(805, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // lblPlay
            // 
            this.lblPlay.AutoSize = true;
            this.lblPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlay.Location = new System.Drawing.Point(699, 446);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(263, 58);
            this.lblPlay.TabIndex = 0;
            this.lblPlay.Text = "Play Again";
            this.lblPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1476, 494);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // SSDeathCount
            // 
            this.SSDeathCount.AutoSize = true;
            this.SSDeathCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSDeathCount.ForeColor = System.Drawing.Color.Red;
            this.SSDeathCount.Location = new System.Drawing.Point(1561, 505);
            this.SSDeathCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SSDeathCount.Name = "SSDeathCount";
            this.SSDeathCount.Size = new System.Drawing.Size(40, 42);
            this.SSDeathCount.TabIndex = 23;
            this.SSDeathCount.Text = "0";
            // 
            // labPlayerTurn
            // 
            this.labPlayerTurn.AutoSize = true;
            this.labPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlayerTurn.Location = new System.Drawing.Point(1459, 104);
            this.labPlayerTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPlayerTurn.Name = "labPlayerTurn";
            this.labPlayerTurn.Size = new System.Drawing.Size(134, 26);
            this.labPlayerTurn.TabIndex = 22;
            this.labPlayerTurn.Text = "Players Turn";
            // 
            // PlayerTurn
            // 
            this.PlayerTurn.Location = new System.Drawing.Point(1460, 132);
            this.PlayerTurn.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerTurn.Name = "PlayerTurn";
            this.PlayerTurn.Size = new System.Drawing.Size(133, 123);
            this.PlayerTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerTurn.TabIndex = 21;
            this.PlayerTurn.TabStop = false;
            // 
            // SFDeathCount
            // 
            this.SFDeathCount.AutoSize = true;
            this.SFDeathCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFDeathCount.ForeColor = System.Drawing.Color.Green;
            this.SFDeathCount.Location = new System.Drawing.Point(1561, 401);
            this.SFDeathCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SFDeathCount.Name = "SFDeathCount";
            this.SFDeathCount.Size = new System.Drawing.Size(42, 44);
            this.SFDeathCount.TabIndex = 20;
            this.SFDeathCount.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1476, 390);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pnlGame
            // 
            this.pnlGame.AutoSize = true;
            this.pnlGame.BackColor = System.Drawing.Color.Gray;
            this.pnlGame.Location = new System.Drawing.Point(1, 2);
            this.pnlGame.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1000, 940);
            this.pnlGame.TabIndex = 18;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // lblTick
            // 
            this.lblTick.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick.Location = new System.Drawing.Point(1465, 32);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(128, 42);
            this.lblTick.TabIndex = 26;
            this.lblTick.Text = "0";
            this.lblTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTick.Visible = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(1494, 9);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(67, 26);
            this.lblTimer.TabIndex = 27;
            this.lblTimer.Text = "Timer";
            this.lblTimer.Visible = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1606, 941);
            this.ControlBox = false;
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblTick);
            this.Controls.Add(this.W);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.SSDeathCount);
            this.Controls.Add(this.labPlayerTurn);
            this.Controls.Add(this.PlayerTurn);
            this.Controls.Add(this.SFDeathCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.W.ResumeLayout(false);
            this.W.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel W;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label SSDeathCount;
        private System.Windows.Forms.Label labPlayerTurn;
        private System.Windows.Forms.PictureBox PlayerTurn;
        private System.Windows.Forms.Label SFDeathCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.Label lblTimer;
    }
}