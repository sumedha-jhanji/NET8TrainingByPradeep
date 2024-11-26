using System.ComponentModel.DataAnnotations;

namespace QuestpondTrainingWebApp.Custom
{
    public class CustomValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
