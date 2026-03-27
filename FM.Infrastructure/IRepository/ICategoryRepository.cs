using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.Infrastructure.Repository
{
    public interface ICategoryRepository
    {
        public async Task<List<Category>> GetAll();

    }
}