#pragma checksum "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fd51c609d3888e26260308c4c09b5da60e11898"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parts_ChooseMake), @"mvc.1.0.view", @"/Views/Parts/ChooseMake.cshtml")]
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
#line 1 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models.Parts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models.Offers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Areas.Admin.Views.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
using CarParts.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fd51c609d3888e26260308c4c09b5da60e11898", @"/Views/Parts/ChooseMake.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c4c68aba6c2824bfb748434cc8416164664bf48", @"/Views/_ViewImports.cshtml")]
    public class Views_Parts_ChooseMake : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<PartCategoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/carMenu.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Parts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddPart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
  
    ViewBag.Title = "Choose Make";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3fd51c609d3888e26260308c4c09b5da60e118986616", async() => {
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
            WriteLiteral("\n    <h1 style=\"text-align:center\">Choose from the available makes:</h1>\n\n    <div class=\"row mt-2 mb-4\">\n");
#nullable restore
#line 14 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
         foreach (var make in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-6 col-xl-1 mb-5 mt-5 ml-4 mr-4\" >\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fd51c609d3888e26260308c4c09b5da60e118988231", async() => {
                WriteLiteral("\n                    <img style=\"width:90px;max-width:90px;height:90px;max-height:90px\"");
                BeginWriteAttribute("src", " src=\"", 698, "\"", 718, 1);
#nullable restore
#line 18 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
WriteAttributeValue("", 704, make.ImageUrl, 704, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\n                         class=\"card-img-top img-fluid card-image rounded\" data-toggle=\"tooltip\"\n                         data-placement=\"bottom\"");
                BeginWriteAttribute("title", " title=\"", 865, "\"", 883, 1);
#nullable restore
#line 20 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
WriteAttributeValue("", 873, make.Name, 873, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Make", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
                                                                   WriteLiteral(make.Name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Make"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Make", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Make"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n");
#nullable restore
#line 23 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Parts\ChooseMake.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<PartCategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
