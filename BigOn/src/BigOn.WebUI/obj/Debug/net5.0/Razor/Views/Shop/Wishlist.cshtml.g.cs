#pragma checksum "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d464ad3bfa213ea493cf7b2f9e57dfaef8dc3196"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Wishlist), @"mvc.1.0.view", @"/Views/Shop/Wishlist.cshtml")]
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
#line 4 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Domain.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Domain.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Domain.Business.AccountModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Application.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\_ViewImports.cshtml"
using BigOn.Domain.Models.Dtos.Products;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d464ad3bfa213ea493cf7b2f9e57dfaef8dc3196", @"/Views/Shop/Wishlist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c70b26d261c709db0a00e6e1e99c513b1978852", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shop_Wishlist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("cart-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Newsletter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/toastr.js/toastr.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/toastr.js/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/js/customize.toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/jquery.cookie/jquery.cookie.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
  
    ViewData["Title"] = "Wishlist";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-area ptb-50"">
    <div class=""container"">
        <div class=""breadcrumb"">
            <ul>
                <li><a href=""index.html"">Home</a></li>
                <li class=""active""><a href=""wishlist.html"">Wishlist</a></li>
            </ul>
        </div>
    </div>
    <!-- Container End -->
</div>
<!-- Breadcrumb End -->
<!-- Wish List Start -->
<div class=""cart-main-area wish-list pb-50"">
    <div class=""container"">
        <!-- Section Title Start -->
        <h2 class=""text-capitalize sub-heading"">wishlist</h2>
        <!-- Section Title Start End -->
        <div class=""row"">
            <div class=""col-md-12 col-12 col-12"">
                <!-- Form Start -->
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc31968982", async() => {
                WriteLiteral(@"
                    <!-- Table Content Start -->
                    <div class=""table-content table-responsive"">
                        <table>
                            <thead>
                                <tr>
                                    <th class=""product-remove"">Remove</th>
                                    <th class=""product-thumbnail"">Image</th>
                                    <th class=""product-name"">Product</th>
                                    <th class=""product-price"">Unit Price</th>
                                    <th class=""product-quantity"">Stock Status</th>
                                    <th class=""product-subtotal"">add to cart</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 43 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td class=\"product-remove\">\r\n                                            <a href=\"http://google.com\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1924, "\"", 1968, 3);
                WriteAttributeValue("", 1934, "removeFromWishlist(event,", 1934, 25, true);
#nullable restore
#line 47 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
WriteAttributeValue("", 1959, item.Id, 1959, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1967, ")", 1967, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">
                                                <i class=""fa fa-times"" aria-hidden=""true""></i>
                                            </a>
                                        </td>
                                        <td class=""product-thumbnail"">
                                            <a href=""#"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319611485", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2353, "~/uploads/images/", 2353, 17, true);
#nullable restore
#line 53 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
AddHtmlAttributeValue("", 2370, item.Images.FirstOrDefault()?.Path, 2370, 35, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </a>\r\n                                        </td>\r\n                                        <td class=\"product-name\"><a href=\"#\">");
#nullable restore
#line 57 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                                                                        Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\r\n                                        <td class=\"product-price\"><span class=\"amount\">");
#nullable restore
#line 58 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                                                                                  Write(item.Price?.ToString("0.00₼"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\r\n                                        <td class=\"product-stock-status\"><span>in stock</span></td>\r\n                                        <td class=\"product-add-to-cart\">\r\n                                            <a data-product-id=\"");
#nullable restore
#line 61 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                                                           Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" basket>Sebete at</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <!-- Table Content Start -->\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <!-- Form End -->\r\n            </div>\r\n        </div>\r\n        <!-- Row End -->\r\n    </div>\r\n</div>\r\n<!-- Wish List End -->\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319616356", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319617574", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("addjs", async() => {
                WriteLiteral("    \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319618999", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319620186", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d464ad3bfa213ea493cf7b2f9e57dfaef8dc319621373", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        function removeFromWishlist(ev, id) {
            ev.preventDefault();
            //[1,2,3,4]

            let wishlist = $.cookie('wishlist');

            if (wishlist != undefined) {
                //logic
                wishlist = JSON.parse(`${wishlist}`);

                wishlist = wishlist.filter(item => item != id);

                $.cookie('wishlist', JSON.stringify(wishlist).replace(/""/g, """"),
                    {
                        expires: 15,
                        path: ''
                    });
            }


            $(ev.currentTarget).closest('tr').remove();
        }


        $(document).ready(function() {
            $('a[data-product-id][basket]').click(function(e) {
                e.preventDefault();

                let data = $(e.currentTarget).data();

                $.ajax({
                    url: '");
#nullable restore
#line 120 "C:\Users\Nigar\Desktop\BigOnLast\BigOn\BigOn\src\BigOn.WebUI\Views\Shop\Wishlist.cshtml"
                     Write(Url.Action("AddToBasket"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type: 'POST',
                    data: data,
                    contentType: 'application/x-www-form-urlencoded',
                    success: function(response) {

                        if (response.error == true) {
                             toastr.error(response.message, ""Xəta!"");
                            return;
                        }

                        toastr.success(response.message, ""Ugur!"");
                        removeFromWishlist(e,data.id);

                    },
                    error: function(response) {
                        console.log(response);
                    },
                });

            });
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591