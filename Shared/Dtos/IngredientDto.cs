using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Dtos
{
    public class IngredientDto
    {
        public long Id { get; set; }
        public string ItemName { get; set; } = null!;
        
        public string ItemAmount {get; set;} = default!;
    }
    
}