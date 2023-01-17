using Microsoft.AspNetCore.Mvc;
using React___server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React___server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<Recipes> Get()
        {
            return Recipes.Read();
        }

        // GET api/<RecipesController>/5
       

        // POST api/<RecipesController>
        [HttpPost]
        public int Post([FromBody] Recipes recipes)
        {
           return recipes.Insert();
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
