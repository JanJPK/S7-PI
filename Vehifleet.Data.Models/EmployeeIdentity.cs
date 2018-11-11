﻿using Microsoft.AspNetCore.Identity;

namespace Vehifleet.Data.Models
{
    public class EmployeeIdentity : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public virtual Employee Employee { get; set; }
    }
}