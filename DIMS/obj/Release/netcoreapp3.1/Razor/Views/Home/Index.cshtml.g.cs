#pragma checksum "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6504badcdd862c3067d38ea9a51ca3a228845157"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6504badcdd862c3067d38ea9a51ca3a228845157", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a23e6afa17bc44ca17dd3a0a7e576ed729b9d44f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
 if (signInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Welcome To ");
#nullable restore
#line 10 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
                                    Write(ViewBag.UserLocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n");
#nullable restore
#line 12 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
    if (User.FindFirst("UserRole").Value == "Public")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center\">\r\n            <h1 class=\"display-4\"> Please wait untile you approved by System Administrator.</h1>\r\n        </div>\r\n");
#nullable restore
#line 17 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <section class=""content"">
            <div class=""container-fluid"">
                <!-- Info boxes -->
                <div class=""row"">
                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info-box"">
                            <span class=""info-box-icon bg-info elevation-1""><i class=""fa fa-calendar-check""></i></span>

                            <div class=""info-box-content"">
                                <span class=""info-box-text"">New Appointment</span>
                                <span class=""info-box-number"">
                                    4
                                    <small></small>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>


                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info");
            WriteLiteral(@"-box"">
                            <span class=""info-box-icon bg-info elevation-1""><i class=""fa fa-calendar-check""></i></span>

                            <div class=""info-box-content"">
                                <span class=""info-box-text"">Total Appointment</span>
                                <span class=""info-box-number"">
                                    10
                                    <small></small>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info-box"">
                            <span class=""info-box-icon bg-info elevation-1""><i class=""fa fa-user-injured""></i></span>
                            <div class=""info-box-content"">
                                <span class=""info-box-text"">New ");
            WriteLiteral(@"Patient</span>
                                <span class=""info-box-number"">
                                    20
                                    <small></small>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>

                    <div class=""clearfix hidden-md-up""></div>

                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info-box mb-3"">
                            <span class=""info-box-icon bg-success elevation-1""><i class=""fas fa-user-injured""></i></span>

                            <div class=""info-box-content"">
                                <span class=""info-box-text"">Total Patients</span>
                                <span class=""info-box-number"">26</span>
                            </div>
                            <!-- /.info-box-content -->");
            WriteLiteral(@"
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->
                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info-box mb-3"">
                            <span class=""info-box-icon bg-danger elevation-1""><i class=""fas fa-user-nurse""></i></span>

                            <div class=""info-box-content"">
                                <span class=""info-box-text"">Doctors</span>
                                <span class=""info-box-number"">41</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->
                    <!-- fix for small devices only -->
                    <!-- /.col -->
                    <div class=""col-12 col-sm-6 col-md-3"">
                        <div class=""info-box mb-3""");
            WriteLiteral(@">
                            <span class=""info-box-icon bg-warning elevation-1""><i class=""fas fa-users""></i></span>

                            <div class=""info-box-content"">
                                <span class=""info-box-text"">Users</span>
                                <span class=""info-box-number"">3</span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <!-- /.col -->


                </div>
            </div>
        </section>
");
#nullable restore
#line 119 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4\">Not Logged In</h1>\r\n    </div>\r\n");
#nullable restore
#line 126 "D:\MyProjets\IMXProject\DIMS\DIMS\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUsers> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
