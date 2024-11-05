using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MeetingApp.TagHelpers{
    public class EmailTagHelper: TagHelper{

        private const string EmailDomain = "sakarya.edu.tr";

        public string? MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //output will be an anchor tag <a> </a>

            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}

