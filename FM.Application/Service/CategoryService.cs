using FM.Application.IService;
using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        // Dependency Injection: Tiêm Repository vào Service
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<Category>> GetAll()
        {
            // Gọi xuống tầng Infrastructure để lấy dữ liệu
            return await _categoryRepo.GetAll();
        }
    }
}