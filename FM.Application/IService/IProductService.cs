using FM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Application.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<bool> Add(Product newProduct);
        Task<bool> Update(Product newProduct);
        Task<Product?> FindById(Guid id);
    }
}
