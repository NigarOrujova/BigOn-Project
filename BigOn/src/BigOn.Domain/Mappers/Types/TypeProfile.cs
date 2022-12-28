using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities;

namespace BigOn.Domain.Mappers.Types
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<ProductType, HolderChooseDto>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
