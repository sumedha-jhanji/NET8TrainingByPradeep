using Microsoft.AspNetCore.Razor.TagHelpers;

namespace QuestpondTrainingWebApp.Custom
{
    public class ExampleCustomTagHelper : TagHelper
    {
        public string Author { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"This is custom tag helper example by {Author}");
        }
    }
}
