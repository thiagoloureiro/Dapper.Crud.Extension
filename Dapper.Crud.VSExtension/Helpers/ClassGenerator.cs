using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ClassGenerator
    {
        public static string Generate(string content, string model, bool interfaceEnabled)
        {
            var sb = new StringBuilder();
            sb.AppendLine(interfaceEnabled
                ? $"public class {model}Repository : I{model}Repository"
                : $"public class {model}Repository");

            sb.AppendLine("{");
            sb.AppendLine(content);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}