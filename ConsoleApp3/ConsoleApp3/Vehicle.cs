using System;

namespace ConsoleApp3
{
    public class Vehicle
    {
        // Attributes
        private string licensePlateNumber;
        private string IUNumber;
        private string vehicleType;

        //Association
        private SeasonParkingPass parkingPass;

        // Constructor
        public Vehicle(string licensePlateNumber, string IUNumber, string vehicleType)
        {
            this.licensePlateNumber = licensePlateNumber;
            this.IUNumber = IUNumber;
            this.vehicleType = vehicleType;
        }

        // Associate a SeasonParkingPass with this Vehicle
        public void AssignParkingPass(SeasonParkingPass pass)
        {
            this.parkingPass = pass;
        }

        // Get vehicle information
        public string GetVehicleInfo()
        {
            return $"License Plate Number: {licensePlateNumber}\nIU Number: {IUNumber}\nVehicle Type: {vehicleType}";
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
