using AutoMapper;
using FM.API.DTO;
using FM.Domain.Entities;

namespace FM.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Categoryname)) // Nếu tên khác nhau
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Suppliername));

                
        }
    }
}
