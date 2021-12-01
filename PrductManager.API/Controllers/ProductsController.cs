using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _productService.GetAllProducts();
            _logger.LogInformation("GetAll called");
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id > 0)
            {
                var data = _productService.GetAllProducts().FirstOrDefault(p => p.Id == id);
                _logger.LogInformation("Data retrieved.");
                return Ok(data);
            }
            else
            {
                return BadRequest("Id is ");
            }
            
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.AddProduct(product);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct([FromBody] Product product)
        {
            try
            {
                _productService.DeleteProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct(Product Object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.UpdateProduct(Object);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
        }
    }
}
