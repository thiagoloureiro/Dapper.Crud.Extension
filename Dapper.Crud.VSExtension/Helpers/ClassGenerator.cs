using System.Linq;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ClassGenerator
    {
        public static string GenerateClassBody(string model, bool interfaceEnabled)
        {
            model = FixClassName(model);
            var sb = new StringBuilder();
            sb.AppendLine(interfaceEnabled
                ? $"public class {model}Repository : I{model}Repository"
                : $"public class {model}Repository");
            sb.AppendLine("{");

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