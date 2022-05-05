using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Pages.Recipe;

public partial class CreateRecipe
{
    public ReadRecipeDto recipe;
    public IngredientDto ingredient;
    public bool cancel;
    public CreateRecipe()
    {
        recipe = new ReadRecipeDto();
        ingredient = new IngredientDto();
    }

    [Inject]
    public IRecipeHttpService RecipeService { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager {get; set;} = default!;

    [Inject]
    private IJSRuntime jSRuntime {get; set;} = default!;

    public async Task SaveAsync()
    {
       // Console.WriteLine("Working");
        var recipeResponse = await RecipeService.CreateRecipeAsync(recipe);
        bool confirmed = await jSRuntime.InvokeAsync<bool>("confirm", "You are adding a new recipe");
        if(!confirmed)
        {
            return;
        }
        else
        {
            if(recipeResponse?.Id > 0)
            {
                await jSRuntime.InvokeVoidAsync("alert", "Recipe Added");
                NavigationManager.NavigateTo("recipelist");
            }
        }

        recipe.Author = string.Empty;
        recipe.RecipeName = string.Empty;
        recipe.Ingredients = new List<IngredientDto>();
    }
    public  async Task Cancel()
    {
        bool confirmed = await jSRuntime.InvokeAsync<bool>("confirm", "You are about to Cancel");
        if(!confirmed)
        {
            return;
        }
        
        NavigationManager.NavigateTo("recipelist");
    }

}
