using fixxo_backend.Contexts;
using fixxo_backend.Models.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public CategoriesController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string category)
        {

            try
            {

                if(await _context.Categories.AnyAsync(x => x.CategoryName.ToLower() == category.ToLower()))
                {
                    return new BadRequestResult();
                }

                var CategoryEntity = new CategoryEntity { CategoryName = category.ToLower() };

                _context.Add(CategoryEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(CategoryEntity);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var categories = new List<CategoryEntity>();

                foreach (var category in await _context.Categories.ToListAsync())
                {
                    categories.Add(category);
                }

                return new OkObjectResult(categories);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {

                var category = await _context.Categories.FindAsync(id);

                

                return new OkObjectResult(category);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }


        }


    }
}
