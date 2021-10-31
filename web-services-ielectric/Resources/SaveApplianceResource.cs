using System.ComponentModel.DataAnnotations;

namespace web_services_ielectric.Resources
{
    public class SaveApplianceResource
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long ApplianceModelId { get; set; }
        [Required]
        public long ClientId { get; set; }
        [Required]
        public int PurchaseDate { get; set; }
    }
}