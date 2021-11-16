using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class ApplianceModelResponse:BaseResponse<ApplianceModel>
    {
        public ApplianceModelResponse(string message) : base(message) { }
        public ApplianceModelResponse(ApplianceModel applianceModel) : base(applianceModel) { }
    }
}