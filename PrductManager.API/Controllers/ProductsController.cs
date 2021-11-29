﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductManager.Application.Contracts;
using ProductManager.Domain.Contracts;
using ProductManager.Domain.Models;

namespace ProductManager.API.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IRepository<Product> product, IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Object GetAll()
        {
            var data = _productService.GetAllProducts();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("{id}")]
        public Object Get(int id)
        {
            var data = _productService.GetAllProducts().FirstOrDefault(p => p.Id == id);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpPost("Add")]
        public async Task<Object> Add([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return true;
        }

        [HttpDelete("Delete")]
        public bool DeleteProduct([FromBody] Product product)
        {
            _productService.DeleteProduct(product);
            return true;
        }

        [HttpPut("Update")]
        public bool UpdateProduct(Product Object)
        {
            _productService.UpdateProduct(Object);
            return true;
        }
    }
}
