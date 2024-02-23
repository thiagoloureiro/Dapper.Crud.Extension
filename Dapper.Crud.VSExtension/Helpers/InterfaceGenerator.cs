using System.Globalization;
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

        public static string GenerateSelect(string model, bool isAsync)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine($"    Task<IEnumerable<{model}>> Select{model}();");
            else
                sb.AppendLine($"    IEnumerable<{model}> Select{model}();");

            return sb.ToString();
        }

        public static string GenerateSelectById(string model, bool isAsync)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine($"    Task<{model}> Select{model}ById(int id);");
            else
                sb.AppendLine($"    {model} Select{model}ById(int id);");

            return sb.ToString();
        }

        public static string GenerateInsert(string model, bool isAsync, bool insertedId)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (insertedId)
            {
                if (isAsync)
                    sb.AppendLine($"    Task<int> Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
                else
                    sb.AppendLine($"    int Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
            }
            else
            {
                if (isAsync)
                    sb.AppendLine($"    Task Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
                else
                    sb.AppendLine($"    void Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
            }
            return sb.ToString();
        }

        public static string GenerateUpdate(string model, bool isAsync)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine($"    Task Update{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
            else
                sb.AppendLine($"    void Update{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");

            return sb.ToString();
        }

        public static string GenerateDelete(string model, bool isAsync)
        {
            model = FixClassName(model);

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine($"    Task Delete{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");
            else
                sb.AppendLine($"    void Delete{model}({model} {model.ToLower(CultureInfo.InvariantCulture)});");

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