#pragma checksum "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "700ee0afe92bb9d5ce801ef3202677482832290f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Index), @"mvc.1.0.view", @"/Views/Report/Index.cshtml")]
namespace AspNetCore
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
#line 1 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\_ViewImports.cshtml"
using DIMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\_ViewImports.cshtml"
using DIMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\_ViewImports.cshtml"
using DIMS.Entities.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\_ViewImports.cshtml"
using DIMS.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\_ViewImports.cshtml"
using DIMS.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"700ee0afe92bb9d5ce801ef3202677482832290f", @"/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a23e6afa17bc44ca17dd3a0a7e576ed729b9d44f", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EnterpriseInfoListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
  
    Layout = "_layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <button type=""button"" class=""btn btn-lg btn-outline-primary float-right font-weight-bolder"" data-toggle=""modal"" data-target=""#modal-md"">
                                <i class=""fa fa-plus-square mr-2""></i> Add New
                            </button>
                            <h2 class=""float-left note-fontsize-10 font-weight-bolder"">Enterprise Info List</h2>
                        </div>

                        <div class=""card-body"">
                            <table id=""example1"" class=""table table-bordered table-hover"">
                                <thead>
                                    <tr class=""bg-gradient-lightblue text-center"">
                                        <th rowspan=""2"" class=""align-middle"">Maqaa Intar");
            WriteLiteral(@"piraayizoota</th>
                                        <th colspan=""5"">Teessoo</th>
                                        <th rowspan=""2"" class=""align-middle"">Bara Hundeeffaamaa</th>
                                        <th rowspan=""2"" class=""align-middle"">Damee hojii</th>
                                        <th rowspan=""2"" class=""align-middle"">Gosa hojii</th>
                                        <th rowspan=""2"" class=""align-middle"">Sadarkaa interpiraayizichaa</th>
                                        <th rowspan=""2"" class=""align-middle"">Gosa Gurmii</th>
                                        <th rowspan=""2"" class=""align-middle"">Lakk. TIN</th>
                                        <th rowspan=""2"" class=""align-middle"">Sadarkaa guddinaa</th>
                                        <th rowspan=""2"" class=""align-middle"">Ka-umsa Kaappitaalaa</th>
                                        <th rowspan=""2"" class=""align-middle"">Madda ka'umsa Kappitaalaa </th>
                              ");
            WriteLiteral(@"          <th rowspan=""2"" class=""align-middle"">Action</th>
                                    </tr>
                                    <tr class=""text-center"">
                                        <th>Godina</th>
                                        <th>Magaalaa</th>
                                        <th>Gandaa</th>
                                        <th>Lakk. Manaa</th>
                                        <th>Lakk. Bilbilaa</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 44 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                     foreach (var item in ViewBag.GetAllReportList)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"info\">\r\n                                            <td>");
#nullable restore
#line 47 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.EnterpriseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 48 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.ZoneName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 49 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 50 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.KebeleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 51 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.HouseNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 52 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 53 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.EstableshedYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 54 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.BranchName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 55 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.BranchItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 56 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.EnterpriseLevelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 57 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.GroupTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 58 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.TINNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 59 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.PromotionLevelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 60 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.InitialCapital);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 61 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                           Write(item.SourceCapitalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                Kassahun\r\n");
            WriteLiteral("                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 68 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Report\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                                <tfoot>
                                    <tr class=""bg-gradient-navy"">
                                        <th colspan=""16""></th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EnterpriseInfoListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
