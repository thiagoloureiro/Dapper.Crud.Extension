using System.Linq;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class InterfaceGenerator
    {
        public static string GenerateInterfaceBody(string model)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine($"public interface I{model}Repository");
            sb.AppendLine("{");

            return sb.ToString();
        }

        public static string GenerateSelect(string model)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();
            sb.AppendLine($"    List<{model}> Select{model}();");

            return sb.ToString();
        }

        public static string GenerateInsert(string model)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();
            sb.AppendLine($"    void Insert{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateUpdate(string model)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();
            sb.AppendLine($"    void Update{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateDelete(string model)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();
            sb.AppendLine($"    void Delete{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        private static string FixClassName(string model)
        {
            if (model.Contains("\\"))
            {
                var str = model.Split('\\');
                model = str.Last(); // last item of the array
            }
            return model;
        }
    }
}