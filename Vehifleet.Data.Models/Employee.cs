﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Employee : CostGeneratingEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeIdentity")]
        public string IdentityId { get; set; }

        public virtual EmployeeUser Identity { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Booking> ManagedBookings { get; set; }
    }
}