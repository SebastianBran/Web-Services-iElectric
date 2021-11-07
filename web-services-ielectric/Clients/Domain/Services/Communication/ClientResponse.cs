using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;

namespace web_services_ielectric.Domain.Services.Communication
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(string message) : base(message) { }
        public ClientResponse(Client client) : base(client) { }
    }
}
