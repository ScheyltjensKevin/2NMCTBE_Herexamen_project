#pragma checksum "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23a504b0517453b5927454bf0add3aae9eb127fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bonus_UsersBonusPoints), @"mvc.1.0.view", @"/Views/Bonus/UsersBonusPoints.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bonus/UsersBonusPoints.cshtml", typeof(AspNetCore.Views_Bonus_UsersBonusPoints))]
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
#line 1 "F:\src\back\EasyFlights\EasyFlights.Web\Views\_ViewImports.cshtml"
using EasyFlights.Web;

#line default
#line hidden
#line 2 "F:\src\back\EasyFlights\EasyFlights.Web\Views\_ViewImports.cshtml"
using EasyFlights.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23a504b0517453b5927454bf0add3aae9eb127fb", @"/Views/Bonus/UsersBonusPoints.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e60c39a1f721fd41cc68c2f77e2f29350f95308", @"/Views/_ViewImports.cshtml")]
    public class Views_Bonus_UsersBonusPoints : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EasyFlights.Models.UsersBonusPointsDict>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
  
    ViewData["Title"] = "UsersBonusPoints";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(162, 115, true);
            WriteLiteral("\r\n<h1>UsersBonusPoints</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(278, 46, false);
#line 14 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Email));

#line default
#line hidden
            EndContext();
            BeginContext(324, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(380, 54, false);
#line 17 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
           Write(Html.DisplayNameFor(model => model.BonusPoints.Points));

#line default
#line hidden
            EndContext();
            BeginContext(434, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(490, 59, false);
#line 20 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
           Write(Html.DisplayNameFor(model => model.BonusPoints.DateAquired));

#line default
#line hidden
            EndContext();
            BeginContext(549, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(661, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(722, 45, false);
#line 29 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
               Write(Html.DisplayFor(modelItem => item.User.Email));

#line default
#line hidden
            EndContext();
            BeginContext(767, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(835, 53, false);
#line 32 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
               Write(Html.DisplayFor(modelItem => item.BonusPoints.Points));

#line default
#line hidden
            EndContext();
            BeginContext(888, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(956, 58, false);
#line 35 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
               Write(Html.DisplayFor(modelItem => item.BonusPoints.DateAquired));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 38 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Bonus\UsersBonusPoints.cshtml"
        }

#line default
#line hidden
            BeginContext(1069, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EasyFlights.Models.UsersBonusPointsDict>> Html { get; private set; }
    }
}
#pragma warning restore 1591