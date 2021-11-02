using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Resources;

namespace web_services_ielectric.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SaveClientResource, Client>();
            CreateMap<SaveTechnicianResource, Technician>();
            CreateMap<SaveApplianceModelResource, ApplianceModel>();
            CreateMap<SaveAnnouncementResource, Announcement>()
                .ForMember(target => target.TypeOfAnnouncement,
                            opt => opt.MapFrom(source => (ETypeOfAnnouncement)source.TypeOfAnnouncement));
        }
    }
}
