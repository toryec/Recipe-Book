using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Dtos
{
    public class ReadRecipeDto
    {
        public long Id { get; set; }
        public string? Author { get; set; }
        public string? RecipeName { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = null!;
    }
    
}