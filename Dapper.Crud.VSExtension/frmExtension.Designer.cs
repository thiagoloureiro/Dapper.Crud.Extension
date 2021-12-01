namespace Dapper.Crud.VSExtension
{
    partial class frmExtension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtension));
            this.btnLoad = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.CheckedListBox();
            this.chkGenerateMethod = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOutput = new ScintillaNET.Scintilla();
            this.chkInterface = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.chkGenerateFiles = new System.Windows.Forms.CheckBox();
            this.chkAutoIncrement = new System.Windows.Forms.CheckBox();
            this.gBox = new System.Windows.Forms.GroupBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAsync = new System.Windows.Forms.CheckBox();
            this.lblAutoIncrement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputLog = new System.Windows.Forms.TextBox();
            this.picLoader = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnChangeMode = new System.Windows.Forms.Button();
            this.chkReturnIdentity = new System.Windows.Forms.CheckBox();
            this.gBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(16, 7);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Refresh";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(16, 41);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(355, 259);
            this.lstFiles.TabIndex = 1;
            this.lstFiles.ThreeDCheckBoxes = true;
            // 
            // chkGenerateMethod
            // 
            this.chkGenerateMethod.AutoSize = true;
            this.chkGenerateMethod.Location = new System.Drawing.Point(8, 52);
            this.chkGenerateMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGenerateMethod.Name = "chkGenerateMethod";
            this.chkGenerateMethod.Size = new System.Drawing.Size(133, 20);
            this.chkGenerateMethod.TabIndex = 2;
            this.chkGenerateMethod.Text = "Generate Method";
            this.chkGenerateMethod.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(8, 52);
            this.chkInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(79, 20);
            this.chkInsert.TabIndex = 3;
            this.chkInsert.Text = "INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(8, 23);
            this.chkSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(81, 20);
            this.chkSelect.TabIndex = 4;
            this.chkSelect.Text = "SELECT";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(8, 108);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(82, 20);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "DELETE";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(8, 80);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(85, 20);
            this.chkUpdate.TabIndex = 6;
            this.chkUpdate.Text = "UPDATE";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.LightGreen;
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(143, 656);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(112, 37);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.IndentationGuides = ScintillaNET.IndentView.Real;
            this.txtOutput.Lexer = ScintillaNET.Lexer.Cpp;
            this.txtOutput.Location = new System.Drawing.Point(380, 41);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(1311, 681);
            this.txtOutput.TabIndex = 9;
            // 
            // chkInterface
            // 
            this.chkInterface.AutoSize = true;
            this.chkInterface.Location = new System.Drawing.Point(8, 80);
            this.chkInterface.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInterface.Name = "chkInterface";
            this.chkInterface.Size = new System.Drawing.Size(139, 20);
            this.chkInterface.TabIndex = 10;
            this.chkInterface.Text = "Generate Interface";
            this.chkInterface.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1592, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Text";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Location = new System.Drawing.Point(8, 23);
            this.chkClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(122, 20);
            this.chkClass.TabIndex = 12;
            this.chkClass.Text = "Generate Class";
            this.chkClass.UseVisualStyleBackColor = true;
            this.chkClass.CheckedChanged += new System.EventHandler(this.chkClass_CheckedChanged);
            // 
            // chkGenerateFiles
            // 
            this.chkGenerateFiles.AutoSize = true;
            this.chkGenerateFiles.Enabled = false;
            this.chkGenerateFiles.Location = new System.Drawing.Point(16, 330);
            this.chkGenerateFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGenerateFiles.Name = "chkGenerateFiles";
            this.chkGenerateFiles.Size = new System.Drawing.Size(117, 20);
            this.chkGenerateFiles.TabIndex = 13;
            this.chkGenerateFiles.Text = "Generate Files";
            this.chkGenerateFiles.UseVisualStyleBackColor = true;
            // 
            // chkAutoIncrement
            // 
            this.chkAutoIncrement.AutoSize = true;
            this.chkAutoIncrement.Location = new System.Drawing.Point(104, 52);
            this.chkAutoIncrement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAutoIncrement.Name = "chkAutoIncrement";
            this.chkAutoIncrement.Size = new System.Drawing.Size(121, 20);
            this.chkAutoIncrement.TabIndex = 14;
            this.chkAutoIncrement.Text = "AutoIncrement?";
            this.chkAutoIncrement.UseVisualStyleBackColor = true;
            // 
            // gBox
            // 
            this.gBox.Controls.Add(this.btnSelectAll);
            this.gBox.Controls.Add(this.chkUpdate);
            this.gBox.Controls.Add(this.chkAutoIncrement);
            this.gBox.Controls.Add(this.chkInsert);
            this.gBox.Controls.Add(this.chkSelect);
            this.gBox.Controls.Add(this.chkDelete);
            this.gBox.Location = new System.Drawing.Point(16, 506);
            this.gBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBox.Name = "gBox";
            this.gBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBox.Size = new System.Drawing.Size(356, 143);
            this.gBox.TabIndex = 15;
            this.gBox.TabStop = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(159, 0);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(100, 28);
            this.btnSelectAll.TabIndex = 17;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAsync);
            this.groupBox1.Controls.Add(this.chkClass);
            this.groupBox1.Controls.Add(this.chkGenerateMethod);
            this.groupBox1.Controls.Add(this.chkInterface);
            this.groupBox1.Location = new System.Drawing.Point(16, 358);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(267, 140);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // chkAsync
            // 
            this.chkAsync.AutoSize = true;
            this.chkAsync.Location = new System.Drawing.Point(8, 108);
            this.chkAsync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAsync.Name = "chkAsync";
            this.chkAsync.Size = new System.Drawing.Size(66, 20);
            this.chkAsync.TabIndex = 13;
            this.chkAsync.Text = "Async";
            this.chkAsync.UseVisualStyleBackColor = true;
            // 
            // lblAutoIncrement
            // 
            this.lblAutoIncrement.AutoSize = true;
            this.lblAutoIncrement.Location = new System.Drawing.Point(16, 697);
            this.lblAutoIncrement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoIncrement.Name = "lblAutoIncrement";
            this.lblAutoIncrement.Size = new System.Drawing.Size(220, 16);
            this.lblAutoIncrement.TabIndex = 17;
            this.lblAutoIncrement.Text = "When AutoIncrement is selected (Id)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 713);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "fields will not be added to insert/update clauses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 735);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Output Log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1377, 726);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "If you find errors please open an issue on GitHub";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtOutputLog
            // 
            this.txtOutputLog.Location = new System.Drawing.Point(8, 756);
            this.txtOutputLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputLog.Multiline = true;
            this.txtOutputLog.Name = "txtOutputLog";
            this.txtOutputLog.Size = new System.Drawing.Size(1489, 125);
            this.txtOutputLog.TabIndex = 24;
            // 
            // picLoader
            // 
            this.picLoader.Image = ((System.Drawing.Image)(resources.GetObject("picLoader.Image")));
            this.picLoader.Location = new System.Drawing.Point(881, 316);
            this.picLoader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picLoader.Name = "picLoader";
            this.picLoader.Size = new System.Drawing.Size(173, 160);
            this.picLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoader.TabIndex = 25;
            this.picLoader.TabStop = false;
            this.picLoader.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Location = new System.Drawing.Point(1507, 865);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(130, 20);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Buy me a kofi <3";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Location = new System.Drawing.Point(1539, 793);
            this.btnChangeMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(100, 28);
            this.btnChangeMode.TabIndex = 29;
            this.btnChangeMode.Text = "Dark Mode :D";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Visible = false;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // chkReturnIdentity
            // 
            this.chkReturnIdentity.AutoSize = true;
            this.chkReturnIdentity.Location = new System.Drawing.Point(257, 558);
            this.chkReturnIdentity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkReturnIdentity.Name = "chkReturnIdentity";
            this.chkReturnIdentity.Size = new System.Drawing.Size(88, 20);
            this.chkReturnIdentity.TabIndex = 18;
            this.chkReturnIdentity.Text = "InsertedId";
            this.chkReturnIdentity.UseVisualStyleBackColor = true;
            // 
            // frmExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 898);
            this.Controls.Add(this.chkReturnIdentity);
            this.Controls.Add(this.btnChangeMode);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picLoader);
            this.Controls.Add(this.txtOutputLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAutoIncrement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBox);
            this.Controls.Add(this.chkGenerateFiles);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExtension";
            this.Text = "Dapper Extension 3.0.10";
            this.gBox.ResumeLayout(false);
            this.gBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckedListBox lstFiles;
        private System.Windows.Forms.CheckBox chkGenerateMethod;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.Button btnGenerate;
        private ScintillaNET.Scintilla txtOutput;
        private System.Windows.Forms.CheckBox chkInterface;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkClass;
        private System.Windows.Forms.CheckBox chkGenerateFiles;
        private System.Windows.Forms.CheckBox chkAutoIncrement;
        private System.Windows.Forms.GroupBox gBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label lblAutoIncrement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputLog;
        private System.Windows.Forms.PictureBox picLoader;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkAsync;
        private System.Windows.Forms.Button btnChangeMode;
        private System.Windows.Forms.CheckBox chkReturnIdentity;
    }
}