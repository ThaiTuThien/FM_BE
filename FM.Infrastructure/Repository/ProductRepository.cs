using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Supplier)
            .ToListAsync();
        }

        public async Task<bool> Add(Product newProduct)
        {
             await _context.Products
            .AddAsync(newProduct);

           int result = await _context.SaveChangesAsync();

           return result > 0;
        }

        public async Task<bool> Update(Product newProduct)
        {
            _context.Products.Update(newProduct);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Product?> GetById(Guid id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Productid == id);
            return result;
        }
    }
}
