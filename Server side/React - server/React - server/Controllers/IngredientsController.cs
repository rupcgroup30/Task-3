using Microsoft.AspNetCore.Mvc;
using React___server.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React___server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        // GET: api/<IngredientsController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return Ingredient.Read();
        }

        // GET api/<IngredientsController>/5
        [HttpGet("{id}")]
        public IEnumerable<Ingredient> GetByRecipeId(int id)
        {
            return Ingredient.ReadRecipeIngredients(id);
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public void Post([FromBody] Ingredient ingredient)
        {
            ingredient.Insert();
        }

        [HttpPost("{recipeId}/{ingredientId}")]
        public void Post(int recipeId, int ingredientId)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.InsertIngredientByRecipe(recipeId, ingredientId);
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
