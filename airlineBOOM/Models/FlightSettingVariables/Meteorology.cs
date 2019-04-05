using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airlineBOOM.Models.FlightSettingVariables
{
    // Custom table
    public class Meteorology
    {
        // Unique ID
        public string Id { get; set; }

        // Parameters
        public double Score { get; set; }
        public string Name { get; set; }
    }
}
