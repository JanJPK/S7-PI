using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehifleet.Data.Dtos
{
    public class EmployeeRegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
