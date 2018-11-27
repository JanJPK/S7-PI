using System;

namespace Vehifleet.Data.Dtos.BaseDtos
{
    public abstract class AuditableDto
    {
        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}