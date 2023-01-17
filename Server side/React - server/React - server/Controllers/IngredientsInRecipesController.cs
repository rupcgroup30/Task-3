using Microsoft.AspNetCore.Mvc;
using React___server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React___server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsInRecipesController : ControllerBase
    {
        // GET: api/<IngredientsInRecipesController>
        [HttpGet("{id}")]
        public IEnumerable<IngredientsInRecipes> Get(int id)
        {
            return IngredientsInRecipes.Read(id);
        }

        // GET api/<IngredientsInRecipesController>/5
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // POST api/<IngredientsInRecipesController>
        [HttpPost]
        public void Post([FromBody] IngredientsInRecipes ingredientsInRecipes)
        {
            ingredientsInRecipes.Insert();
        }

        // PUT api/<IngredientsInRecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientsInRecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
