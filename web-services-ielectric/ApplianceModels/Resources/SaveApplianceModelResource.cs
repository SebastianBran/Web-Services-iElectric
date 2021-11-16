using System.ComponentModel.DataAnnotations;

namespace web_services_ielectric.Resources
{
    public class SaveApplianceModelResource
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string ImgPath { get; set; }
        [Required]
        public string PurchaseDate { get; set; }
        [Required]
        public long ApplianceBrandId { get; set; }
        [Required]
        public long ClientId { get; set; }
    }
}