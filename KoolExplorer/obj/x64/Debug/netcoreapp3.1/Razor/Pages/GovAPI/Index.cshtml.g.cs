#pragma checksum "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ee43b0e6c1cba584177560dc378520d021e4cf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(KoolExplorer.Pages.GovAPI.Pages_GovAPI_Index), @"mvc.1.0.razor-page", @"/Pages/GovAPI/Index.cshtml")]
namespace KoolExplorer.Pages.GovAPI
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ee43b0e6c1cba584177560dc378520d021e4cf7", @"/Pages/GovAPI/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5bc8869bfab4b1804bed9ab34b0f6b2df88c8e4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_GovAPI_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h2>Index</h2>\r\n\r\n");
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().centre_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().centre_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().class_of_licence));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().type_of_service));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().levels_offered));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <th>\r\n                ");
#nullable restore
#line 28 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().fees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <th>\r\n                ");
#nullable restore
#line 30 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().type_of_citizenship));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <th>\r\n                ");
#nullable restore
#line 32 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().last_updated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <th>\r\n                ");
#nullable restore
#line 34 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.centreServicesList.FirstOrDefault().remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 40 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
         foreach (var item in Model.centreServicesList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.centre_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.centre_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.class_of_licence));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.type_of_service));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 56 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.levels_offered));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 59 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.fees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.type_of_citizenship));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.last_updated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.remarks));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 76 "F:\School\github\KoolExplorer\KoolExplorer\Pages\GovAPI\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KoolExplorer.Pages.GovAPI.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KoolExplorer.Pages.GovAPI.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KoolExplorer.Pages.GovAPI.IndexModel>)PageContext?.ViewData;
        public KoolExplorer.Pages.GovAPI.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
