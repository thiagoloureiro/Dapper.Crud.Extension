﻿using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class AssemblyHelper
    {
        private static Assembly BuildAssembly(string code)
        {
            using (var compiler = new Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider())
            {
                //Clean up
                Environment.SetEnvironmentVariable("ROSLYN_COMPILER_LOCATION", null, EnvironmentVariableTarget.Process);

                var compilerparams = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };

                compilerparams.ReferencedAssemblies.Add("System.dll");
                compilerparams.ReferencedAssemblies.Add("System.Core.dll");
                compilerparams.ReferencedAssemblies.Add("System.Data.dll");
                compilerparams.ReferencedAssemblies.Add("System.Data.Linq.dll");
                compilerparams.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                compilerparams.ReferencedAssemblies.Add("System.Xml.dll");
                compilerparams.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                compilerparams.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerparams.ReferencedAssemblies.Add("System.ComponentModel.DataAnnotations.dll");
                compilerparams.ReferencedAssemblies.Add("System.Web.dll");
                compilerparams.ReferencedAssemblies.Add("System.Web.Abstractions.dll");
                // compilerparams.ReferencedAssemblies.Add("System.Web.Mvc.dll");
                // compilerparams.ReferencedAssemblies.Add("System.Web.Optimization.dll");

                CompilerResults results =
                    compiler.CompileAssemblyFromSource(compilerparams, code);
                if (results.Errors.HasErrors)
                {
                    StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                    foreach (CompilerError error in results.Errors)
                    {
                        errors.Append($"Line {error.Line},{error.Column}\t: {error.ErrorText}\n");
                    }

                    compiler.Dispose();

                    throw new Exception(errors.ToString());
                }
                else
                {
                    return results.CompiledAssembly;
                }
            }
        }

        public static object ExecuteCode(string code, string namespacename, string classname, bool isstatic)
        {
            Assembly asm = BuildAssembly(code);
            classname = FixClassName(classname);

            object instance = null;
            Type type = null;

            if (isstatic)
            {
                type = asm.GetType(namespacename + "." + classname);
            }
            else
            {
                instance = asm.CreateInstance(namespacename + "." + classname);
                type = instance.GetType();
            }
            return instance;
        }

        private static string FixClassName(string classname)
        {
            if (classname.Contains("\\"))
            {
                var str = classname.Split('\\');
                classname = str.Last(); // last item of the array
            }
            return classname;
        }
    }
}