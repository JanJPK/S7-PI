using Microsoft.AspNetCore.Identity;

namespace Vehifleet.Data.Models
{
    /// <summary>
    ///     Personal data of an employee.
    /// </summary>
    public class EmployeeIdentity : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public virtual Employee Employee { get; set; }
    }
}