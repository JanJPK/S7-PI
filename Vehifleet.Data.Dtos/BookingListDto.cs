using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehifleet.Data.Dtos
{
    public class BookingListDto
    {
        public int Id { get; set; }

        public string Vehicle { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
