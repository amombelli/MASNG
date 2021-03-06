// <copyright file="PexAssemblyInfo.cs" company="TECSER ENTERPISE">Copyright ©  2017</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("MASng")]
[assembly: PexInstrumentAssembly("System.Data")]
[assembly: PexInstrumentAssembly("Microsoft.ReportViewer.WinForms")]
[assembly: PexInstrumentAssembly("System.Drawing")]
[assembly: PexInstrumentAssembly("System.Data.DataSetExtensions")]
[assembly: PexInstrumentAssembly("Microsoft.CSharp")]
[assembly: PexInstrumentAssembly("EntityFramework")]
[assembly: PexInstrumentAssembly("Tecser.Business.VBTools")]
[assembly: PexInstrumentAssembly("TecserEF.Entity")]
[assembly: PexInstrumentAssembly("Tecser.Business")]
[assembly: PexInstrumentAssembly("System.Windows.Forms")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("WebServicesAFIP")]
[assembly: PexInstrumentAssembly("System.Web.Services")]
[assembly: PexInstrumentAssembly("Tecser.Business.WebServices")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.ReportViewer.WinForms")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Drawing")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data.DataSetExtensions")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.CSharp")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EntityFramework")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Tecser.Business.VBTools")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "TecserEF.Entity")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Tecser.Business")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Windows.Forms")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "WebServicesAFIP")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Services")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Tecser.Business.WebServices")]

