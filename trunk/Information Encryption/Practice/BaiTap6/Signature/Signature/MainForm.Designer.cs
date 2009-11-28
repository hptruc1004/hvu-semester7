namespace Signature
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSignHash = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSignatureInput = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.tbInputFileName = new System.Windows.Forms.TextBox();
            this.tabSignData = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSignatureInput2 = new System.Windows.Forms.TextBox();
            this.btnVerify2 = new System.Windows.Forms.Button();
            this.btnSign2 = new System.Windows.Forms.Button();
            this.btnBrowseInputFileName2 = new System.Windows.Forms.Button();
            this.tbInputFileName2 = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabMain.SuspendLayout();
            this.tabSignHash.SuspendLayout();
            this.tabSignData.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Data file";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSignHash);
            this.tabMain.Controls.Add(this.tabSignData);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(534, 223);
            this.tabMain.TabIndex = 0;
            // 
            // tabSignHash
            // 
            this.tabSignHash.Controls.Add(this.label2);
            this.tabSignHash.Controls.Add(this.label1);
            this.tabSignHash.Controls.Add(this.tbSignatureInput);
            this.tabSignHash.Controls.Add(this.btnVerify);
            this.tabSignHash.Controls.Add(this.btnSign);
            this.tabSignHash.Controls.Add(this.btnBrowseInputFile);
            this.tabSignHash.Controls.Add(this.tbInputFileName);
            this.tabSignHash.Location = new System.Drawing.Point(4, 22);
            this.tabSignHash.Name = "tabSignHash";
            this.tabSignHash.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignHash.Size = new System.Drawing.Size(526, 197);
            this.tabSignHash.TabIndex = 0;
            this.tabSignHash.Text = "Sign Hash";
            this.tabSignHash.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Signature:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input:";
            // 
            // tbSignatureInput
            // 
            this.tbSignatureInput.Location = new System.Drawing.Point(97, 74);
            this.tbSignatureInput.Name = "tbSignatureInput";
            this.tbSignatureInput.Size = new System.Drawing.Size(332, 20);
            this.tbSignatureInput.TabIndex = 5;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(290, 127);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(84, 35);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(153, 127);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(84, 35);
            this.btnSign.TabIndex = 2;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Location = new System.Drawing.Point(435, 38);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(36, 26);
            this.btnBrowseInputFile.TabIndex = 1;
            this.btnBrowseInputFile.Text = "...";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
            // 
            // tbInputFileName
            // 
            this.tbInputFileName.Enabled = false;
            this.tbInputFileName.Location = new System.Drawing.Point(97, 42);
            this.tbInputFileName.Name = "tbInputFileName";
            this.tbInputFileName.Size = new System.Drawing.Size(332, 20);
            this.tbInputFileName.TabIndex = 0;
            // 
            // tabSignData
            // 
            this.tabSignData.Controls.Add(this.label3);
            this.tabSignData.Controls.Add(this.label4);
            this.tabSignData.Controls.Add(this.tbSignatureInput2);
            this.tabSignData.Controls.Add(this.btnVerify2);
            this.tabSignData.Controls.Add(this.btnSign2);
            this.tabSignData.Controls.Add(this.btnBrowseInputFileName2);
            this.tabSignData.Controls.Add(this.tbInputFileName2);
            this.tabSignData.Location = new System.Drawing.Point(4, 22);
            this.tabSignData.Name = "tabSignData";
            this.tabSignData.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignData.Size = new System.Drawing.Size(526, 197);
            this.tabSignData.TabIndex = 1;
            this.tabSignData.Text = "Sign Data";
            this.tabSignData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Signature:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Input:";
            // 
            // tbSignatureInput2
            // 
            this.tbSignatureInput2.Location = new System.Drawing.Point(102, 68);
            this.tbSignatureInput2.Name = "tbSignatureInput2";
            this.tbSignatureInput2.Size = new System.Drawing.Size(335, 20);
            this.tbSignatureInput2.TabIndex = 13;
            // 
            // btnVerify2
            // 
            this.btnVerify2.Location = new System.Drawing.Point(300, 119);
            this.btnVerify2.Name = "btnVerify2";
            this.btnVerify2.Size = new System.Drawing.Size(101, 35);
            this.btnVerify2.TabIndex = 11;
            this.btnVerify2.Text = "Verify";
            this.btnVerify2.UseVisualStyleBackColor = true;
            this.btnVerify2.Click += new System.EventHandler(this.btnVerify2_Click);
            // 
            // btnSign2
            // 
            this.btnSign2.Location = new System.Drawing.Point(126, 119);
            this.btnSign2.Name = "btnSign2";
            this.btnSign2.Size = new System.Drawing.Size(101, 35);
            this.btnSign2.TabIndex = 10;
            this.btnSign2.Text = "Sign";
            this.btnSign2.UseVisualStyleBackColor = true;
            this.btnSign2.Click += new System.EventHandler(this.btnSign2_Click);
            // 
            // btnBrowseInputFileName2
            // 
            this.btnBrowseInputFileName2.Location = new System.Drawing.Point(443, 28);
            this.btnBrowseInputFileName2.Name = "btnBrowseInputFileName2";
            this.btnBrowseInputFileName2.Size = new System.Drawing.Size(29, 26);
            this.btnBrowseInputFileName2.TabIndex = 9;
            this.btnBrowseInputFileName2.Text = "...";
            this.btnBrowseInputFileName2.UseVisualStyleBackColor = true;
            this.btnBrowseInputFileName2.Click += new System.EventHandler(this.btnBrowseInputFile2_Click);
            // 
            // tbInputFileName2
            // 
            this.tbInputFileName2.Enabled = false;
            this.tbInputFileName2.Location = new System.Drawing.Point(102, 32);
            this.tbInputFileName2.Name = "tbInputFileName2";
            this.tbInputFileName2.Size = new System.Drawing.Size(335, 20);
            this.tbInputFileName2.TabIndex = 8;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Signature file|*.sig";
            this.saveFileDialog.Title = "Signature file";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 223);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Text = "Signature";
            this.tabMain.ResumeLayout(false);
            this.tabSignHash.ResumeLayout(false);
            this.tabSignHash.PerformLayout();
            this.tabSignData.ResumeLayout(false);
            this.tabSignData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSignHash;
        private System.Windows.Forms.TabPage tabSignData;
        private System.Windows.Forms.TextBox tbInputFileName;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox tbSignatureInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSignatureInput2;
        private System.Windows.Forms.Button btnVerify2;
        private System.Windows.Forms.Button btnSign2;
        private System.Windows.Forms.Button btnBrowseInputFileName2;
        private System.Windows.Forms.TextBox tbInputFileName2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

