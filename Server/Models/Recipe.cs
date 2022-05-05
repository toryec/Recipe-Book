using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Server.Models
{
    public class Recipe : IEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Author { get; set; }
        [Required]
        [MaxLength(50)]
        public string? RecipeName { get; set; }

        [Required]
        public List<Ingredient> ? Ingredients { get; set; }

       // public byte[] Timestamp { get; set; } = null!;

       // public DateTimeOffset CreatedDate { get; set; }
        
       // public bool IsDeleted { get; set; }
       
    }
}