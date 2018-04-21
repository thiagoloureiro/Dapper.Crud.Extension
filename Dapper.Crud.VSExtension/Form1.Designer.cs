namespace Dapper.Crud.VSExtension
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.CheckedListBox();
            this.chkGenerateClass = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOutput = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 41);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(251, 184);
            this.lstFiles.TabIndex = 1;
            // 
            // chkGenerateClass
            // 
            this.chkGenerateClass.AutoSize = true;
            this.chkGenerateClass.Location = new System.Drawing.Point(270, 41);
            this.chkGenerateClass.Name = "chkGenerateClass";
            this.chkGenerateClass.Size = new System.Drawing.Size(98, 17);
            this.chkGenerateClass.TabIndex = 2;
            this.chkGenerateClass.Text = "Generate Class";
            this.chkGenerateClass.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(269, 87);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(66, 17);
            this.chkInsert.TabIndex = 3;
            this.chkInsert.Text = "INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(269, 64);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(67, 17);
            this.chkSelect.TabIndex = 4;
            this.chkSelect.Text = "SELECT";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(269, 133);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "DELETE";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(269, 110);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "UPDATE";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(269, 202);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Lexer = ScintillaNET.Lexer.Cpp;
            this.txtOutput.Location = new System.Drawing.Point(385, 41);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(804, 610);
            this.txtOutput.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 663);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.chkInsert);
            this.Controls.Add(this.chkGenerateClass);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox lstFiles;
        private System.Windows.Forms.CheckBox chkGenerateClass;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnGenerate;
        private ScintillaNET.Scintilla txtOutput;
    }
}