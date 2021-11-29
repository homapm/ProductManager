using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Domain.Contracts;
using ProductManager.Domain.Data;
using ProductManager.Domain.Models;

namespace ProductManager.Domain.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        readonly ProductManagerDbContext _dbContext;
        public ProductRepository(ProductManagerDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> Create(Product @object)
        {
            var obj = await _dbContext.Products.AddAsync(@object);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public void Update(Product @object)
        {
            _dbContext.Products.Update(@object);
            _dbContext.SaveChanges();
        }

        public void Delete(Product @object)
        {
            _dbContext.Remove(@object);
            _dbContext.SaveChanges();
        }
    }
}
