#pragma checksum "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a2ec3d61e2c2275a8cf9e9d9961afd1b8d77103"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_UserTickets), @"mvc.1.0.view", @"/Views/Ticket/UserTickets.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/UserTickets.cshtml", typeof(AspNetCore.Views_Ticket_UserTickets))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a2ec3d61e2c2275a8cf9e9d9961afd1b8d77103", @"/Views/Ticket/UserTickets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e60c39a1f721fd41cc68c2f77e2f29350f95308", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_UserTickets : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EasyFlights.Models.TicketAdmin>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
  
    ViewData["Title"] = "UserTickets";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
            BeginContext(153, 84, true);
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(238, 41, false);
#line 11 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(279, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(335, 45, false);
#line 14 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Available));

#line default
#line hidden
            EndContext();
            BeginContext(380, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(436, 43, false);
#line 17 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
            EndContext();
            BeginContext(479, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(535, 47, false);
#line 20 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(582, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(638, 45, false);
#line 23 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(683, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(739, 40, false);
#line 26 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Seat));

#line default
#line hidden
            EndContext();
            BeginContext(779, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(835, 41, false);
#line 29 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(876, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 35 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(994, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1043, 40, false);
#line 38 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1083, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1139, 44, false);
#line 41 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Available));

#line default
#line hidden
            EndContext();
            BeginContext(1183, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1239, 42, false);
#line 44 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1281, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1337, 46, false);
#line 47 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(1383, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1439, 44, false);
#line 50 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1483, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1539, 39, false);
#line 53 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Seat));

#line default
#line hidden
            EndContext();
            BeginContext(1578, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1634, 40, false);
#line 56 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1674, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1730, 129, false);
#line 59 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.ID, dest = item.Destination, dep = item.Departure, user = item.Email  },null));

#line default
#line hidden
            EndContext();
            BeginContext(1859, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 62 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\UserTickets.cshtml"
}

#line default
#line hidden
            BeginContext(1898, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EasyFlights.Models.TicketAdmin>> Html { get; private set; }
    }
}
#pragma warning restore 1591