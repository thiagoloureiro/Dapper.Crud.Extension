using System.Collections.Generic;
using System.Linq;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ModelHelper
    {
        public static object Generate(string[] content, string rawContent, string model)
        {
            var nspace = "";
            var o = new object();
            foreach (var line in content)
            {
                if (line.Contains("namespace"))
                {
                    nspace = line.Replace("namespace ", "");
                    break;
                }
            }

            o = AssemblyHelper.ExecuteCode(rawContent, nspace, model, false);

            return o;
        }

        private static List<string> Types()
        {
            var lst = new List<string>
            {
                "bool",
                "byte",
                "char",
                "decimal",
                "double",
                "enum",
                "float",
                "int",
                "long",
                "sbyte",
                "short",
                "struct",
                "uint",
                "ulong",
                "ushort",
                "string",
                "DateTime",
                "Int",
                "Int64",
                "String"
            };

            return lst;
        }
    }
}