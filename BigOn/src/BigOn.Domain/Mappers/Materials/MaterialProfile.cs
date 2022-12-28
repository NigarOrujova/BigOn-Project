using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities;

namespace BigOn.Domain.Mappers.Materials
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<ProductMaterial, HolderChooseDto>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
