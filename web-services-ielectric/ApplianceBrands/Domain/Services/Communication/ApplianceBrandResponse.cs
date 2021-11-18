using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class ApplianceBrandResponse:BaseResponse<ApplianceBrand>
    {
        public ApplianceBrandResponse(string message) : base(message) { }
        public ApplianceBrandResponse(ApplianceBrand applianceBrand) : base(applianceBrand) { }
    }
}