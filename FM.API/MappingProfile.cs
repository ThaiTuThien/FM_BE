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
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Categoryname)) 
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Suppliername));
            CreateMap<AddProductDTO, Product>()
            .ForMember(dest => dest.Categoryid, opt => opt.MapFrom(src => src.Categoryid.ToOracleGuid()))
            .ForMember(dest => dest.Supplierid, opt => opt.MapFrom(src => src.Supplierid.ToOracleGuid()));
            CreateMap<UpdateProductDTO, Product>()
           .ForMember(dest => dest.Categoryid, opt => opt.MapFrom(src => src.Categoryid.ToOracleGuid()))
           .ForMember(dest => dest.Supplierid, opt => opt.MapFrom(src => src.Supplierid.ToOracleGuid()))
           .ForMember(dest => dest.Productid, opt => opt.MapFrom(src => src.Productid.ToOracleGuid()));

        }
    }
}
