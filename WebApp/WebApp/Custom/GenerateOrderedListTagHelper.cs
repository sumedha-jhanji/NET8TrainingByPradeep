using Microsoft.AspNetCore.Razor.TagHelpers;

namespace QuestpondTrainingWebApp.Custom
{
    public class GenerateOrderedListTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var existingContent = await output.GetChildContentAsync();
            var existingData = existingContent.GetContent();
            if (existingData != null && existingData.Count() > 0) {                
                var listData = existingData.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (listData.Count() > 1)
                {
                    output.TagName = "ul";
                    foreach (var item in listData)
                    {
                        output.Content.AppendHtml($"<li>{item}</li>");
                    }
                }
            }
        }
    }
}
