#pragma checksum "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edfd002c3e24e86ed2fa865e131b6b31ac33de1e"
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
#line 1 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
using CarParts.Areas.Admin.Views.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edfd002c3e24e86ed2fa865e131b6b31ac33de1e", @"/Areas/Admin/Views/UsersParts.cshtml")]
    public class Areas_Admin_Views_UsersParts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<UsersPartsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   ViewData["Title"] = "Users Parts"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>You don\'t have available offers.</h1> ");
#nullable restore
#line 8 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
                                          }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead class=\"thead-dark\">\r\n        <tr>\r\n            <th scope=\"col\">Username</th>\r\n            <th scope=\"col\">Parts count</th>\r\n            <th scope=\"col\">Edit parts</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 20 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n    <td>");
#nullable restore
#line 23 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>");
#nullable restore
#line 24 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
   Write(user.PartsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        <a type=\"button\" class=\"btn btn-success\"\r\n           asp-controller=\"Admins\"\r\n           asp-action=\"EditParts\"");
            BeginWriteAttribute("asp-route-UserId", "\r\n           asp-route-UserId=\"", 694, "\"", 737, 1);
#nullable restore
#line 29 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
WriteAttributeValue("", 725, user.UserId, 725, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n           a>Edit parts</a>\r\n    </td>\r\n</tr>\r\n");
#nullable restore
#line 33 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
#nullable restore
#line 35 "C:\Users\Hringald\Desktop\GitHub\CarParts-MVC-ASP.NET-Project\CarParts\CarParts\Areas\Admin\Views\UsersParts.cshtml"
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
