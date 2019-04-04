using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineBOOM.Models
{
    // Custom table
    public class Pilot
    {
        // Unique ID
        public string Id { get; set; }

        // Parameters
        public int IdentityDocument { get; set; }
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime BornDate { get; set; }
        // Array of flights done by the pilot
        // Number of fligths done by the pilot. Depends on the above.
        // Time flown. Also depends on the above.
        // Array of assigned fligths
        // That crazy array of test which is also an array of scenarios [2D array]
    }
}
