using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class DapperGenerator
    {
        public static string Select(string model, IList<PropertyInfo> properties)
        {
            var sb = new StringBuilder();
            var prop = GenerateProperties(properties);

            sb.AppendLine($"List<{model}> ret;");
            sb.AppendLine("using (var db = new SqlConnection(connstring))");
            sb.AppendLine("{");
            sb.AppendLine($"    const string sql = @\"SELECT {prop} FROM [{model}]\";");
            sb.AppendLine("");
            sb.AppendLine($"    ret = db.Query<{model}>(sql, commandType: CommandType.Text).ToList();");
            sb.AppendLine("}");
            sb.AppendLine("return ret;");

            return sb.ToString();
        }

        private static string GenerateProperties(IList<PropertyInfo> properties)
        {
            var last = properties.Last();
            string str = string.Empty;
            foreach (var prop in properties)
            {
                if (prop.Equals(last))
                    str += prop.Name.ToString();
                else

                    str += prop.Name.ToString() + ", ";
            }
            return str;
        }
    }
}