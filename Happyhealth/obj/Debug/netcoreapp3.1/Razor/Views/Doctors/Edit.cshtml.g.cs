#pragma checksum "C:\Users\Sushmitha\source\repos\Happyhealth\Happyhealth\Views\Doctors\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "783a712bb47e5d78196866d5118634662cbd2aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctors_Edit), @"mvc.1.0.view", @"/Views/Doctors/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"783a712bb47e5d78196866d5118634662cbd2aee", @"/Views/Doctors/Edit.cshtml")]
    #nullable restore
    public class Views_Doctors_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Happyhealth.Models.Doctor>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Sushmitha\source\repos\Happyhealth\Happyhealth\Views\Doctors\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Doctor</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
            <div class=""form-group"">
                <label asp-for=""Name"" class=""control-label""></label>
                <input asp-for=""Name"" class=""form-control"" />
                <span asp-validation-for=""Name"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Specialty"" class=""control-label""></label>
                <input asp-for=""Specialty"" class=""form-control"" />
                <span asp-validation-for=""Specialty"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Experience"" class=""control-label""></label>
                <input asp-for=""Experience"" class=""form-control"" />
                <span asp-validatio");
            WriteLiteral(@"n-for=""Experience"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Availability"" class=""control-label""></label>
                <input asp-for=""Availability"" class=""form-control"" />
                <span asp-validation-for=""Availability"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\Sushmitha\source\repos\Happyhealth\Happyhealth\Views\Doctors\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Happyhealth.Models.Doctor> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
