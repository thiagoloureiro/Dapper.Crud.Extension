using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class InterfaceGenerator
    {
        public static string GenerateSelect(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public interface I{model}Repository");
            sb.AppendLine("{");
            sb.AppendLine($"    List<{model}> Select{model}();");
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}