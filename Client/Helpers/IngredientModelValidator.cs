using BlazorApp.Shared.Dtos;
using FluentValidation;

namespace BlazorApp.Client.Helpers;

public class IngredientModelValidator: AbstractValidator<IngredientDto>
{
    public IngredientModelValidator()
    {
       RuleFor(x => x.ItemName).NotEmpty().MaximumLength(50);
       RuleFor(x => x.ItemAmount).NotEmpty().MaximumLength(50); 
    }
}