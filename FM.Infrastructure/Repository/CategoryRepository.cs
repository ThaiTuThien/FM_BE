using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
0namespace FM.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
   
            return await _context.Categories.ToListAsync();
        }
    }
}