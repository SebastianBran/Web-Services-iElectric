using AutoMapper;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Extensions;

namespace web_services_ielectric.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Technician, TechnicianResource>();
            CreateMap<Announcement, AnnouncementResource>()
                .ForMember(target => target.TypeOfAnnouncement,
                            opt => opt.MapFrom(source => source.TypeOfAnnouncement.ToDescriptionString()));
            CreateMap<Plan, PlanResource>();
        }
    }
}
