using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages.Recipe;

public partial class RecipeTable
{
    [Parameter]
    public IEnumerable<ReadRecipeDto>? Recipes { get; set; }
}