using fastwebsite.Entities;
using fastwebsite.Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fastwebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FastdbContext _context;
        private readonly InterfaceProductsFactory _productFactory;

        public ProductsController(FastdbContext context, InterfaceProductsFactory productFactory)
        {
            _context = context;
            _productFactory = productFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product productData)
        {
            if (productData == null)
            {
                return BadRequest("Invalid product data.");
            }

            var product = _productFactory.CreateProduct(
                productData.ProductName,
                productData.Price,
                productData.Img,
                productData.Des,
                productData.CateId
            );

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        }
    }
}