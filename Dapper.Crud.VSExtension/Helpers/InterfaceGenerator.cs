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

        public static string GenerateSelect(string model, bool async)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (async)
                sb.AppendLine($"    Task<IEnumerable<{model}>> Select{model}();");
            else
                sb.AppendLine($"    IEnumerable<{model}> Select{model}();");

            return sb.ToString();
        }

        public static string GenerateInsert(string model, bool async)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (async)
                sb.AppendLine($"    Task Insert{model}({model} {model.ToLower()});");
            else
                sb.AppendLine($"    void Insert{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateUpdate(string model, bool async)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (async)
                sb.AppendLine($"    Task Update{model}({model} {model.ToLower()});");
            else
                sb.AppendLine($"    void Update{model}({model} {model.ToLower()});");

            return sb.ToString();
        }

        public static string GenerateDelete(string model, bool async)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (async)
                sb.AppendLine($"    Task Delete{model}({model} {model.ToLower()});");
            else
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