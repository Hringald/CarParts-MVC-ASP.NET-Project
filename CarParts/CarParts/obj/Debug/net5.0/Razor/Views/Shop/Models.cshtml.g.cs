#pragma checksum "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63dc22924bc9a0f4bac1981784c3e45d17cef749"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Models), @"mvc.1.0.view", @"/Views/Shop/Models.cshtml")]
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
#line 1 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models.Parts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Models.Offers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\_ViewImports.cshtml"
using CarParts.Areas.Admin.Views.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
using CarParts.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63dc22924bc9a0f4bac1981784c3e45d17cef749", @"/Views/Shop/Models.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8f8c29fb9dd4e0d6265d4b0cf961b9e87b35b0e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Models : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<PartCategoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Categories", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
  
    ViewBag.Title = "Models";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 13 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                     Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>There are no models from ");
#nullable restore
#line 14 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                           Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" that we sale parts for:</p>\r\n</div>\r\n");
#nullable restore
#line 16 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">");
#nullable restore
#line 20 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                     Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>This is are the models of ");
#nullable restore
#line 21 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                            Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" that we sale parts for:</p>\r\n</div>\r\n");
            WriteLiteral("<div class=\"row mt-2 mb-4\">\r\n");
#nullable restore
#line 26 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
     foreach (var modelModel in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card col-6 col-lg-3 game-card\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 754, "\"", 780, 1);
#nullable restore
#line 29 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
WriteAttributeValue("", 760, modelModel.ImageUrl, 760, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                 class=\"card-img-top img-fluid card-image rounded\" data-toggle=\"tooltip\"\r\n                 data-placement=\"bottom\"");
            BeginWriteAttribute("title", " title=\"", 913, "\"", 937, 1);
#nullable restore
#line 31 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
WriteAttributeValue("", 921, modelModel.Name, 921, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body\">\r\n                <ul class=\"list-group list-group-flush\">\r\n                    <li class=\"list-group-item text-center\">");
#nullable restore
#line 34 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                                                       Write(modelModel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ul>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63dc22924bc9a0f4bac1981784c3e45d17cef7499323", async() => {
                WriteLiteral("Products Categories");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Make", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                                                                     WriteLiteral(ViewBag.Name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Make"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Make", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Make"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
                                                                                                     WriteLiteral(modelModel.Name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Model"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Model", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Model"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 39 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 41 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Shop\Models.cshtml"
}

#line default
#line hidden
#nullable disable
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
