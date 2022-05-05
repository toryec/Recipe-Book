using BlazorApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data
{
    public class RecipeRepo : IRepo<Recipe>
    {
        private readonly AppDbContext _context;

        public RecipeRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Recipe> CreateAsync(Recipe _object)
        {  
            var recipeObject = await _context.Recipes.AddAsync(_object);
            _context.SaveChanges();
            return recipeObject.Entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var data = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            if (data is null)
            {
                return true;
            }

            _context.Recipes.Remove(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(long id)
        {
            return await _context.Recipes
            .Include(x => x.Ingredients)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Recipe _object)
        {
            _context.Recipes.Update(_object);
           return await _context.SaveChangesAsync() > 0;
        }
    }
}