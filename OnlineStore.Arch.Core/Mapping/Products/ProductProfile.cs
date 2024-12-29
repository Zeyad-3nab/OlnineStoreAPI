using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnlineStore.Arch.Core.DTOs.ProductDTO;
using OnlineStore.Arch.Core.Models;

namespace OnlineStore.Arch.Core.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.BrandName, options => options.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d=>d.PictureUrl , optios => optios.MapFrom(s => $"{configuration["BASEURL"]}{s.PictureUrl}"))
                .ForMember(d => d.TypeName, options => options.MapFrom(s => s.ProductType.Name)).ReverseMap()
                ;

            CreateMap<ProductBrand, TypeBrandDTO>().ReverseMap();
            CreateMap<ProductType, TypeBrandDTO>().ReverseMap();
            
        }
    }
}
