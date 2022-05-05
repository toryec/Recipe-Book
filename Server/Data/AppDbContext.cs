using BlazorApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder
                .Entity<Recipe>().HasData(
                    new Recipe{Id = 1, Author = "Mike", RecipeName = "Alfrado"},
                    new Recipe{Id = 2,Author= "Jake",RecipeName="Tomato Soup"},
                    new Recipe{Id = 3, Author="Paul", RecipeName="Spicy Honey Wings"}
                );

            modelBuilder.Entity<Ingredient>()
                .HasOne(r => r.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient{Id=1,RecipeId=1,ItemName="Chicken Thighs", ItemAmount="20 grams"},
                new Ingredient{Id=2,RecipeId=1, ItemName="Milk", ItemAmount ="15 grams"},
                new Ingredient{Id=3,RecipeId=2,ItemName="Tomatoes",ItemAmount= "6 grams"},
                new Ingredient{Id=4,RecipeId=2,ItemName="Bread",ItemAmount= "10 grams"},
                new Ingredient{Id=5,RecipeId=3,ItemName="Chicken Wings",ItemAmount= "40 grams"},
                new Ingredient{Id=6,RecipeId=3,ItemName="Honey",ItemAmount= "6 grams"}
            );
        }
}
    }

    