#pragma checksum "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b05bdfce503bdd301f8cdac0857574c6a9e38e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admins_EditParts), @"mvc.1.0.view", @"/Views/Admins/EditParts.cshtml")]
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
#line 1 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
using CarParts.Areas.Admin.Views.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b05bdfce503bdd301f8cdac0857574c6a9e38e8", @"/Views/Admins/EditParts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8f8c29fb9dd4e0d6265d4b0cf961b9e87b35b0e", @"/Views/_ViewImports.cshtml")]
    public class Views_Admins_EditParts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditPartsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admins", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditPart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeletePart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   ViewBag.Title = "Edit Parts"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
 if (!Model.Parts.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 8 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Doesn\'t have available parts.</h1> ");
#nullable restore
#line 8 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
                                                       }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Make</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Category</th>
            <th scope=""col"">Price</th>
            <th scope=""col"">Quantity</th>
            <th scope=""col"">Info</th>
            <th scope=""col"">Delete</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 24 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
         foreach (var part in Model.Parts)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 27 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   Write(part.MakeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 28 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   Write(part.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 29 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   Write(part.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 30 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   Write(part.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</td>\r\n    <td>");
#nullable restore
#line 31 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
   Write(part.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b05bdfce503bdd301f8cdac0857574c6a9e38e89121", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-PartId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
                 WriteLiteral(part.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PartId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-PartId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PartId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("a", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b05bdfce503bdd301f8cdac0857574c6a9e38e812001", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-PartId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
                 WriteLiteral(part.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PartId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-PartId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PartId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("a", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </td>\r\n</tr>");
#nullable restore
#line 46 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
#nullable restore
#line 48 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Views\Admins\EditParts.cshtml"
        }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditPartsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
