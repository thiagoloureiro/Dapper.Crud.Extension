using EnvDTE;
using EnvDTE80;
using System;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class ProjectHelpers
    {
        private static DTE2 _dte = CreateCrudPackage.Instance.Dte;

        public static Project GetActiveProject()
        {
            try
            {
                if (_dte.ActiveSolutionProjects is Array activeSolutionProjects && activeSolutionProjects.Length > 0)
                    return activeSolutionProjects.GetValue(0) as Project;
            }
            catch (Exception ex)
            {
                Logger.Log("Error getting the active project" + ex);
            }

            return null;
        }

        public static string GetFullPath(this Project project)
        {
            return project.Properties.Item("FullPath").Value.ToString();
        }
    }
}