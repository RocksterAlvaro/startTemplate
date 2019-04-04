using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineBOOM.Models
{
    public class Flight
    {
        // Unique ID
        public string Id { get; set; }

        // Parameters
        public int Hours { get; set; }
        public DateTime Date { get; set; }
        // Origin city
        // Destination city
        public string AirplaneState { get; set; } // TODO
        public int TicketsSold { get; set; }
        // Metereology
        // Visibility
        // setoff
        public Pilot Pilot { get; set; }
        public Pilot CoPilot { get; set; }
        public Pilot Auxiliary1 { get; set; }
        public Pilot Auxiliary2 { get; set; }
        public Pilot Auxiliary3 { get; set; }
    }
}
