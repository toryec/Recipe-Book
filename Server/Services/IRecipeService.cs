using BlazorApp.Server.Models;

namespace BlazorApp.Server.Services
{
    public interface IRecipeService
    {
        Task<Recipe> CreateRecipeAsync(Recipe recipe);
        Task<bool> UpdateRecipeAsync(long id, Recipe recipe);
        Task<bool> DeleteRecipeAsync(long id);
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe?> GetRecipeByIdAsync(long id);
 
    }
}