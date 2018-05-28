using System.Linq;
using AutoMapper;
using vega.Controllers.Resource;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {
        // Domain to Api Resources
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();



        // API Resources to Domain
            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.contact.ContactName))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.contact.ContactEmail))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.contact.ContactPhone))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })));
        }



    }
}