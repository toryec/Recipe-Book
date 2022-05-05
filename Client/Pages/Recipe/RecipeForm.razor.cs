using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Client.Pages.Recipe;

public partial class RecipeForm
{
    public IngredientDto? ingredient;
    public bool disable;

    private IngredientEditAction ingredientEditAction;

    [Parameter] 
    public ReadRecipeDto RecipeDto {get; set;} = default!;

    [Parameter]
    public EventCallback HandleValidSubmit {get; set;}

    // [Parameter]
    // public async Task Save {get; set;} = default!;
    protected override void OnInitialized()
    {
       // RecipeDto.Ingredients = new List<IngredientDto>();
    }
    public void AddIngredient()
    {
        if(RecipeDto.Ingredients is null)
        {
            RecipeDto.Ingredients = new List<IngredientDto>();
        }
        
        ingredientEditAction = IngredientEditAction.Add;
        ingredient = new IngredientDto();
    }
    public void OnIngredientFormComplete(bool isSuccesful)
    {
        if (isSuccesful && ingredientEditAction == IngredientEditAction.Add)
        {
            if (ingredient is not null)
            {
                RecipeDto.Ingredients.Add(ingredient);
            }
        }

        Console.WriteLine($"From Recipe Form: {ingredient.ItemName}, HashCode: {ingredient.GetHashCode()}");
        ingredientEditAction = IngredientEditAction.None;
        ingredient = null;
        disable = false;
    }

    public void Update(IngredientDto ingredientToUpdate)
    {
        ingredient = ingredientToUpdate;
        ingredientEditAction = IngredientEditAction.Update;
        disable = true;
    }

    public void Delete(IngredientDto ingredientToDelete)
    {
        //Remove ingredients from collection
        RecipeDto.Ingredients.Remove(ingredientToDelete);
    }

    private enum IngredientEditAction 
    {
        None,
        Add,
        Update
    }
}