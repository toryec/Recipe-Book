using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Server.Models
{
    public class Ingredient : IEntity
    {
        [Key]
        [Required]
        public long Id {get; set;} 

        [Required]
        
        public long RecipeId {get; set;}

        [Required]
        [MaxLength(50)]
        public string? ItemName { get; set; }
        
        [Required]
        public string? ItemAmount {get; set;}

        public Recipe? Recipe {get; set;}

       // public byte[] Timestamp  { get; set; } = default!;

       // public DateTimeOffset CreatedDate { get; set; }

       // public bool IsDeleted { get; set; }

    }
}