using System.Globalization;
using System.Linq;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class MethodGenerator
    {
        public static string GenerateSelect(string content, string model, bool generateClass, bool isAsync)
        {
            var space = "";
            model = FixClassName(model);

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine(space + $"public async Task<IEnumerable<{model}>> Select{model}()");
            else
                sb.AppendLine(space + $"public IEnumerable<{model}> Select{model}()");

            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateSelectById(string content, string model, bool generateClass, bool isAsync)
        {
            var space = "";
            model = FixClassName(model);

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();

            if (isAsync)
                sb.AppendLine(space + $"public async Task<{model}> Select{model}ById(int id)");
            else
                sb.AppendLine(space + $"public {model} Select{model}ById(int id)");

            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateInsert(string content, string model, bool generateClass, bool isAsync, bool insertedId)
        {
            var space = "";
            model = FixClassName(model);

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();

            if (insertedId)
            {
                if (isAsync)
                    sb.AppendLine(space + $"public async Task<int> Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
                else
                    sb.AppendLine(space + $"public int Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
            }
            else
            {
                if (isAsync)
                    sb.AppendLine(space + $"public async Task Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
                else
                    sb.AppendLine(space + $"public void Insert{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
            }
            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateUpdate(string content, string model, bool generateClass, bool isAsync)
        {
            var space = "";
            model = FixClassName(model);

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            if (isAsync)
                sb.AppendLine(space + $"public async Task Update{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
            else
                sb.AppendLine(space + $"public void Update{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");

            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

            return sb.ToString();
        }

        public static string GenerateDelete(string content, string model, bool generateClass, bool isAsync)
        {
            var space = "";
            model = FixClassName(model);

            if (generateClass)
                space = "    ";

            var sb = new StringBuilder();
            if (isAsync)
                sb.AppendLine(space + $"public async Task Delete{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");
            else
                sb.AppendLine(space + $"public void Delete{model}({model} {model.ToLower(CultureInfo.InvariantCulture)})");

            sb.AppendLine(space + "{");
            sb.Append(content);
            sb.AppendLine(space + "}");

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