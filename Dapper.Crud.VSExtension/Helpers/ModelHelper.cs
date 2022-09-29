using System.Collections.Generic;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ModelHelper
    {
        public static object Generate(string[] content, string rawContent, string model)
        {
            var nspace = "";
            foreach (var line in content)
            {
                if (line.Contains("namespace"))
                {
                    nspace = line.Replace("namespace ", "");
                    break;
                }
            }

            return AssemblyHelper.ExecuteCode(rawContent, nspace, model, false);
        }

        public static List<string> Types()
        {
            var lst = new List<string>
            {
                "boolean",
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
                "datetime",
                "int16",
                "int32",
                "int64",
                "string",
                "nullable`1",
                "guid"
            };

            return lst;
        }
    }
}