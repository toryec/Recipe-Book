using BlazorApp.Shared.Dtos;
using FluentValidation;

namespace BlazorApp.Client.Helpers;

public class RecipeModelValidator : AbstractValidator<ReadRecipeDto>
{
    public RecipeModelValidator()
    {
        RuleFor(x => x.RecipeName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Author).NotEmpty().MaximumLength(50);
    }
}