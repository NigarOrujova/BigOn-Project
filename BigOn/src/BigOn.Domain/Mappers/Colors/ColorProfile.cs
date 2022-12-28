using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities;

namespace BigOn.Domain.Mappers.Colors
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ProductColor, HolderChooseDto>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.HexCode));
        }
    }
}
