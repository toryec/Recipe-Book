using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Pages.Recipe;

public partial class UpdateRecipe
{
     public ReadRecipeDto recipeToUpdate = default!;

    [Parameter]
    public long Id {get; set;}

    [Inject]
    public IRecipeHttpService RecipeService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager {get; set;} = default!;

    [Inject]
    private IJSRuntime jSRuntime {get; set;} = default!;


    protected override async Task OnInitializedAsync()
    {
        recipeToUpdate = await RecipeService.GetRecipeByIdAsync(Id);
        
    }

    public async Task UpdateAsync()
    {
        Console.WriteLine("Working...");
    }

}