using AutoMapper;
using Zaap.Controllers.Resources;
using Zaap.Models;

namespace Zaap.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feauture, FeautureResource>();
        }
    }
}