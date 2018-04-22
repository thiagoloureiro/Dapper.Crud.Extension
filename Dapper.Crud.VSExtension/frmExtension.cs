using Dapper.Crud.VSExtension.Helpers;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Dapper.Crud.VSExtension
{
    public partial class frmExtension : Form
    {
        public string Projectpath;

        public frmExtension()
        {
            InitializeComponent();
            SetTxtStyles();
            LoadFiles();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Log("Initializing generation process...");

                txtOutput.Text = string.Empty;
                foreach (var item in lstFiles.CheckedItems)
                {
                    var model = item.ToString();
                    IList<PropertyInfo> properties = GetPropertyInfos(model);
                    string output = string.Empty;

                    if (chkClass.Checked)
                    {
                        output += ClassGenerator.GenerateClassBody(model, chkInterface.Checked);

                        if (chkSelect.Checked)
                            output += MethodGenerator.GenerateSelect(
                                DapperGenerator.Select(model, properties, chkGenerateMethod.Checked, chkClass.Checked),
                                model, chkClass.Checked);

                        if (chkInsert.Checked)
                            output += MethodGenerator.GenerateInsert(
                                DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked),
                                model, chkClass.Checked);

                        if (chkUpdate.Checked)
                            output += MethodGenerator.GenerateUpdate(
                                DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked),
                                model, chkClass.Checked);

                        if (chkDelete.Checked)
                            output += MethodGenerator.GenerateDelete(
                                DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked),
                                model, chkClass.Checked);

                        output += "}";

                        txtOutput.Text += output;

                        if (chkGenerateFiles.Checked)
                            FileHelper.GenerateClass(output, model, Projectpath);
                    }
                    else
                    {
                        if (chkGenerateMethod.Checked)
                        {
                            if (chkSelect.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateSelect(DapperGenerator.Select(model, properties, chkGenerateMethod.Checked, chkClass.Checked), model, chkClass.Checked);

                            if (chkInsert.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateInsert(DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked), model, chkClass.Checked);

                            if (chkUpdate.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateUpdate(DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked), model, chkClass.Checked);

                            if (chkDelete.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateDelete(DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked), model, chkClass.Checked);
                        }
                        else
                        {
                            if (chkSelect.Checked)
                                txtOutput.Text += DapperGenerator.Select(model, properties, chkGenerateMethod.Checked, chkClass.Checked);

                            if (chkInsert.Checked)
                                txtOutput.Text += DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked);

                            if (chkUpdate.Checked)
                                txtOutput.Text += DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked);

                            if (chkDelete.Checked)
                                txtOutput.Text += DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked);
                        }
                    }

                    if (chkInterface.Checked)
                    {
                        output = InterfaceGenerator.GenerateInterfaceBody(model);

                        if (chkSelect.Checked)
                            output += InterfaceGenerator.GenerateSelect(model);

                        if (chkInsert.Checked)
                            output += InterfaceGenerator.GenerateInsert(model);

                        if (chkUpdate.Checked)
                            output += InterfaceGenerator.GenerateUpdate(model);

                        if (chkDelete.Checked)
                            output += InterfaceGenerator.GenerateDelete(model);

                        output += "}";

                        txtOutput.Text += output;

                        if (chkGenerateFiles.Checked)
                            FileHelper.GenerateInterface(output, model, Projectpath);
                    }
                }
                Logger.Log($"Process Completed Successfully!");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error during the operation: {ex.Message} InnerException {ex.InnerException} StackTrace {ex.StackTrace}");
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
            LoadFiles();
        }

        private void LoadFiles()
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            chkSelect.Checked = true;
            chkInsert.Checked = true;
            chkUpdate.Checked = true;
            chkDelete.Checked = true;
        }

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            chkGenerateMethod.Checked = chkClass.Checked;
        }
    }
}