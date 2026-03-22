
using FM.Application.IService;
using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FM.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<bool> Add(Product product)
        {
            return await _repo.Add(product);
        }

        public async Task<bool> Update(Product product)
        {
            return await _repo.Update(product);
        }

        public async Task<Product?> FindById(Guid id)
        {
            return await _repo.GetById(id);
        }
    }
}
