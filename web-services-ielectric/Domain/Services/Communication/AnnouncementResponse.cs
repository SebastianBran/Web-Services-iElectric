using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class AnnouncementResponse : BaseResponse<Announcement>
    {
        public AnnouncementResponse(string message) : base(message) { }
        public AnnouncementResponse(Announcement announcement) : base(announcement) { }
    }
}
