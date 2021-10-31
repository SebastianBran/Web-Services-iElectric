using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class ApplianceResponse:BaseResponse<Appliance>
    {
        public ApplianceResponse(string message) : base(message) { }
        public ApplianceResponse(Appliance appliance) : base(appliance) { }
    }
}