using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace Dapper.Crud.VSExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(CreateCrudPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class CreateCrudPackage : AsyncPackage
    {
        public DTE2 Dte;

        public static CreateCrudPackage Instance;

        /// <summary>
        /// CreateCrudPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "cb7802c6-dd51-4368-ad9a-413841cf0287";

        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            CreateCrud.Initialize(this);
            await base.InitializeAsync(cancellationToken, progress);
            Dte = await GetServiceAsync(typeof(DTE)) as DTE2;
            Instance = this;
            Logger.Initialize(this, "Dapper CRUD Generator");
        }

        #endregion Package Members
    }
}