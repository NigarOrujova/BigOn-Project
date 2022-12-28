using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelpersCustomize.AppCode.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("bsbtn")]
    public class BsButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-class")]
        public string CssClass { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;

            var inner = await output.GetChildContentAsync();

            output.Attributes.Add("class",$"btn {CssClass}");

            //output.Content.SetContent(inner.GetContent());
            output.Content.SetHtmlContent(inner.GetContent());
        }





















        //public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    var inner = await output.GetChildContentAsync();

        //    output.Content.SetHtmlContent($"<button class='btn {this.CssClass}'>{inner.GetContent()}</button>");
        //}
    }
}
