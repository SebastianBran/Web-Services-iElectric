﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Models
{
    public class Appliance
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long ApplianceModelId { get; set; }
        public string PurchaseDate { get; set; }
    }
}
