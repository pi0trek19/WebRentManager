#pragma checksum "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cefb184c0285a48053c6fe14392815f4bf90ba9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Services_Details), @"mvc.1.0.view", @"/Views/Services/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Services/Details.cshtml", typeof(AspNetCore.Views_Services_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cefb184c0285a48053c6fe14392815f4bf90ba9d", @"/Views/Services/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7cf82df0dd814c7b28170c21c27ef191b9258cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Services_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 298, true);
            WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <table class=""col-lg-4 col-md-12 table-hover table-striped table-bordered"">
                <tbody>
                    <tr>
                        <th class=""text-center text-dark"">Nr rej.</th>
                        <td>");
            EndContext();
            BeginContext(332, 29, false);
#line 9 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Car.RegistrationNumber);

#line default
#line hidden
            EndContext();
            BeginContext(361, 158, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Marka</th>\r\n                        <td>");
            EndContext();
            BeginContext(520, 15, false);
#line 13 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Car.Make);

#line default
#line hidden
            EndContext();
            BeginContext(535, 158, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Model</th>\r\n                        <td>");
            EndContext();
            BeginContext(694, 16, false);
#line 17 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Car.Model);

#line default
#line hidden
            EndContext();
            BeginContext(710, 330, true);
            WriteLiteral(@"</td>
                    </tr>
                </tbody>
            </table>

            <table class=""col-lg-4 col-md-12 table-hover table-striped table-bordered"">
                <tbody>
                    <tr>
                        <th class=""text-center text-dark"">Nazwa serwisu</th>
                        <td>");
            EndContext();
            BeginContext(1041, 27, false);
#line 26 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._ServiceFacility.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1068, 158, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Adres</th>\r\n                        <td>");
            EndContext();
            BeginContext(1227, 29, false);
#line 30 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._ServiceFacility.Street);

#line default
#line hidden
            EndContext();
            BeginContext(1256, 165, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Kod pocztowy</th>\r\n                        <td>");
            EndContext();
            BeginContext(1422, 26, false);
#line 34 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._ServiceFacility.Zip);

#line default
#line hidden
            EndContext();
            BeginContext(1448, 159, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Miasto</th>\r\n                        <td>");
            EndContext();
            BeginContext(1608, 27, false);
#line 38 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._ServiceFacility.City);

#line default
#line hidden
            EndContext();
            BeginContext(1635, 326, true);
            WriteLiteral(@"</td>
                    </tr>
                </tbody>
            </table>
            <table class=""col-lg-4 col-md-12 table-hover table-striped table-bordered"">
                <tbody>
                    <tr>
                        <th class=""text-center text-dark"">Typ serwisu</th>
                        <td>");
            EndContext();
            BeginContext(1962, 19, false);
#line 46 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Service.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(1981, 157, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Data</th>\r\n                        <td>");
            EndContext();
            BeginContext(2139, 42, false);
#line 50 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Service.Date.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(2181, 161, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Przebieg</th>\r\n                        <td>");
            EndContext();
            BeginContext(2343, 21, false);
#line 54 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Service.Milage);

#line default
#line hidden
            EndContext();
            BeginContext(2364, 164, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <th class=\"text-center text-dark\">Typ serwisu</th>\r\n                        <td>");
            EndContext();
            BeginContext(2529, 37, false);
#line 58 "C:\Users\Piotrek\Desktop\WebRentManager\Views\Services\Details.cshtml"
                       Write(Model._Service.ServiceType.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2566, 110, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
