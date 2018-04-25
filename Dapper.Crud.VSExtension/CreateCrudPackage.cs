using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Dapper.Crud.VSExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(CreateCrudPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class CreateCrudPackage : Package
    {
        public DTE2 Dte;

        public static CreateCrudPackage Instance;

        /// <summary>
        /// CreateCrudPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "cb7802c6-dd51-4368-ad9a-413841cf0287";

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCrud"/> class.
        /// </summary>
        public CreateCrudPackage()
        {
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            CreateCrud.Initialize(this);
            base.Initialize();
            Dte = GetService(typeof(DTE)) as DTE2;
            Instance = this;
            Logger.Initialize(this, "Dapper CRUD Generator");
        }

        #endregion Package Members
    }
}