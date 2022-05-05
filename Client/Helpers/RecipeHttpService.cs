
using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Shared.Dtos;

namespace BlazorApp.Client.Helpers
{
    public class RecipeHttpService : IRecipeHttpService
    {

         //TODO: Bad code, remove
        public static List<ReadRecipeDto> Recipes
         = new List<ReadRecipeDto>();
          //TODO: Bad code, remove

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public RecipeHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            jsonSerializerOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true};

        }

        public async Task<ReadRecipeDto>? CreateRecipeAsync(ReadRecipeDto recipe)
        {
            var response = await _httpClient.PostAsJsonAsync("recipes",recipe);
            return await response.Content.ReadFromJsonAsync<ReadRecipeDto>();

        }

        public async Task<bool> DeleteRecipeAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"recipes/{id}");
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<IEnumerable<ReadRecipeDto>> GetAllRecipeAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<ReadRecipeDto>>("recipes");

                if (response is null)
                {
                    //Perform validation
                    throw new HttpRequestException("No data found");
                }

                //TODO: Bad code, remove
                Recipes = response.ToList();
                //TODO: Bad code, remove

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            
        }

        public async Task<ReadRecipeDto>? GetRecipeByIdAsync(long id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ReadRecipeDto>($"recipes/{id}");
                if(response is null)
                {
                    //Perform Validation
                   throw new HttpRequestException("No data found");
                }
                return response;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"Request Unsuccefull: {ex} ");
                throw;
            }
           
        }

        public async Task<bool> UpdateRecipeAsync(long id, ReadRecipeDto recipe)
        {
            var response = await _httpClient.PutAsJsonAsync($"recipes/{id}",recipe);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        
    }
}