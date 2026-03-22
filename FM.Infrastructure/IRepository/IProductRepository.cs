using FM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Infrastructure.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<bool> Add(Product newProduct);
        Task<bool> Update(Product newProduct);
        Task<Product?> GetById(Guid id);
    }
}
