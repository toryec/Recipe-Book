using AutoMapper;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Dtos;

namespace BlazorApp.Server.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            // Source --> Target
            CreateMap<Recipe, ReadRecipeDto>();
            CreateMap<CreateRecipeDto,Recipe>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<UpdateRecipeDto, Recipe>();
        }
    }
}