using fixxo_backend.Contexts;
using fixxo_backend.Models.Categories;
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
    public class SubCategoriesController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public SubCategoriesController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryRequest req)
        {



            try
            {

                if(await _context.SubCategories.AnyAsync(x => x.CategoryId == req.CategoryId && x.CategoryName.ToLower() == req.CategoryName.ToLower() ))
                {
                    return new BadRequestResult();

                }

                if(!await _context.Categories.AnyAsync(x => x.Id == req.CategoryId))
                {
                    return new BadRequestResult();
                }



                var subCategoryEntity = new SubCategoryEntity { CategoryName = req.CategoryName.ToLower(), CategoryId = req.CategoryId };



                _context.Add(subCategoryEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(subCategoryEntity);

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

                var categories = new List<SubCategoryEntity>();

                foreach (var category in await _context.SubCategories.ToListAsync())
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

                var category = await _context.SubCategories.FindAsync(id);

                

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
