
using FM.Application.IService;
using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
