using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Pages.Recipe;

public partial class RecipeList
{
    [Inject]
    private IJSRuntime JS {get; set;} = default!;

    [Inject]
    private NavigationManager NavigationManager {get; set;} = default!;

    [Inject]
    private IRecipeHttpService RecipeHttpService { get; set; } = default!;

    private IEnumerable<ReadRecipeDto> recipeList = Enumerable.Empty<ReadRecipeDto>();

    protected override async Task OnInitializedAsync()
    {
        recipeList = await RecipeHttpService.GetAllRecipeAsync();
       // recipeList = null;
    }
}