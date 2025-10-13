using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RSVPApp.TagHelpers{
    
    [HtmlTargetElement("email")]
    public class EmailTagHelper: TagHelper{

        [HtmlAttributeName("mail-to")]
        public string? MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //anchor tag <a> </a>

            var address = MailTo;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    } 
}