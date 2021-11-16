using System.Collections.Generic;

namespace web_services_ielectric.Domain.Models
{
    public class ApplianceBrand
    {
        // Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public List<ApplianceModel> ApplianceModels { get; set; }
    }
}