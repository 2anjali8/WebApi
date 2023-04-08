using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> category = new List<Category>()
        {
            new Category() { Id = 1,Title="Electronic"},
            new Category() { Id = 2,Title="Fashion"},
            new Category() { Id = 3,Title="Decoration"},
            new Category() { Id = 4,Title="Households"}
        };

        [HttpGet]
         public List<Category> Get() 
         {
            return category;
         }
        [HttpPost]

        public IActionResult Post([FromBody]Category cat) 
        {
            category.Add(cat);
            return Ok(category);
        }

    }
}
