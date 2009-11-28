namespace RijndaelCrypto
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
            this.tbPlainFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.grbPassword = new System.Windows.Forms.GroupBox();
            this.btnBrowsePlainFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDescrypt = new System.Windows.Forms.Button();
            this.btnBrowseEncryptedFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEncryptedFile = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbbBlockSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.tbIV = new System.Windows.Forms.TextBox();
            this.labelIV = new System.Windows.Forms.Label();
            this.cbbPadding = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbMode = new System.Windows.Forms.ComboBox();
            this.grbPassword.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPlainFile
            // 
            this.tbPlainFile.Enabled = false;
            this.tbPlainFile.Location = new System.Drawing.Point(116, 26);
            this.tbPlainFile.Name = "tbPlainFile";
            this.tbPlainFile.Size = new System.Drawing.Size(423, 20);
            this.tbPlainFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input file:";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(605, 21);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(70, 29);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // grbPassword
            // 
            this.grbPassword.Controls.Add(this.btnBrowsePlainFile);
            this.grbPassword.Controls.Add(this.btnEncrypt);
            this.grbPassword.Controls.Add(this.label1);
            this.grbPassword.Controls.Add(this.tbPlainFile);
            this.grbPassword.Location = new System.Drawing.Point(16, 79);
            this.grbPassword.Name = "grbPassword";
            this.grbPassword.Size = new System.Drawing.Size(695, 71);
            this.grbPassword.TabIndex = 5;
            this.grbPassword.TabStop = false;
            this.grbPassword.Text = " File encryption ";
            // 
            // btnBrowsePlainFile
            // 
            this.btnBrowsePlainFile.Location = new System.Drawing.Point(557, 21);
            this.btnBrowsePlainFile.Name = "btnBrowsePlainFile";
            this.btnBrowsePlainFile.Size = new System.Drawing.Size(42, 29);
            this.btnBrowsePlainFile.TabIndex = 5;
            this.btnBrowsePlainFile.Text = "...";
            this.btnBrowsePlainFile.UseVisualStyleBackColor = true;
            this.btnBrowsePlainFile.Click += new System.EventHandler(this.btnBrowsePlainFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDescrypt);
            this.groupBox1.Controls.Add(this.btnBrowseEncryptedFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbEncryptedFile);
            this.groupBox1.Location = new System.Drawing.Point(16, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " File descryption ";
            // 
            // btnDescrypt
            // 
            this.btnDescrypt.Location = new System.Drawing.Point(605, 21);
            this.btnDescrypt.Name = "btnDescrypt";
            this.btnDescrypt.Size = new System.Drawing.Size(70, 29);
            this.btnDescrypt.TabIndex = 6;
            this.btnDescrypt.Text = "Descrypt";
            this.btnDescrypt.UseVisualStyleBackColor = true;
            this.btnDescrypt.Click += new System.EventHandler(this.btnDescrypt_Click);
            // 
            // btnBrowseEncryptedFile
            // 
            this.btnBrowseEncryptedFile.Location = new System.Drawing.Point(557, 21);
            this.btnBrowseEncryptedFile.Name = "btnBrowseEncryptedFile";
            this.btnBrowseEncryptedFile.Size = new System.Drawing.Size(42, 29);
            this.btnBrowseEncryptedFile.TabIndex = 6;
            this.btnBrowseEncryptedFile.Text = "...";
            this.btnBrowseEncryptedFile.UseVisualStyleBackColor = true;
            this.btnBrowseEncryptedFile.Click += new System.EventHandler(this.btnBrowseEncryptedFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Input file:";
            // 
            // tbEncryptedFile
            // 
            this.tbEncryptedFile.Enabled = false;
            this.tbEncryptedFile.Location = new System.Drawing.Point(116, 26);
            this.tbEncryptedFile.Name = "tbEncryptedFile";
            this.tbEncryptedFile.Size = new System.Drawing.Size(423, 20);
            this.tbEncryptedFile.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All file|*.*";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(535, 252);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 41);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbbBlockSize
            // 
            this.cbbBlockSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBlockSize.FormattingEnabled = true;
            this.cbbBlockSize.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.cbbBlockSize.Location = new System.Drawing.Point(31, 42);
            this.cbbBlockSize.Name = "cbbBlockSize";
            this.cbbBlockSize.Size = new System.Drawing.Size(75, 21);
            this.cbbBlockSize.TabIndex = 8;
            this.cbbBlockSize.SelectedIndexChanged += new System.EventHandler(this.cbbBlockSize_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Block size (bit):";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(277, 42);
            this.tbKey.MaxLength = 16;
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(214, 20);
            this.tbKey.TabIndex = 10;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(274, 15);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(78, 13);
            this.labelKey.TabIndex = 12;
            this.labelKey.Text = "Key (16 chars):";
            // 
            // tbIV
            // 
            this.tbIV.Location = new System.Drawing.Point(497, 42);
            this.tbIV.MaxLength = 16;
            this.tbIV.Name = "tbIV";
            this.tbIV.Size = new System.Drawing.Size(214, 20);
            this.tbIV.TabIndex = 13;
            // 
            // labelIV
            // 
            this.labelIV.AutoSize = true;
            this.labelIV.Location = new System.Drawing.Point(494, 15);
            this.labelIV.Name = "labelIV";
            this.labelIV.Size = new System.Drawing.Size(116, 13);
            this.labelIV.TabIndex = 14;
            this.labelIV.Text = "IV (16 chars) - optional:";
            // 
            // cbbPadding
            // 
            this.cbbPadding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPadding.FormattingEnabled = true;
            this.cbbPadding.Items.AddRange(new object[] {
            "PKCS7",
            "X923",
            "ISO10126"});
            this.cbbPadding.Location = new System.Drawing.Point(121, 42);
            this.cbbPadding.Name = "cbbPadding";
            this.cbbPadding.Size = new System.Drawing.Size(62, 21);
            this.cbbPadding.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mode:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Padding:";
            // 
            // cbbMode
            // 
            this.cbbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMode.FormattingEnabled = true;
            this.cbbMode.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "OFB",
            "CFB",
            "CTS"});
            this.cbbMode.Location = new System.Drawing.Point(199, 42);
            this.cbbMode.Name = "cbbMode";
            this.cbbMode.Size = new System.Drawing.Size(62, 21);
            this.cbbMode.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 316);
            this.Controls.Add(this.cbbMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbPadding);
            this.Controls.Add(this.labelIV);
            this.Controls.Add(this.tbIV);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbBlockSize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPassword);
            this.Name = "MainForm";
            this.Text = "Rijndael";
            this.grbPassword.ResumeLayout(false);
            this.grbPassword.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlainFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.GroupBox grbPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEncryptedFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbbBlockSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Button btnBrowsePlainFile;
        private System.Windows.Forms.Button btnDescrypt;
        private System.Windows.Forms.Button btnBrowseEncryptedFile;
        private System.Windows.Forms.TextBox tbIV;
        private System.Windows.Forms.Label labelIV;
        private System.Windows.Forms.ComboBox cbbPadding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbMode;
    }
}

