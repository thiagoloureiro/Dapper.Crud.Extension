using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ProjectHelpers
    {
        private static DTE2 _dte = CreateCrudPackage.Instance.Dte;

        public static IEnumerable<ProjectItem> GetSelectedItems()
        {
            var items = (Array)_dte.ToolWindows.SolutionExplorer.SelectedItems;

            foreach (UIHierarchyItem selItem in items)
            {
                if (selItem.Object is ProjectItem item)
                    yield return item;
            }
        }

        public static Project GetActiveProject()
        {
            try
            {
                if (_dte.ActiveSolutionProjects is Array activeSolutionProjects && activeSolutionProjects.Length > 0)
                    return activeSolutionProjects.GetValue(0) as Project;
            }
            catch (Exception ex)
            {
                Logger.Logger.Log("Error getting the active project" + ex);
            }

            return null;
        }

        public static string GetFullPath(this ProjectItem item)
        {
            return item.Properties.Item("FullPath").Value.ToString();
        }

        public static string GetFullPath(this Project project)
        {
            return project.Properties.Item("FullPath").Value.ToString();
        }

        public static string GetRootFolder(this Project project)
        {
            if (string.IsNullOrEmpty(project?.FullName))
                return null;

            string fullPath;

            try
            {
                fullPath = project.Properties.Item("FullPath").Value as string;
            }
            catch (ArgumentException)
            {
                try
                {
                    // MFC projects don't have FullPath, and there seems to be no way to query existence
                    fullPath = project.Properties.Item("ProjectDirectory").Value as string;
                }
                catch (ArgumentException)
                {
                    // Installer projects have a ProjectPath.
                    fullPath = project.Properties.Item("ProjectPath").Value as string;
                }
            }

            if (string.IsNullOrEmpty(fullPath))
                return File.Exists(project.FullName) ? Path.GetDirectoryName(project.FullName) : null;

            if (Directory.Exists(fullPath))
                return fullPath;

            if (File.Exists(fullPath))
                return Path.GetDirectoryName(fullPath);

            return null;
        }

        public static IEnumerable<Project> GetAllProjects()
        {
            return _dte.Solution.Projects
                .Cast<Project>()
                .SelectMany(GetChildProjects)
                .Union(_dte.Solution.Projects.Cast<Project>())
                .Where(p => { try { return !string.IsNullOrEmpty(p.FullName); } catch { return false; } });
        }

        private static IEnumerable<Project> GetChildProjects(Project parent)
        {
            try
            {
                if (!string.IsNullOrEmpty(parent.FullName))
                    return new[] { parent };
            }
            catch (COMException)
            {
                return Enumerable.Empty<Project>();
            }

            return parent.ProjectItems
                .Cast<ProjectItem>()
                .Where(p => p.SubProject != null)
                .SelectMany(p => GetChildProjects(p.SubProject));
        }
    }
}