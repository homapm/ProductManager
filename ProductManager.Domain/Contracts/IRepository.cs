using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Contracts
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);
        public Task<T> Create(T @object);

        public void Update(T @object);

        public void Delete(T @object);
    }
}
