using FM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FM.Application.IService
{
	public interface ICategoryService
	{
		// Khai báo hàm lấy danh sách Category để Service thực thi
		Task<List<Category>> GetAll();
	}
}