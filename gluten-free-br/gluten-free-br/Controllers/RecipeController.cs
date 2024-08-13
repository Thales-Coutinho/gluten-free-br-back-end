using Asp.Versioning;
using gluten_free_br.Model;
using gluten_free_br.Business;
using Microsoft.AspNetCore.Mvc;

namespace gluten_free_br.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private IRecipeBusiness _recipeBusiness;

    public RecipeController(ILogger<RecipeController> logger, IRecipeBusiness recipeBusiness)
    {
        _logger = logger;
        _recipeBusiness = recipeBusiness;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(_recipeBusiness.FindAll());
    }


    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        Recipe recipe = _recipeBusiness.FinfById(id);
        if(recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Recipe recipe)
        {
            if (recipe == null) return BadRequest();
            return Ok(_recipeBusiness.Create(recipe));
        }

    [HttpPut]
    public IActionResult Put([FromBody] Recipe recipe)
        {
            if (recipe == null) return BadRequest();
            return Ok(_recipeBusiness.Update(recipe));
        }
        
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
        {
            _recipeBusiness.Delete(id);
            return NoContent();
        }
}