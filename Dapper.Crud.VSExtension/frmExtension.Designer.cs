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
            this.btnLoad = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.CheckedListBox();
            this.chkGenerateMethod = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtOutput = new ScintillaNET.Scintilla();
            this.chkInterface = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkClass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Refresh";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 41);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(251, 244);
            this.lstFiles.TabIndex = 1;
            this.lstFiles.ThreeDCheckBoxes = true;
            // 
            // chkGenerateMethod
            // 
            this.chkGenerateMethod.AutoSize = true;
            this.chkGenerateMethod.Location = new System.Drawing.Point(269, 66);
            this.chkGenerateMethod.Name = "chkGenerateMethod";
            this.chkGenerateMethod.Size = new System.Drawing.Size(109, 17);
            this.chkGenerateMethod.TabIndex = 2;
            this.chkGenerateMethod.Text = "Generate Method";
            this.chkGenerateMethod.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(269, 195);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(66, 17);
            this.chkInsert.TabIndex = 3;
            this.chkInsert.Text = "INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(269, 172);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(67, 17);
            this.chkSelect.TabIndex = 4;
            this.chkSelect.Text = "SELECT";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(269, 241);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "DELETE";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(269, 218);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "UPDATE";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(269, 262);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.IndentationGuides = ScintillaNET.IndentView.Real;
            this.txtOutput.Lexer = ScintillaNET.Lexer.Cpp;
            this.txtOutput.Location = new System.Drawing.Point(390, 41);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(799, 610);
            this.txtOutput.TabIndex = 9;
            // 
            // chkInterface
            // 
            this.chkInterface.AutoSize = true;
            this.chkInterface.Location = new System.Drawing.Point(269, 89);
            this.chkInterface.Name = "chkInterface";
            this.chkInterface.Size = new System.Drawing.Size(115, 17);
            this.chkInterface.TabIndex = 10;
            this.chkInterface.Text = "Generate Interface";
            this.chkInterface.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1114, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Text";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Location = new System.Drawing.Point(269, 43);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(98, 17);
            this.chkClass.TabIndex = 12;
            this.chkClass.Text = "Generate Class";
            this.chkClass.UseVisualStyleBackColor = true;
            // 
            // frmExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 663);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkInterface);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.chkInsert);
            this.Controls.Add(this.chkGenerateMethod);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnLoad);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExtension";
            this.Text = "Dapper Extension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckedListBox lstFiles;
        private System.Windows.Forms.CheckBox chkGenerateMethod;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnGenerate;
        private ScintillaNET.Scintilla txtOutput;
        private System.Windows.Forms.CheckBox chkInterface;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkClass;
    }
}