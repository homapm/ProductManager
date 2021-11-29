using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Domain.Models;

namespace ProductManager.Application.Contracts
{
    public interface IProductService
    {
        public Product GetProduct(int id);

        public IEnumerable<Product> GetAllProducts();

        public Task<Product> AddProduct(Product product);

        public bool UpdateProduct(Product product);

        public bool DeleteProduct(Product product);
        
    }
}
