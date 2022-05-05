using BlazorApp.Server.Data;
using BlazorApp.Server.Models;

namespace BlazorApp.Server.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepo<Recipe> _repository;

        public RecipeService(IRepo<Recipe> repository)
        {
            _repository = repository;
        }
        public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
        {
            if(recipe == null)
            {
                 throw new ArgumentException(nameof(recipe));
            }
           return await _repository.CreateAsync(recipe);

        }

        public async Task<bool> DeleteRecipeAsync(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);   
        }

        public async Task<bool> UpdateRecipeAsync(long id, Recipe recipe)
        {
            var data = await _repository.GetByIdAsync(id);
            if(data != null)
            {
               data.RecipeName = recipe.RecipeName;
               data.Ingredients = recipe.Ingredients;
               data.Author = recipe.Author;
               await _repository.UpdateAsync(data);
               return true; 
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }
            
        }
    }
}