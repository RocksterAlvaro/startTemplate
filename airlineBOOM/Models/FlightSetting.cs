using airlineBOOM.Models.FlightSettingVariables;

namespace airlineBOOM.Models
{
    // Custom table
    public class FlightSetting
    {
        // Unique ID
        public string Id { get; set; }

        // FlightSetting difficulty value
        public double TotalScore { get; set; }

        // My classes
        public Visibility FlightSettingVisibility { get; set; }
        public Meteorology FlightSettingMeteorology { get; set; }
        public Setoff FlightSettingSetoff { get; set; }
    }
}
