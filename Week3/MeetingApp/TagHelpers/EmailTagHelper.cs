
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Razor.TagHelpers;

public class EmailTagHelper : TagHelper{

    private string EmailDomainName = "sakarya.edu.tr";

    public string? MailTo {get; set;}
    public override void Process (TagHelperContext context, TagHelperOutput output){
        output.TagName = "a"; 
        var address = MailTo + "@" + EmailDomainName;

        output.Attributes.SetAttribute("href", "mailto:" + address);
        output.Content.SetContent(address);
    }
}