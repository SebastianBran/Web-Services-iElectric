using System.ComponentModel.DataAnnotations;

namespace web_services_ielectric.Resources
{
    public class SaveApplianceBrandResource
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgPath { get; set; }
    }
}