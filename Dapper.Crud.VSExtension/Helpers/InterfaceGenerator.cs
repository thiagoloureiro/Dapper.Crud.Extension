using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class InterfaceGenerator
    {
        public static string GenerateInterfaceBody(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine($"public interface I{model}Repository");
            sb.AppendLine("{");

            return sb.ToString();
        }

        public static string GenerateSelect(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"    List<{model}> Select{model}();");

            return sb.ToString();
        }

        public static string GenerateInsert(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"    void Insert{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateUpdate(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"    void Update{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateDelete(string model)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"    void Delete{model}({model} {model.ToLower()});");

            return sb.ToString();
        }
    }
}