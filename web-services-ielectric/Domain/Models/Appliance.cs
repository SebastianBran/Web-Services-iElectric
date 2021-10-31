
namespace web_services_ielectric.Domain.Models
{
    public class Appliance
    {
        //Properties
        public long Id { get; set; }
        public long ApplianceModelId { get; set; }
        public long ClientId { get; set; }
        public int PurchaseDate { get; set; }
    }
}