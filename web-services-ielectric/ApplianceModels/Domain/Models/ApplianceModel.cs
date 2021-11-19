﻿
using System.Collections.Generic;

namespace web_services_ielectric.Domain.Models
{
    public class ApplianceModel
    {
        //Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string ImgPath { get; set; }
        
        public long ApplianceBrandId { get; set; }
        public ApplianceBrand ApplianceBrand { get; set; }
    }
}