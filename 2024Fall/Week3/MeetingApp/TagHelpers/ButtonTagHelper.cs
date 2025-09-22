using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Razor.TagHelpers;

public class ButtonTagHelper : TagHelper{

    public string ButtonText {get; set;} = "CLICK ME";
    public string ButtonType {get; set;} = "button";

    public override void Process(TagHelperContext context, TagHelperOutput output){
        output.TagName = "button";
        output.Attributes.SetAttribute("type", ButtonType);
        output.Attributes.SetAttribute("class", "btn btn-dark");
        output.Content.SetContent(ButtonText);

    }
}