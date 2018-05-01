using Microsoft.CSharp;
using System;
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
            CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();

            CompilerParameters compilerparams = new CompilerParameters
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

            CompilerResults results =
                compiler.CompileAssemblyFromSource(compilerparams, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors)
                {
                    errors.Append($"Line {error.Line},{error.Column}\t: {error.ErrorText}\n");
                }
                throw new Exception(errors.ToString());
            }
            else
            {
                return results.CompiledAssembly;
            }
        }

        public static object ExecuteCode(string code, string namespacename, string classname, bool isstatic)
        {
            object returnval = null;
            Assembly asm = BuildAssembly(code);

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
    }
}