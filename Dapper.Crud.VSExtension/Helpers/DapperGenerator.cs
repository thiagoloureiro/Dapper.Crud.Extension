using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class DapperGenerator
    {
        public static string Select(string model)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"List<{model}> ret;");
            sb.AppendLine("using (var db = new SqlConnection(connstring))");
            sb.AppendLine("{");
            sb.AppendLine($"    const string sql = @\"SELECT * FROM [{model}]\";");
            sb.AppendLine("");
            sb.AppendLine($"    ret = db.Query<{model}>(sql, commandType: CommandType.Text).ToList();");
            sb.AppendLine("}");
            sb.AppendLine("return ret;");

            return sb.ToString();
        }
    }
}