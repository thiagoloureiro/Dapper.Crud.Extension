using Dapper.Crud.VSExtension.Helpers;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Dapper.Crud.VSExtension
{
    public partial class frmExtension : Form
    {
        public string Projectpath;
        public string RawContent;
        public bool _darkMode = false;

        public frmExtension()
        {
            InitializeComponent();
            SetTxtStyles();
            LoadFiles();
            picLoader.Visible = false;
        }

        private static string GetAssemblyLocalPathFrom(Type type)
        {
            string codebase = type.Assembly.CodeBase;
            var uri = new Uri(codebase, UriKind.Absolute);
            return uri.LocalPath;
        }

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var threadInput = new Thread(GenerateCrud);
            threadInput.Start();
        }

        private void GenerateCrud()
        {
            try
            {
                Logger.Log("Initializing generation process...");
                SetLoading(true);

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
                        {
                            output += MethodGenerator.GenerateSelect(
                                DapperGenerator.Select(model, properties, chkGenerateMethod.Checked, chkClass.Checked,
                                    chkAsync.Checked, chkAwaitUsing.Checked),
                                model, chkClass.Checked, chkAsync.Checked);

                            output += MethodGenerator.GenerateSelectById(
                                DapperGenerator.SelectById(model, properties, chkGenerateMethod.Checked, chkClass.Checked,
                                    chkAsync.Checked, chkAwaitUsing.Checked),
                                model, chkClass.Checked, chkAsync.Checked);
                        }

                        if (chkInsert.Checked)
                            output += MethodGenerator.GenerateInsert(
                                DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkReturnIdentity.Checked, chkAwaitUsing.Checked),
                                model, chkClass.Checked, chkAsync.Checked, chkReturnIdentity.Checked);

                        if (chkUpdate.Checked)
                            output += MethodGenerator.GenerateUpdate(
                                DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkAwaitUsing.Checked),
                                model, chkClass.Checked, chkAsync.Checked);

                        if (chkDelete.Checked)
                            output += MethodGenerator.GenerateDelete(
                                DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked),
                                model, chkClass.Checked, chkAsync.Checked);

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
                            {
                                txtOutput.Text +=
                                    MethodGenerator.GenerateSelect(
                                        DapperGenerator.Select(model, properties, chkGenerateMethod.Checked,
                                            chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked), model,
                                        chkClass.Checked, chkAsync.Checked);

                                txtOutput.Text +=
                                    MethodGenerator.GenerateSelectById(
                                        DapperGenerator.Select(model, properties, chkGenerateMethod.Checked,
                                            chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked), model,
                                        chkClass.Checked, chkAsync.Checked);
                            }

                            if (chkInsert.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateInsert(DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkReturnIdentity.Checked, chkAwaitUsing.Checked), model, chkClass.Checked, chkAsync.Checked, chkReturnIdentity.Checked);

                            if (chkUpdate.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateUpdate(DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkAwaitUsing.Checked), model, chkClass.Checked, chkAsync.Checked);

                            if (chkDelete.Checked)
                                txtOutput.Text +=
                                    MethodGenerator.GenerateDelete(DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked), model, chkClass.Checked, chkAsync.Checked);
                        }
                        else
                        {
                            if (chkSelect.Checked)
                                txtOutput.Text += DapperGenerator.Select(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked);

                            if (chkInsert.Checked)
                                txtOutput.Text += DapperGenerator.Insert(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkReturnIdentity.Checked, chkAwaitUsing.Checked);

                            if (chkUpdate.Checked)
                                txtOutput.Text += DapperGenerator.Update(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAutoIncrement.Checked, chkAsync.Checked, chkAwaitUsing.Checked);

                            if (chkDelete.Checked)
                                txtOutput.Text += DapperGenerator.Delete(model, properties, chkGenerateMethod.Checked, chkClass.Checked, chkAsync.Checked, chkAwaitUsing.Checked);
                        }
                    }

                    if (chkInterface.Checked)
                    {
                        output = InterfaceGenerator.GenerateInterfaceBody(model);

                        if (chkSelect.Checked)
                        {
                            output += InterfaceGenerator.GenerateSelect(model, chkAsync.Checked);
                            output += InterfaceGenerator.GenerateSelectById(model, chkAsync.Checked);
                        }
                        if (chkInsert.Checked)
                            output += InterfaceGenerator.GenerateInsert(model, chkAsync.Checked, chkReturnIdentity.Checked);

                        if (chkUpdate.Checked)
                            output += InterfaceGenerator.GenerateUpdate(model, chkAsync.Checked);

                        if (chkDelete.Checked)
                            output += InterfaceGenerator.GenerateDelete(model, chkAsync.Checked);

                        output += "}";

                        txtOutput.Text += output;

                        if (chkGenerateFiles.Checked)
                            FileHelper.GenerateInterface(output, model, Projectpath);
                    }
                }
                SetLoading(false);
                Logger.Log($"Process Completed Successfully!");
            }
            catch (Exception ex)
            {
                SetLoading(false);
                Logger.Log($"Error during the operation: {ex.Message} InnerException {ex.InnerException} StackTrace {ex.StackTrace} Code {AssemblyHelper.codeGlobal}");
                txtOutputLog.ForeColor = Color.Red;
                txtOutputLog.Text = $"Error during the operation: {ex.Message} InnerException {ex.InnerException} StackTrace {ex.StackTrace} Code {AssemblyHelper.codeGlobal}";
            }
        }

        private void SetTxtStyles()
        {
            txtOutput.StyleResetDefault();
            txtOutput.Styles[Style.Default].Font = "Consolas";
            txtOutput.Styles[Style.Default].Size = 10;
            txtOutput.StyleClearAll();

            if (_darkMode)
            {
                // Configure the CPP (C#) lexer styles
                txtOutput.Styles[Style.Cpp.Default].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Default].ForeColor = Color.Pink;
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

                txtOutput.Styles[Style.Cpp.Comment].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.CommentLine].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.CommentLineDoc].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Number].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Word].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Word2].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.String].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Character].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Verbatim].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.StringEol].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Operator].BackColor = Color.FromArgb(41, 41, 41);
                txtOutput.Styles[Style.Cpp.Preprocessor].BackColor = Color.FromArgb(41, 41, 41);
            }
            else
            {
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

            var fileList = filteredList.ToList();
            foreach (var file in fileList)
            {
                var model = file.Replace(Projectpath, "").Replace(".cs", "");

                if (!model.Contains(@"obj\"))
                    lstFiles.Items.Add(model);
            }

            RawContent = FileHelper.GenerateRawStringAllFiles(fileList);
        }

        private IList<PropertyInfo> GetPropertyInfos(string model)
        {
            var installationPath = GetAssemblyLocalPathFrom(typeof(CreateCrudPackage));
            installationPath = installationPath.Replace("Dapper.Crud.VSExtension.dll", "");

            Environment.SetEnvironmentVariable("ROSLYN_COMPILER_LOCATION", installationPath + "\\roslyn", EnvironmentVariableTarget.Process);

            Assembly.LoadFrom(installationPath + "System.Web.Optimization.dll");
            Assembly.LoadFrom(installationPath + "System.Web.Mvc.dll");
            Assembly.LoadFrom(installationPath + "Dapper.Contrib.dll");
            Assembly.LoadFrom(installationPath + "Microsoft.AspNetCore.Mvc.dll");

            var file = Projectpath + model + ".cs";
            var objectModel = ModelHelper.Generate(CleanupAttributes(File.ReadAllLines(file)), CleanupAttributes(RawContent), model);
            var props = new List<PropertyInfo>(objectModel.GetType().GetProperties());

            var types = ModelHelper.Types();

            foreach (var prop in props.ToList())
            {
                if (!types.Contains(prop.PropertyType.Name.ToLower()))
                {
                    props.Remove(prop);
                }
            }

            var sortedProps = SortProperties(props);

            return sortedProps;
        }

        private string[] CleanupAttributes(string[] content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                content[i] = content[i].Trim().Replace("[HiddenInput", "//[HiddenInput");
                content[i] = content[i].Trim().Replace("[DisplayValue", "//[DisplayValue");
                content[i] = content[i].Trim().Replace("[ErrorMessage", "//[ErrorMessage");
                content[i] = content[i].Trim().Replace("[Required", "//[Required");
            }

            return content;
        }

        private string CleanupAttributes(string content)
        {
            content = content.Replace("[HiddenInput", "//[HiddenInput");
            content = content.Replace("[DisplayValue", "//[DisplayValue");
            content = content.Replace("[ErrorMessage", "//[ErrorMessage");
            content = content.Replace("[Required", "//[Required");

            return content;
        }

        private IList<PropertyInfo> SortProperties(IList<PropertyInfo> prop)
        {
            List<PropertyInfo> sortedProp = new List<PropertyInfo>();

            foreach (var p in prop)
            {
                if (p.Name == "Id")
                {
                    sortedProp.Add(p);
                    break;
                }
            }
            foreach (var p in prop)
            {
                if (p.Name != "Id")
                {
                    sortedProp.Add(p);
                }
            }

            return sortedProp;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ko-fi.com/thiagoguaru");
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            SetTxtStyles();
            if (!_darkMode)
            {
                this.BackColor = SystemColors.Control;

                foreach (Control child in this.Controls)
                {
                    child.ForeColor = Color.Black;
                    txtOutput.BackColor = SystemColors.Control;
                    txtOutputLog.BackColor = SystemColors.Control;
                    lstFiles.BackColor = SystemColors.Control;
                }

                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.BackColor = SystemColors.Control;
                }
            }
            else
            {
                this.BackColor = Color.FromArgb(41, 41, 41);

                foreach (Control child in this.Controls)
                {
                    child.ForeColor = Color.WhiteSmoke;
                    txtOutputLog.BackColor = Color.FromArgb(41, 41, 41);
                    lstFiles.BackColor = Color.FromArgb(41, 41, 41);
                }

                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.BackColor = Color.FromArgb(100, 100, 100);
                    button.FlatStyle = FlatStyle.Flat;

                    button.FlatAppearance.BorderColor = Color.DarkGray;
                }
            }
            btnChangeMode.Text = _darkMode ? "White mode" : "Dark mode";
            _darkMode = !_darkMode;
        }

        private void SelectAllClass_Click(object sender, EventArgs e)
        {
            chkClass.Checked = true;
            chkGenerateMethod.Checked = true;
            chkAsync.Checked = true;
            chkInterface.Checked = true;
            chkAwaitUsing.Checked = true;
        }
    }
}