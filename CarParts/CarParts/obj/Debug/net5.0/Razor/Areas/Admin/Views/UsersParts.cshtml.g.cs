#pragma checksum "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6caac44be4ef1acdc10fd513bc27de12d4cd7aab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_UsersParts), @"mvc.1.0.view", @"/Areas/Admin/Views/UsersParts.cshtml")]
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
#line 1 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
using CarParts.Areas.Admin.Views.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6caac44be4ef1acdc10fd513bc27de12d4cd7aab", @"/Areas/Admin/Views/UsersParts.cshtml")]
    public class Areas_Admin_Views_UsersParts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<UsersPartsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   ViewData["Title"] = "Users Parts"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 6 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>You don\'t have available offers.</h1> ");
#nullable restore
#line 8 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
                                          }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\n    <thead class=\"thead-dark\">\n        <tr>\n            <th scope=\"col\">Username</th>\n            <th scope=\"col\">Parts count</th>\n            <th scope=\"col\">Edit parts</th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 20 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 23 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 24 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   Write(user.PartsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>\n        <a type=\"button\" class=\"btn btn-success\"\n           asp-controller=\"Admins\"\n           asp-action=\"EditParts\"");
            BeginWriteAttribute("asp-route-UserId", "\n           asp-route-UserId=\"", 667, "\"", 709, 1);
#nullable restore
#line 29 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
WriteAttributeValue("", 697, user.UserId, 697, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\n           a>Edit parts</a>\n    </td>\n</tr>\n");
#nullable restore
#line 33 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
#nullable restore
#line 35 "C:\Users\Antonio\OneDrive\Работен плот\CarParts-MVC-ASP.NET-Project-main\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<UsersPartsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
