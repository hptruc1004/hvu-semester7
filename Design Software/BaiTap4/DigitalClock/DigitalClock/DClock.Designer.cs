namespace DigitalClock
{
    partial class DClock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.ptbMin1 = new System.Windows.Forms.PictureBox();
            this.ptbMin2 = new System.Windows.Forms.PictureBox();
            this.ptbSec1 = new System.Windows.Forms.PictureBox();
            this.ptbSec2 = new System.Windows.Forms.PictureBox();
            this.ptbDash = new System.Windows.Forms.PictureBox();
            this.timerAlarm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSec1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSec2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDash)).BeginInit();
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // ptbMin1
            // 
            this.ptbMin1.BackColor = System.Drawing.Color.Black;
            this.ptbMin1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbMin1.Location = new System.Drawing.Point(0, 0);
            this.ptbMin1.Name = "ptbMin1";
            this.ptbMin1.Size = new System.Drawing.Size(34, 31);
            this.ptbMin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMin1.TabIndex = 0;
            this.ptbMin1.TabStop = false;
            // 
            // ptbMin2
            // 
            this.ptbMin2.BackColor = System.Drawing.Color.Black;
            this.ptbMin2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbMin2.Location = new System.Drawing.Point(34, 0);
            this.ptbMin2.Name = "ptbMin2";
            this.ptbMin2.Size = new System.Drawing.Size(34, 31);
            this.ptbMin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMin2.TabIndex = 1;
            this.ptbMin2.TabStop = false;
            // 
            // ptbSec1
            // 
            this.ptbSec1.BackColor = System.Drawing.Color.Black;
            this.ptbSec1.Location = new System.Drawing.Point(102, 0);
            this.ptbSec1.Name = "ptbSec1";
            this.ptbSec1.Size = new System.Drawing.Size(34, 31);
            this.ptbSec1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSec1.TabIndex = 2;
            this.ptbSec1.TabStop = false;
            // 
            // ptbSec2
            // 
            this.ptbSec2.BackColor = System.Drawing.Color.Black;
            this.ptbSec2.Location = new System.Drawing.Point(136, 0);
            this.ptbSec2.Name = "ptbSec2";
            this.ptbSec2.Size = new System.Drawing.Size(34, 31);
            this.ptbSec2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSec2.TabIndex = 3;
            this.ptbSec2.TabStop = false;
            // 
            // ptbDash
            // 
            this.ptbDash.BackColor = System.Drawing.Color.Black;
            this.ptbDash.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbDash.Location = new System.Drawing.Point(68, 0);
            this.ptbDash.Name = "ptbDash";
            this.ptbDash.Size = new System.Drawing.Size(34, 31);
            this.ptbDash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDash.TabIndex = 4;
            this.ptbDash.TabStop = false;
            // 
            // DClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ptbDash);
            this.Controls.Add(this.ptbSec2);
            this.Controls.Add(this.ptbSec1);
            this.Controls.Add(this.ptbMin2);
            this.Controls.Add(this.ptbMin1);
            this.Name = "DClock";
            this.Size = new System.Drawing.Size(171, 31);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSec1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSec2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.PictureBox ptbMin1;
        private System.Windows.Forms.PictureBox ptbMin2;
        private System.Windows.Forms.PictureBox ptbSec1;
        private System.Windows.Forms.PictureBox ptbSec2;
        private System.Windows.Forms.PictureBox ptbDash;
        private System.Windows.Forms.Timer timerAlarm;
    }
}
