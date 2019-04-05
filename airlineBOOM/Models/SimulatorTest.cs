using airlineBOOM.Models.FlightSettingVariables;

namespace airlineBOOM.Models
{
    // Custom table
    public class SimulatorTest
    {
        // Unique ID
        public string Id { get; set; }

        // The pilot responsible for this test
        public Pilot Pilot { get; set; }

        // Total score in the simulation of the pilot
        public double PilotTotalSimulationScore { get; set; }
        
        // Pilot scores in each variable
        public Visibility PilotVisibilityScore { get; set; }
        public Meteorology PilotMeteorologyScore { get; set; }
        public Setoff PilotSetoffScore { get; set; }

        // FlightSetting of the simulation
        public FlightSetting SimulationSetting { get; set; }
    }
}
