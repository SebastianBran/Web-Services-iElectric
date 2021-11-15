using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace web_services_ielectric.Security.Domain.Entities
{
    public class User
    {
        public long Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        [JsonIgnore]
        public string HashPassword { get; set; }
    }
}
