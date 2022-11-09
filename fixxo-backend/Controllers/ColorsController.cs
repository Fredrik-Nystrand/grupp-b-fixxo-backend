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
    public class ColorsController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public ColorsController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string color)
        {

            try
            {

                if(await _context.Colors.AnyAsync(x => x.Color.ToLower() == color.ToLower()))
                {
                    return new BadRequestResult();
                }

                var colorEntity = new ColorEntity { Color = color.ToLower() };

                _context.Add(colorEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(colorEntity);

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

                var colors = new List<ColorEntity>();

                foreach (var color in await _context.Colors.ToListAsync())
                {
                    colors.Add(color);
                }

                return new OkObjectResult(colors);

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

                var color = await _context.Colors.FindAsync(id);

                

                return new OkObjectResult(color);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }


        }


    }
}
