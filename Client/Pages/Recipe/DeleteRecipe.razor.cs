using BlazorApp.Client.Helpers;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Client.Pages.Recipe;

public partial class DeleteRecipe
{
    public ReadRecipeDto recipeToDelete = default!;

    [Inject]
    public IRecipeHttpService RecipeService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager {get; set;} = default!;

    [Inject]
    private IJSRuntime jSRuntime {get; set;} = default!;


    [Parameter]
    public long Id {get; set;}
    

    protected override async Task OnInitializedAsync()
    {
        recipeToDelete = await RecipeService.GetRecipeByIdAsync(Id);
    }

    protected async Task Delete()
    {
        bool confirmed = await jSRuntime.InvokeAsync<bool>("confirm", "You're about to Delete a Recipe");
        if(!confirmed)
        {
            return;
        }
        else
        {
            bool deleteResponse = await RecipeService.DeleteRecipeAsync(Id);
            if(deleteResponse)
            {
                await jSRuntime.InvokeVoidAsync("alert", "Delete Successful");
                NavigationManager.NavigateTo("recipelist");
            }
        }
        
    }
    public  async Task Cancel()
    {
        
        bool confirmed = await jSRuntime.InvokeAsync<bool>("confirm", "You're about to Cancel");
        if(!confirmed)
        {
            return;
        }
        
        NavigationManager.NavigateTo("recipelist");
    }

}