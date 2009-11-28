namespace HashAlgo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbHashAlgo = new System.Windows.Forms.ComboBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnInputData = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHash = new System.Windows.Forms.TextBox();
            this.btnHashData = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Algorithm:";
            // 
            // cbbHashAlgo
            // 
            this.cbbHashAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHashAlgo.FormattingEnabled = true;
            this.cbbHashAlgo.Items.AddRange(new object[] {
            "SHA1",
            "MD5",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.cbbHashAlgo.Location = new System.Drawing.Point(98, 32);
            this.cbbHashAlgo.Name = "cbbHashAlgo";
            this.cbbHashAlgo.Size = new System.Drawing.Size(87, 21);
            this.cbbHashAlgo.TabIndex = 2;
            // 
            // tbInput
            // 
            this.tbInput.Enabled = false;
            this.tbInput.Location = new System.Drawing.Point(98, 71);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(275, 20);
            this.tbInput.TabIndex = 3;
            // 
            // btnInputData
            // 
            this.btnInputData.Location = new System.Drawing.Point(379, 69);
            this.btnInputData.Name = "btnInputData";
            this.btnInputData.Size = new System.Drawing.Size(33, 23);
            this.btnInputData.TabIndex = 4;
            this.btnInputData.Text = "...";
            this.btnInputData.UseVisualStyleBackColor = true;
            this.btnInputData.Click += new System.EventHandler(this.btnInputData_Click);
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(42, 169);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(75, 37);
            this.btnHash.TabIndex = 5;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hash:";
            // 
            // tbHash
            // 
            this.tbHash.Enabled = false;
            this.tbHash.Location = new System.Drawing.Point(98, 110);
            this.tbHash.Name = "tbHash";
            this.tbHash.Size = new System.Drawing.Size(275, 20);
            this.tbHash.TabIndex = 7;
            // 
            // btnHashData
            // 
            this.btnHashData.Location = new System.Drawing.Point(379, 108);
            this.btnHashData.Name = "btnHashData";
            this.btnHashData.Size = new System.Drawing.Size(33, 23);
            this.btnHashData.TabIndex = 8;
            this.btnHashData.Text = "...";
            this.btnHashData.UseVisualStyleBackColor = true;
            this.btnHashData.Click += new System.EventHandler(this.btnHashData_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(133, 169);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 37);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(337, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 37);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 230);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnHashData);
            this.Controls.Add(this.tbHash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.btnInputData);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.cbbHashAlgo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Hash Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbHashAlgo;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnInputData;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHash;
        private System.Windows.Forms.Button btnHashData;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

