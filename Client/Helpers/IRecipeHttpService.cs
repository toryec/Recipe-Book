using BlazorApp.Shared.Dtos;

namespace BlazorApp.Client.Helpers
{
    public interface IRecipeHttpService
    {
        Task<IEnumerable<ReadRecipeDto>> GetAllRecipeAsync();
        Task<ReadRecipeDto>? GetRecipeByIdAsync(long id);
        Task<ReadRecipeDto>? CreateRecipeAsync(ReadRecipeDto recipe);

        Task<bool> DeleteRecipeAsync(long id);

        Task<bool> UpdateRecipeAsync(long id, ReadRecipeDto recipe);

    }
}