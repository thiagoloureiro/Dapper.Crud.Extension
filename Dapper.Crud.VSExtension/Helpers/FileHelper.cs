using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class FileHelper
    {
        public static void GenerateClass(string content, string model, string projectPath)
        {
            File.WriteAllText(projectPath + model + "Repository.cs", content);
        }

        public static void GenerateInterface(string content, string model, string projectPath)
        {
            File.WriteAllText(projectPath + "I" + model + "Repository.cs", content);
        }

        public static IEnumerable<string> FilterFileList(List<string> files)
        {
            var filteredlist = new List<string>();

            foreach (var file in files)
            {
                if (!CheckInterface(file))
                    filteredlist.Add(file);
            }

            filteredlist.RemoveAll(x => x.Contains("TemporaryGeneratedFile"));
            filteredlist.RemoveAll(x => x.Contains("AssemblyInfo.cs"));
            filteredlist.RemoveAll(x => x.Contains("Program.cs"));
            filteredlist.RemoveAll(x => x.Contains("Startup.cs"));
            return filteredlist;
        }

        private static bool CheckInterface(string file)
        {
            var content = File.ReadAllText(file);

            return content.Contains("public interface") || content.Contains("private interface");
        }

        public static string GenerateRawStringAllFiles(IEnumerable<string> fileList)
        {
            var lstUsings = new List<string>();
            var lstContent = new List<string>();

            foreach (var file in fileList)
            {
                var strContent = File.ReadAllLines(file);
                foreach (var line in strContent)
                {
                    if (line.Contains("using"))
                        lstUsings.Add(line);
                    else
                        lstContent.Add(line);
                }
            }

            var sbResult = new StringBuilder();

            List<string> lstUsingsFiltered = lstUsings.Distinct().ToList();

            foreach (var item in lstUsingsFiltered)
            {
                sbResult.AppendLine(item);
            }

            foreach (var item in lstContent)
            {
                sbResult.AppendLine(item);
            }

            return sbResult.ToString();
        }
    }
}