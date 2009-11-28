namespace DigitalClock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.imageDigit = new System.Windows.Forms.ImageList(this.components);
            this.dClock = new DigitalClock.DClock();
            this.btnAlarmOn = new System.Windows.Forms.Button();
            this.btnAlarmOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(105, 120);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(186, 120);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // imageDigit
            // 
            this.imageDigit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageDigit.ImageStream")));
            this.imageDigit.TransparentColor = System.Drawing.Color.Transparent;
            this.imageDigit.Images.SetKeyName(0, "0.png");
            this.imageDigit.Images.SetKeyName(1, "1.png");
            this.imageDigit.Images.SetKeyName(2, "2.png");
            this.imageDigit.Images.SetKeyName(3, "3.png");
            this.imageDigit.Images.SetKeyName(4, "4.png");
            this.imageDigit.Images.SetKeyName(5, "5.png");
            this.imageDigit.Images.SetKeyName(6, "6.png");
            this.imageDigit.Images.SetKeyName(7, "7.png");
            this.imageDigit.Images.SetKeyName(8, "8.png");
            this.imageDigit.Images.SetKeyName(9, "9.png");
            // 
            // dClock
            // 
            this.dClock.DashImage = ((System.Drawing.Image)(resources.GetObject("dClock.DashImage")));
            this.dClock.ListDigitImages = this.imageDigit;
            this.dClock.Location = new System.Drawing.Point(57, 37);
            this.dClock.Name = "dClock";
            this.dClock.Size = new System.Drawing.Size(171, 31);
            this.dClock.TabIndex = 4;
            // 
            // btnAlarmOn
            // 
            this.btnAlarmOn.Location = new System.Drawing.Point(57, 161);
            this.btnAlarmOn.Name = "btnAlarmOn";
            this.btnAlarmOn.Size = new System.Drawing.Size(75, 23);
            this.btnAlarmOn.TabIndex = 5;
            this.btnAlarmOn.Text = "Alarm On";
            this.btnAlarmOn.UseVisualStyleBackColor = true;
            this.btnAlarmOn.Click += new System.EventHandler(this.btnAlarmOn_Click);
            // 
            // btnAlarmOff
            // 
            this.btnAlarmOff.Location = new System.Drawing.Point(153, 161);
            this.btnAlarmOff.Name = "btnAlarmOff";
            this.btnAlarmOff.Size = new System.Drawing.Size(75, 23);
            this.btnAlarmOff.TabIndex = 6;
            this.btnAlarmOff.Text = "Alarm Off";
            this.btnAlarmOff.UseVisualStyleBackColor = true;
            this.btnAlarmOff.Click += new System.EventHandler(this.btnAlarmOff_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.btnAlarmOff);
            this.Controls.Add(this.btnAlarmOn);
            this.Controls.Add(this.dClock);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ImageList imageDigit;
        private DClock dClock;
        private System.Windows.Forms.Button btnAlarmOn;
        private System.Windows.Forms.Button btnAlarmOff;

    }
}

