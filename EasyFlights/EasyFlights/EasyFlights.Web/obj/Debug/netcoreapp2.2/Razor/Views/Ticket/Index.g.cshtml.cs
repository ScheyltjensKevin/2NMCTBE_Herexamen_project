#pragma checksum "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b964db2c6397d9b1b70de0f0dd2039317c640570"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b964db2c6397d9b1b70de0f0dd2039317c640570", @"/Views/Ticket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e60c39a1f721fd41cc68c2f77e2f29350f95308", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EasyFlights.Models.TicketAdmin>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/searchbar.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Ticket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cancel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
  
    ViewData["Title"] = "Index";

    if (Model.First().Administrator == 0)
    {
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    else
    {
        Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
    }

#line default
#line hidden
            BeginContext(283, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(285, 421, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b964db2c6397d9b1b70de0f0dd2039317c6405706295", async() => {
                BeginContext(320, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(326, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b964db2c6397d9b1b70de0f0dd2039317c6405706687", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(372, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(380, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b964db2c6397d9b1b70de0f0dd2039317c6405708024", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(427, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(433, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b964db2c6397d9b1b70de0f0dd2039317c6405709356", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(485, 207, true);
                WriteLiteral("\r\n\r\n    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\">\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.1/animate.min.css\">\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(706, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 25 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
 if (Model != null)
{
    foreach (var item in Model)
    {
        if (item.ID != Guid.Empty)
        {

#line default
#line hidden
            BeginContext(819, 214, true);
            WriteLiteral("            <div class=\"demo-box\">\r\n                <div class=\"flight-info\">\r\n                    <div class=\"segments\">\r\n                        <div class=\"segment departure\">\r\n                            <time>");
            EndContext();
            BeginContext(1034, 44, false);
#line 35 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                             Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 59, true);
            WriteLiteral("</time>\r\n                            <span class=\"airport\">");
            EndContext();
            BeginContext(1138, 42, false);
#line 36 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                             Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1180, 508, true);
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
            BeginContext(1689, 44, false);
#line 46 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                             Write(Html.DisplayFor(modelItem => item.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1733, 60, true);
            WriteLiteral("</time>\r\n                            <span class=\"airport\"> ");
            EndContext();
            BeginContext(1794, 46, false);
#line 47 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Destination));

#line default
#line hidden
            EndContext();
            BeginContext(1840, 142, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"segment price\">\r\n                            <span class=\"price\">");
            EndContext();
            BeginContext(1983, 40, false);
#line 50 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2023, 123, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"segment orders\">\r\n                            ");
            EndContext();
            BeginContext(2146, 441, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b964db2c6397d9b1b70de0f0dd2039317c64057015269", async() => {
                BeginContext(2196, 40, true);
                WriteLiteral("\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2236, "\"", 2252, 1);
#line 54 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2244, item.ID, 2244, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2253, 66, true);
                WriteLiteral(" name=\"ticketID\" hidden />\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2319, "\"", 2344, 1);
#line 55 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2327, item.Destination, 2327, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2345, 69, true);
                WriteLiteral(" name=\"destination\" hidden />\r\n                                <input");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2414, "\"", 2437, 1);
#line 56 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
WriteAttributeValue("", 2422, item.Departure, 2422, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2438, 142, true);
                WriteLiteral(" name=\"departure\" hidden />\r\n                                <button type=\"submit\" class=\"order\">Cancel</button>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2587, 106, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 63 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
        }

    }
}
else
{

#line default
#line hidden
            BeginContext(2725, 66, true);
            WriteLiteral("    <h3 style=\"color:white\"> Please Buy some tickets first!</h3>\r\n");
            EndContext();
#line 70 "F:\src\back\EasyFlights\EasyFlights.Web\Views\Ticket\Index.cshtml"
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
