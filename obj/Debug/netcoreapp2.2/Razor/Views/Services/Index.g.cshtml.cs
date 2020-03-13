#pragma checksum "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "596c08a5ffe18a1a6f2dd21c216ee45c23014fd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services_Index), @"mvc.1.0.view", @"/Views/Services/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Services/Index.cshtml", typeof(AspNetCore.Views_Services_Index))]
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
#line 3 "C:\Users\Piotrek\Desktop\WebRentManager\Views\_ViewImports.cshtml"
using WebRentManager.ViewComponents;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"596c08a5ffe18a1a6f2dd21c216ee45c23014fd1", @"/Views/Services/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7cf82df0dd814c7b28170c21c27ef191b9258cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Services_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Service>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "service", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cars", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(22, 567, true);
            WriteLiteral(@"

    <h2>Lista przeglądów</h2>
    <div class=""row"">
        <table class=""table-bordered table-striped table-hover"">
            <thead>
                <tr>
                    <th class=""text-center text-dark"">Serwis</th>
                    <th class=""text-center text-dark"">Samochód</th>
                    <th class=""text-center text-dark"">Przebieg</th>
                    <th class=""text-center text-dark"">Data</th>
                    <th class=""text-center text-dark"">Typ</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 17 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(654, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(708, 138, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596c08a5ffe18a1a6f2dd21c216ee45c23014fd15148", async() => {
                BeginContext(788, 16, false);
#line 20 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                      Write(item.Client.Name);

#line default
#line hidden
                EndContext();
                BeginContext(804, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(806, 18, false);
#line 20 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                                        Write(item.Client.Street);

#line default
#line hidden
                EndContext();
                BeginContext(824, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(826, 16, false);
#line 20 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                                                            Write(item.Client.City);

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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 20 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                               WriteLiteral(item.ClientId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(846, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(881, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "596c08a5ffe18a1a6f2dd21c216ee45c23014fd18864", async() => {
                BeginContext(955, 13, false);
#line 21 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                Write(item.Car.Make);

#line default
#line hidden
                EndContext();
                BeginContext(968, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(970, 14, false);
#line 21 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                               Write(item.Car.Model);

#line default
#line hidden
                EndContext();
                BeginContext(984, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(986, 27, false);
#line 21 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                                                                               Write(item.Car.RegistrationNumber);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 21 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                                                                            WriteLiteral(item.CarId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1017, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1053, 11, false);
#line 22 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                       Write(item.Milage);

#line default
#line hidden
            EndContext();
            BeginContext(1064, 38, true);
            WriteLiteral(" km</td>\r\n                        <td>");
            EndContext();
            BeginContext(1103, 32, false);
#line 23 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                       Write(item.Date.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1135, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1171, 27, false);
#line 24 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                       Write(item.ServiceType.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1198, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 26 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1251, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Service>> Html { get; private set; }
    }
}
#pragma warning restore 1591
