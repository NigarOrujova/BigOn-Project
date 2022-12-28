using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities;

namespace BigOn.Domain.Mappers.ProductSizes
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSize, HolderChooseDto>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
