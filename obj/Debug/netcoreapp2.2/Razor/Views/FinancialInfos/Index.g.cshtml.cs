#pragma checksum "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce682ebf204acce57b1c2e263aacb8179d646c62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FinancialInfos_Index), @"mvc.1.0.view", @"/Views/FinancialInfos/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FinancialInfos/Index.cshtml", typeof(AspNetCore.Views_FinancialInfos_Index))]
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
#line 1 "C:\Users\Piotrek\Desktop\WebRentManager\Views\_ViewImports.cshtml"
using WebRentManager.Models;

#line default
#line hidden
#line 2 "C:\Users\Piotrek\Desktop\WebRentManager\Views\_ViewImports.cshtml"
using WebRentManager.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce682ebf204acce57b1c2e263aacb8179d646c62", @"/Views/FinancialInfos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fbae830d2f408f389cda34321553a4754b92461", @"/Views/_ViewImports.cshtml")]
    public class Views_FinancialInfos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tuple<FinancialInfo,Car>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cars", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FinancialInfos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 773, true);
            WriteLiteral(@"
<div class=""row"">
    <table class=""table-bordered table-striped table-hover"">
        <thead>
            <tr>
                <th class=""text-center text-dark"">Nr. rej</th>
                <th class=""text-center text-dark"">Marka i model</th>
                <th class=""text-center text-dark"">Leasingobiorca</th>
                <th class=""text-center text-dark"">Leasingodawca</th>
                <th class=""text-center text-dark"">Początek</th>
                <th class=""text-center text-dark"">Koniec</th>
                <th class=""text-center text-dark"">Rata miesięczna [netto]</th>
                <th class=""text-center text-dark"">Wykup na koniec [netto]</th>           
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 19 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(870, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(908, 112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce682ebf204acce57b1c2e263aacb8179d646c625919", async() => {
                BeginContext(987, 29, false);
#line 22 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
                                                                                             Write(item.Item2.RegistrationNumber);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-guid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 22 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
                                                                      WriteLiteral(item.Item2.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["guid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-guid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["guid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1020, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1048, 15, false);
#line 23 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item2.Make);

#line default
#line hidden
            EndContext();
            BeginContext(1063, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(1066, 16, false);
#line 23 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
                                 Write(item.Item2.Model);

#line default
#line hidden
            EndContext();
            BeginContext(1082, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1110, 18, false);
#line 24 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.Company);

#line default
#line hidden
            EndContext();
            BeginContext(1128, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1156, 19, false);
#line 25 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.BankName);

#line default
#line hidden
            EndContext();
            BeginContext(1175, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1203, 48, false);
#line 26 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.LeaseStartDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1251, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1279, 46, false);
#line 27 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.LeaseEndDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1325, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1353, 37, false);
#line 28 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.MonthlyLeaseFee.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1390, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1418, 39, false);
#line 29 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
               Write(item.Item1.EndBuyoutNetPrice.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1457, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1484, 123, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce682ebf204acce57b1c2e263aacb8179d646c6211700", async() => {
                BeginContext(1594, 9, true);
                WriteLiteral("Szczegóły");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 30 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
                                                                              WriteLiteral(item.Item1.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1607, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 32 "C:\Users\Piotrek\Desktop\WebRentManager\Views\FinancialInfos\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1648, 44, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tuple<FinancialInfo,Car>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
