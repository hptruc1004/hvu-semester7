namespace MHTT
{
    partial class BaiTap1
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
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbDocFile = new System.Windows.Forms.TextBox();
            this.openDocFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.rbKoCoDau = new System.Windows.Forms.RadioButton();
            this.rbCoDau = new System.Windows.Forms.RadioButton();
            this.gbCount = new System.Windows.Forms.GroupBox();
            this.cbCount = new System.Windows.Forms.ComboBox();
            this.gbCondition.SuspendLayout();
            this.gbCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbContent.DetectUrls = false;
            this.rtbContent.Location = new System.Drawing.Point(1, 126);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(545, 214);
            this.rtbContent.TabIndex = 0;
            this.rtbContent.Text = "";
            this.rtbContent.WordWrap = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(373, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbDocFile
            // 
            this.tbDocFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocFile.Location = new System.Drawing.Point(12, 14);
            this.tbDocFile.Name = "tbDocFile";
            this.tbDocFile.Size = new System.Drawing.Size(346, 20);
            this.tbDocFile.TabIndex = 2;
            // 
            // openDocFileDialog
            // 
            this.openDocFileDialog.Filter = "Doc file|*.doc";
            this.openDocFileDialog.Title = "Open file";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiagnostic.Location = new System.Drawing.Point(461, 12);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(75, 23);
            this.btnDiagnostic.TabIndex = 3;
            this.btnDiagnostic.Text = "Diagnostic";
            this.btnDiagnostic.UseVisualStyleBackColor = true;
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.rbKoCoDau);
            this.gbCondition.Controls.Add(this.rbCoDau);
            this.gbCondition.Location = new System.Drawing.Point(12, 40);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(286, 64);
            this.gbCondition.TabIndex = 4;
            this.gbCondition.TabStop = false;
            this.gbCondition.Text = "Condition";
            // 
            // rbKoCoDau
            // 
            this.rbKoCoDau.AutoSize = true;
            this.rbKoCoDau.Checked = true;
            this.rbKoCoDau.Location = new System.Drawing.Point(172, 29);
            this.rbKoCoDau.Name = "rbKoCoDau";
            this.rbKoCoDau.Size = new System.Drawing.Size(92, 17);
            this.rbKoCoDau.TabIndex = 1;
            this.rbKoCoDau.TabStop = true;
            this.rbKoCoDau.Text = "Khong co dau";
            this.rbKoCoDau.UseVisualStyleBackColor = true;
            this.rbKoCoDau.CheckedChanged += new System.EventHandler(this.rbKoCoDau_CheckedChanged);
            // 
            // rbCoDau
            // 
            this.rbCoDau.AutoSize = true;
            this.rbCoDau.Location = new System.Drawing.Point(29, 29);
            this.rbCoDau.Name = "rbCoDau";
            this.rbCoDau.Size = new System.Drawing.Size(59, 17);
            this.rbCoDau.TabIndex = 0;
            this.rbCoDau.Text = "Co dau";
            this.rbCoDau.UseVisualStyleBackColor = true;
            this.rbCoDau.CheckedChanged += new System.EventHandler(this.rbCoDau_CheckedChanged);
            // 
            // gbCount
            // 
            this.gbCount.Controls.Add(this.cbCount);
            this.gbCount.Location = new System.Drawing.Point(317, 41);
            this.gbCount.Name = "gbCount";
            this.gbCount.Size = new System.Drawing.Size(219, 63);
            this.gbCount.TabIndex = 5;
            this.gbCount.TabStop = false;
            this.gbCount.Text = "Count";
            // 
            // cbCount
            // 
            this.cbCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCount.FormattingEnabled = true;
            this.cbCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbCount.Location = new System.Drawing.Point(56, 27);
            this.cbCount.Name = "cbCount";
            this.cbCount.Size = new System.Drawing.Size(121, 21);
            this.cbCount.TabIndex = 0;
            this.cbCount.SelectedIndexChanged += new System.EventHandler(this.cbCount_SelectedIndexChanged);
            // 
            // BaiTap1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 343);
            this.Controls.Add(this.gbCount);
            this.Controls.Add(this.gbCondition);
            this.Controls.Add(this.btnDiagnostic);
            this.Controls.Add(this.tbDocFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.rtbContent);
            this.Name = "BaiTap1";
            this.Text = "Form1";
            this.gbCondition.ResumeLayout(false);
            this.gbCondition.PerformLayout();
            this.gbCount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbDocFile;
        private System.Windows.Forms.OpenFileDialog openDocFileDialog;
        private System.Windows.Forms.Button btnDiagnostic;
        private System.Windows.Forms.GroupBox gbCondition;
        private System.Windows.Forms.RadioButton rbKoCoDau;
        private System.Windows.Forms.RadioButton rbCoDau;
        private System.Windows.Forms.GroupBox gbCount;
        private System.Windows.Forms.ComboBox cbCount;
    }
}

