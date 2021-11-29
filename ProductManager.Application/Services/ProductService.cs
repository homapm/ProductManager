using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Application.Contracts;
using ProductManager.Domain.Contracts;
using ProductManager.Domain.Models;

namespace ProductManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetAll().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public async Task<Product> AddProduct(Product Product)
        {
            return await _productRepository.Create(Product);
        }

        public bool UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            return true;
        }
        public bool DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
            return true;
        }
    }
}
