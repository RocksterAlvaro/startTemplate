using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airlineBOOM.Models
{
    // Custom table
    public class City
    {
        // Unique ID
        public string Id { get; set; }

        // Parameters
        public string name { get; set; }
        public string airportCondition { get; set; }
        public string terrainCondition { get; set; }
    }
}
