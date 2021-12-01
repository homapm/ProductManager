using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductManager.Application.Contracts;
using ProductManager.Domain.Contracts;
using ProductManager.Domain.Models;

namespace ProductManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IRepository<Product> product, IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _productService.GetAllProducts();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _productService.GetAllProducts().FirstOrDefault(p => p.Id == id);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct([FromBody] Product product)
        {
            _productService.DeleteProduct(product);
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct(Product Object)
        {
            _productService.UpdateProduct(Object);
            return Ok();
        }
    }
}
