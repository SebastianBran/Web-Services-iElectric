﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class ClientResource : PersonResource
    {
        public List<UserPlanResource> UserPlans { get; set; }
    }
}
