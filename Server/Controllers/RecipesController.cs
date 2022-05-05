using AutoMapper;
using BlazorApp.Server.Data;
using BlazorApp.Server.Models;
using BlazorApp.Server.Services;
using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadRecipeDto>>> GetAllRecipeAsync()
        {
            var recipeItem = await _recipeService.GetAllRecipesAsync();

            return Ok(_mapper.Map<IEnumerable<ReadRecipeDto>>(recipeItem));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRecipeDto>> GetRecipeByIdAsync(long id)
        {
            var recipeItem = await _recipeService.GetRecipeByIdAsync(id);
            if(recipeItem != null)
            {
                return Ok(_mapper.Map<ReadRecipeDto>(recipeItem));
            }
            return NotFound();        
        }

        [HttpPost]
        public async Task<ActionResult<ReadRecipeDto>> CreateRecipeAsync([FromBody] CreateRecipeDto createRecipe)
        {
            var recipeModel = _mapper.Map<Recipe>(createRecipe);
            await _recipeService.CreateRecipeAsync(recipeModel);
            return _mapper.Map<ReadRecipeDto>(recipeModel);
            
           // return CreatedAtAction(nameof(GetRecipeByIdAsync), new {Id = recipeModel.Id}, recipeModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRecipeAsync(long id)
        {
            await _recipeService.DeleteRecipeAsync(id);
            return Ok(true);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateRecipeAsync(long id, [FromBody] UpdateRecipeDto recipe)
        {
            var updatemodel = _mapper.Map<Recipe>(recipe);
            await _recipeService.UpdateRecipeAsync(id,updatemodel);
            return Ok(true);
        }


        
    }
}