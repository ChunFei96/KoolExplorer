#pragma checksum "F:\School\github\KoolExplorer\KoolExplorer\Pages\AppForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edda7203180125d35b158bad8c00e9d636913e6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(KoolExplorer.Pages.Pages_AppForm), @"mvc.1.0.razor-page", @"/Pages/AppForm.cshtml")]
namespace KoolExplorer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\School\github\KoolExplorer\KoolExplorer\Pages\_ViewImports.cshtml"
using KoolExplorer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edda7203180125d35b158bad8c00e9d636913e6b", @"/Pages/AppForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5bc8869bfab4b1804bed9ab34b0f6b2df88c8e4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AppForm : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\School\github\KoolExplorer\KoolExplorer\Pages\AppForm.cshtml"
  
    ViewData["Title"] = "Application Form";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 6 "F:\School\github\KoolExplorer\KoolExplorer\Pages\AppForm.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>You can slot the form below this line</p>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KoolExplorer.Pages.AppFormModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KoolExplorer.Pages.AppFormModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KoolExplorer.Pages.AppFormModel>)PageContext?.ViewData;
        public KoolExplorer.Pages.AppFormModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
