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
    public class SizesController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public SizesController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string size)
        {

            try
            {

                if(await _context.Sizes.AnyAsync(x => x.Size.ToLower() == size.ToLower()))
                {
                    return new BadRequestResult();
                }

                var SizeEntity = new SizeEntity { Size = size.ToLower() };

                _context.Add(SizeEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(SizeEntity);

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

                var sizes = new List<SizeEntity>();

                foreach (var size in await _context.Sizes.ToListAsync())
                {
                    sizes.Add(size);
                }

                return new OkObjectResult(sizes);

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

                var size = await _context.Sizes.FindAsync(id);

                

                return new OkObjectResult(size);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }


        }


    }
}
