using fixxo_backend.Contexts;
using fixxo_backend.Models.Entities.Product;
using fixxo_backend.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public ProductController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            try
            {
                var colors = new List<ColorEntity>();

                foreach(var colorId in req.Colors)
                {
                    var color = await _context.Colors.FindAsync(colorId);
                    colors.Add(color);
                }

                var sizes = new List<SizeEntity>();

                foreach (var sizeId in req.Sizes)
                {
                    var size = await _context.Sizes.FindAsync(sizeId);
                    sizes.Add(size);
                }


                var productEntity = new ProductEntity
                {
                    Name = req.Name,
                    ImgUrl = req.ImgUrl,
                    Description = req.Description,
                    Price = req.Price,
                    SalePrice = req.SalePrice,
                    CategoryId = req.CategoryId,
                    SubCategoryId = req.SubCategoryId,
                    Colors = colors,
                    Sizes = sizes,

                };



                _context.Add(productEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(productEntity);

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

                var products = new List<ProductResponse>();

                foreach (var product in await _context.Products.Include(x => x.Colors).Include(x => x.Sizes).ToListAsync())
                {


                    var newProduct = new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        ImgUrl = product.ImgUrl,
                        Description = product.Description,
                        Price = product.Price,
                        SalePrice = product.SalePrice,
                        Colors = product.Colors,
                        Sizes = product.Sizes,
                        Category = await _context.Categories.FindAsync(product.CategoryId),
                        SubCategory = await _context.SubCategories.FindAsync(product.SubCategoryId)
                    };

                    products.Add(newProduct);
                }

                return new OkObjectResult(products);

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

                var product = await _context.Products.Include(x => x.Colors).Include(x => x.Sizes).FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                var response = new ProductResponse
                {
                    Name = product.Name,
                    ImgUrl = product.ImgUrl,
                    Description = product.Description,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    Colors = product.Colors,
                    Sizes = product.Sizes,
                    Category = await _context.Categories.FindAsync(product.CategoryId),
                    SubCategory = await _context.SubCategories.FindAsync(product.SubCategoryId)
                };

                return new OkObjectResult(response);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new BadRequestResult();
            }


        }

    }
}
