using AutoMapper;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Extensions;
using web_services_ielectric.Security.Domain.Entities;
using web_services_ielectric.Security.Domain.Services.Communication;

namespace web_services_ielectric.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Administrator, AdministratorResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Technician, TechnicianResource>();
            CreateMap<ApplianceModel, ApplianceModelResource>();
            CreateMap<ApplianceBrand, ApplianceBrandResource>();
            CreateMap<Appliance, ApplianceResource>();
            CreateMap<Announcement, AnnouncementResource>()
                .ForMember(target => target.TypeOfAnnouncement,
                            opt => opt.MapFrom(source => source.TypeOfAnnouncement.ToDescriptionString()));
            CreateMap<Appointment, AppointmentResource>();
            CreateMap<Report, ReportResource>();
            CreateMap<SpareRequest, SpareRequestResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<User, RegisterRequest>();
            CreateMap<User, AuthenticateResponse>();
            CreateMap<User, RegisterResponse>();
        }
    }
}
