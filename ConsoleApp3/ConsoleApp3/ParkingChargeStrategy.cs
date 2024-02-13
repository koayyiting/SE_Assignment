using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class ParkingChargeStrategy
    {
        // Attributes
        private double vehicleTypeRates;
        private double seasonPassRates;
        private double timeBasedRates;

        // Constructor
        public ParkingChargeStrategy(double vehicleTypeRates, double seasonPassRates, double timeBasedRates)
        {
            this.vehicleTypeRates = vehicleTypeRates;
            this.seasonPassRates = seasonPassRates;
            this.timeBasedRates = timeBasedRates;
        }

        // No association 
        // But aggregration where ParkingChargeStrategy can stand alone 
        // If ParkingChargeStrategy stands alone and does not have a strict ownership relationship with
        // ParkingRecord, you can remove the association from the ParkingChargeStrategy class and use it independently. 


        // Operations
        public double CalculateCharge(double hoursParked)
        {
            // Calculate charge based on rates and the number of hours parked
            double totalCharge = (vehicleTypeRates + seasonPassRates) + timeBasedRates * hoursParked;

            // Additional logic for calculation

            return totalCharge;
        }

        public void UpdateVehicleTypeRates(double rate)
        {
            vehicleTypeRates = rate;
        }

        public void UpdateSeasonPassRates(double rate)
        {
            seasonPassRates = rate;
        }

        public void UpdateTimeBasedRates(double rate)
        {
            timeBasedRates = rate;
        }

        // ToString
        // Get details of the parking charge strategy
        public string GetChargeDetails()
        {
            return $"Vehicle Type Rates: {vehicleTypeRates}, Season Pass Rates: {seasonPassRates}, Time Based Rates: {timeBasedRates}";
        }
    }
}
