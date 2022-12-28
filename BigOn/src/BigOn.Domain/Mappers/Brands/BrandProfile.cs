using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Mappers.Common;
using BigOn.Domain.Models.Dtos.Brand;
using BigOn.Domain.Models.Entities;

namespace BigOn.Domain.Mappers.Brands
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(dest => dest.Marka, src => src.MapFrom(m => m.Name))
                .ForMember(dest => dest.CreatedDate, src => src.ConvertUsing(new DateFormatConverter(), m => m.CreatedDate));
            //.ReverseMap();

            CreateMap<Brand, HolderChooseDto>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));

        }
    }
}
