using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class Person
    {
        // Properties
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public long CellphoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relationships
        public IList<Appointment> Appointment { get; set; } = new List<Appointment>(); // -- Relación de uno a muchos
    }
}
