using System.Collections.Generic;

namespace Vehifleet.Data.Dtos
{
    public class EmployeeLoginDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string UserName { get; set; }

        public string Jwt { get; set; }
    }
}