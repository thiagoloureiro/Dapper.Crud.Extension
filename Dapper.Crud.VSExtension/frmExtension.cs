using Dapper.Crud.VSExtension.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ScintillaNET;

namespace Dapper.Crud.VSExtension
{
    public partial class frmExtension : Form
    {
        public string Projectpath;

        public frmExtension()
        {
            InitializeComponent();
            SetTxtStyles();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtOutput.Text = string.Empty;
            foreach (var item in lstFiles.CheckedItems)
            {
                var model = item.ToString();
                IList<PropertyInfo> properties = GetPropertyInfos(model);

                if (chkClass.Checked)
                {
                    string output = ClassGenerator.Generate(MethodGenerator.GenerateSelect(DapperGenerator.Select(model, properties), model), model, chkInterface.Checked);
                    txtOutput.Text += output;

                    if (chkGenerateFiles.Checked)
                        FileHelper.GenerateClass(output, model, Projectpath);
                }
                else
                {
                    if (chkGenerateMethod.Checked)
                        txtOutput.Text += MethodGenerator.GenerateSelect(DapperGenerator.Select(model, properties), model);
                    else
                        txtOutput.Text += DapperGenerator.Select(model, properties);
                }

                if (chkInterface.Checked)
                {
                    string output = InterfaceGenerator.GenerateSelect(model);
                    txtOutput.Text += output;

                    if (chkGenerateFiles.Checked)
                        FileHelper.GenerateInterface(output, model, Projectpath);
                }
            }
        }

        private void SetTxtStyles()
        {
            txtOutput.StyleResetDefault();
            txtOutput.Styles[Style.Default].Font = "Consolas";
            txtOutput.Styles[Style.Default].Size = 10;
            txtOutput.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            txtOutput.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            txtOutput.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            txtOutput.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            txtOutput.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            txtOutput.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            txtOutput.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            txtOutput.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            txtOutput.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            txtOutput.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            txtOutput.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            txtOutput.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            txtOutput.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            txtOutput.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            var project = ProjectHelpers.GetActiveProject();

            Projectpath = project.GetFullPath();

            var files = Directory.GetFiles(Projectpath, "*.cs", SearchOption.AllDirectories).ToList();
            var filteredList = FileHelper.FilterFileList(files);

            foreach (var file in filteredList)
            {
                var model = file.Replace(Projectpath, "").Replace(".cs", "");
                lstFiles.Items.Add(model);
            }
        }

        private IList<PropertyInfo> GetPropertyInfos(string model)
        {
            var file = Projectpath + model + ".cs";
            var objectModel = ModelHelper.Generate(File.ReadAllLines(file), File.ReadAllText(file), model);
            IList<PropertyInfo> props = new List<PropertyInfo>(objectModel.GetType().GetProperties());
            return props;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = string.Empty;
        }
    }
}