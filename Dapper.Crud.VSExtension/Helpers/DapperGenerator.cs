using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class DapperGenerator
    {
        public static string Select(string modelName)
        {
            var sb = new StringBuilder();

            sb.AppendLine("using (var db = new SqlConnection(connstring))");
            sb.AppendLine("{");
            sb.AppendLine($"    const string sql = @\"SELECT * FROM [{modelName}]\";");
            sb.AppendLine("");
            sb.AppendLine($"    ret = db.Query<{modelName}>(sql, commandType: CommandType.Text).ToList();");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}