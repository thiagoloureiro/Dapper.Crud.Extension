using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class MethodGenerator
    {
        public static string GenerateSelect(string content, string model, bool generateClass)
        {
            var space = "";

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            sb.AppendLine(space + $"public List<{model}> Select{model}()");
            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateInsert(string content, string model, bool generateClass)
        {
            var space = "";

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            sb.AppendLine(space + $"public void Insert{model}({model} {model.ToLower()})");
            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateUpdate(string content, string model, bool generateClass)
        {
            var space = "";

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            sb.AppendLine(space + $"public void Update{model}({model} {model.ToLower()})");
            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateDelete(string content, string model, bool generateClass)
        {
            var space = "";

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            sb.AppendLine(space + $"public void Delete{model}({model} {model.ToLower()})");
            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }
    }
}