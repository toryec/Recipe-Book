using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Shared.Dtos
{
    public class UpdateRecipeDto
    {
        [Required]
        public string? Author { get; set; }

        [Required]
        public string? RecipeName { get; set; }
        
        [Required]
        public List<IngredientDto> ? Ingredients { get; set; }
    }
}