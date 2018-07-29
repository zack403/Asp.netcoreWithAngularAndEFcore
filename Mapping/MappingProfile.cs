using System.Linq;
using AutoMapper;
using Zaap.Controllers.Resources;
using Zaap.Models;

namespace Zaap.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feauture, FeautureResource>();
            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));


            //API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.Ignore())
            .AfterMap((vr, v) =>
            {
                //Remove unselected features
                var removedfeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                foreach (var f in removedfeatures)
                    v.Features.Remove(f);

                //Add new features
                var addedfeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id });
                foreach (var f in addedfeatures)
                    v.Features.Add(f);
            });





        }
    }
}