using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Dtos
{
    public class CreateRecipeDto
    {
        [Required]
        public string? Author { get; set; }

        [Required]
        public string? RecipeName { get; set; }
        
        [Required]
        public List<IngredientDto> ? Ingredients { get; set; }
    }
    
}