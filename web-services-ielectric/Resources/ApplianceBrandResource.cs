using System.Collections.Generic;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Resources
{
    public class ApplianceBrandResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
    }
}