using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Resources
{
    public class SaveApplianceBrandResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgPath { get; set; }
    }
}