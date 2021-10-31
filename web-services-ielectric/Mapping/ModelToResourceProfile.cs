using AutoMapper;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Technician, TechnicianResource>();
            CreateMap<Appliance, ApplianceResource>();
        }
    }
}
