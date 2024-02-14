using System;

namespace ConsoleApp3
{
    public class Vehicle
    {
        // Attributes
        private string licensePlateNumber;
        private string iUNumber;
        private string vehicleType;

        public string LicensePlateNumber { get; set; }
        public string IUNumber { get; set; }
        public string VehicleType { get; set; }


        //Association
        private SeasonParkingPass parkingPass;

        // Constructor
        public Vehicle(string licensePlateNumber, string IUNumber, string vehicleType)
        {
            this.LicensePlateNumber = licensePlateNumber;
            this.IUNumber = IUNumber;
            this.VehicleType = vehicleType;
        }

        // Associate a SeasonParkingPass with this Vehicle
        public void AssignParkingPass(SeasonParkingPass pass)
        {
            this.parkingPass = pass;
        }

        // Get vehicle information
        public string GetVehicleInfo()
        {
            return $"License Plate Number: {LicensePlateNumber}\nIU Number: {IUNumber}\nVehicle Type: {VehicleType}";
        }

        // Register vehicle in the system
        public bool RegisterVehicleInSystem()
        {
            // Logic to register vehicle in the system
            // For example, database operations, etc.
            // Return true if registration is successful, false otherwise
            return true; // Placeholder, replace with actual logic
        }
    }
}
