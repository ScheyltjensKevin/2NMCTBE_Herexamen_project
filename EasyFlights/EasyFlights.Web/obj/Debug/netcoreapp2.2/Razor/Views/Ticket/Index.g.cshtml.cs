#pragma checksum "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c40ebe2a8d39b29eb53e142aa9b16a8ae72f10c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_Index), @"mvc.1.0.view", @"/Views/Ticket/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/Index.cshtml", typeof(AspNetCore.Views_Ticket_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c40ebe2a8d39b29eb53e142aa9b16a8ae72f10c", @"/Views/Ticket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e60c39a1f721fd41cc68c2f77e2f29350f95308", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EasyFlights.Models.TicketAdmin>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ticket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cancel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
  
    ViewData["Title"] = "Index";


    Layout = "~/Views/Shared/_LayoutBG.cshtml";



#line default
#line hidden
            BeginContext(150, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(152, 325, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c40ebe2a8d39b29eb53e142aa9b16a8ae72f10c4591", async() => {
                BeginContext(187, 30, true);
                WriteLiteral("\r\n\r\n    <link rel=\"stylesheet\"");
                EndContext();
                BeginWriteAttribute("href", " href=", 217, "", 253, 1);
#line 13 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 223, Url.Content("~/css/site.css"), 223, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(253, 210, true);
                WriteLiteral(" />\r\n\r\n    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\">\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.1/animate.min.css\">\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(477, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 19 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
 if (Model != null)
{
    foreach (var item in Model)
    {
        if (item.ID != Guid.Empty)
        {

#line default
#line hidden
            BeginContext(590, 214, true);
            WriteLiteral("            <div class=\"demo-box\">\r\n                <div class=\"flight-info\">\r\n                    <div class=\"segments\">\r\n                        <div class=\"segment departure\">\r\n                            <time>");
            EndContext();
            BeginContext(805, 44, false);
#line 29 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                             Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(849, 59, true);
            WriteLiteral("</time>\r\n                            <span class=\"airport\">");
            EndContext();
            BeginContext(909, 42, false);
#line 30 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                             Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(951, 508, true);
            WriteLiteral(@"</span>
                        </div>
                        <div class=""divider""><span class=""plane""></span></div>
                        <div class=""segment adaptive"">
                            <span class=""airport"">TO</span>
                        </div>
                        <div class=""divider adaptive"">
                            <span class=""plane""></span>
                        </div>
                        <div class=""segment destination"">
                            <time>");
            EndContext();
            BeginContext(1460, 44, false);
#line 40 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                             Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1504, 60, true);
            WriteLiteral("</time>\r\n                            <span class=\"airport\"> ");
            EndContext();
            BeginContext(1565, 46, false);
#line 41 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(1611, 142, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"segment price\">\r\n                            <span class=\"price\">");
            EndContext();
            BeginContext(1754, 40, false);
#line 44 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1794, 123, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"segment orders\">\r\n                            ");
            EndContext();
            BeginContext(1917, 441, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c40ebe2a8d39b29eb53e142aa9b16a8ae72f10c10009", async() => {
                BeginContext(1967, 40, true);
                WriteLiteral("\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2007, "\"", 2023, 1);
#line 48 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2015, item.ID, 2015, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2024, 66, true);
                WriteLiteral(" name=\"ticketID\" hidden />\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2090, "\"", 2115, 1);
#line 49 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2098, item.Destination, 2098, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2116, 69, true);
                WriteLiteral(" name=\"destination\" hidden />\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2185, "\"", 2208, 1);
#line 50 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2193, item.Departure, 2193, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2209, 142, true);
                WriteLiteral(" name=\"departure\" hidden />\r\n                                <button type=\"submit\" class=\"order\">Cancel</button>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2358, 106, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 57 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
        }

    }
}
else
{

#line default
#line hidden
            BeginContext(2496, 66, true);
            WriteLiteral("    <h3 style=\"color:white\"> Please Buy some tickets first!</h3>\r\n");
            EndContext();
#line 64 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
}

#line default
#line hidden
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
