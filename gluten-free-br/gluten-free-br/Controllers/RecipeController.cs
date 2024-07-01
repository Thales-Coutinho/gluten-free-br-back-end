using Asp.Versioning;
using gluten_free_br.Model;
using gluten_free_br.Services;
using Microsoft.AspNetCore.Mvc;

namespace gluten_free_br.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private IRecipeService _recipeService;

    public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(_recipeService.FindAll());
    }


    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        Recipe recipe = _recipeService.FinfById(id);
        if(recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Recipe recipe)
        {
            if (recipe == null) return BadRequest();
            return Ok(_recipeService.Create(recipe));
        }

    [HttpPut]
    public IActionResult Put([FromBody] Recipe recipe)
        {
            if (recipe == null) return BadRequest();
            return Ok(_recipeService.Update(recipe));
        }
        
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
        {
            _recipeService.Delete(id);
            return NoContent();
        }
}