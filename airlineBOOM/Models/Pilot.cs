using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airlineBOOM.Models
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
        // Make a request to the databse to know which flights have done the pilot
        // Count the above request
        // Sum the hours on the above | I can also create a varible. I'll probably reconsider.
        // Make a request to the database to know which flights that havent flown have this pilot
        // Make a request to the database to know which simulation test are asigned to this pilot
    }
}
