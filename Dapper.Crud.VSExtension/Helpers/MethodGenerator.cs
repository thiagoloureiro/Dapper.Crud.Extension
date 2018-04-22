using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class MethodGenerator
    {
        public static string GenerateSelect(string content, string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public List<{model}> Select{model}()");
            sb.AppendLine("{");
            sb.Append(content);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}