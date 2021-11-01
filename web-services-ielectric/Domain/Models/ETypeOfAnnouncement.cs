using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public enum ETypeOfAnnouncement : byte
    {
        [Description("Informative")]
        Informative = 1,
        [Description("Advertisement")]
        Advertisement = 2,
    }
}
