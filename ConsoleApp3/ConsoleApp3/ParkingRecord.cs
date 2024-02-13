using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class ParkingRecord
    {
        // Attributes
        private string uniqueParkingNumber;
        private DateTime entryDateTime;
        private DateTime exitDateTime;
        private string vehicleType;
        private int seasonPassType = -1; //  "-1, 0, 1", representing "No pass, Daily Pass, Monthly Pass"
        private double amountCharged;

        // Associations
        private CarPark carPark; // One ParkingRecord belongs to one CarPark
        private ParkingChargeStrategy parkingChargeStrategy; // One ParkingRecord has one ParkingChargeStrategy
        private MonthlyFinancialReport monthlyFinancialReport; // One ParkingRecord has one MonthlyFinancialReport

        // Association: One ParkingRecord can have 0 or more User_ParkingRecord
        private List<User_ParkingRecord> user_ParkingRecords;

        // Constructor
        public ParkingRecord(string uniqueParkingNumber, DateTime entryDateTime, DateTime exitDateTime, string vehicleType, int seasonPassType)
        {
            this.uniqueParkingNumber = uniqueParkingNumber;
            this.entryDateTime = entryDateTime;
            this.exitDateTime = exitDateTime;
            this.vehicleType = vehicleType;
            this.seasonPassType = seasonPassType;
            this.user_ParkingRecords = new List<User_ParkingRecord>();
        }

        // Association: One ParkingRecord can have 0 or more User_ParkingRecord
        public List<User_ParkingRecord> User_ParkingRecords
        {
            get { return user_ParkingRecords; }
        }

        // Operation to capture parking record and return the amount charged
        public double CaptureParkingRecord(DateTime entryDateTime, DateTime exitDateTime, string vehicleType, int seasonPassType)
        {
            // Logic to calculate amount charged based on parking duration, vehicle type, etc.
            // This could involve using the ParkingChargeStrategy associated with this ParkingRecord.
            // For now, let's assume a basic calculation.
            double parkingCharge = CalculateParkingCharge(entryDateTime, exitDateTime);
            this.amountCharged = parkingCharge;
            return parkingCharge;
        }

        // Method to calculate the parking charge
        private double CalculateParkingCharge(DateTime entryDateTime, DateTime exitDateTime)
        {
            // Check if ParkingChargeStrategy is set
            if (parkingChargeStrategy != null)
            {
                // Calculate the number of hours parked
                double hoursParked = (exitDateTime - entryDateTime).TotalHours;

                // Call CalculateCharge method from ParkingChargeStrategy with hoursParked parameter
                return parkingChargeStrategy.CalculateCharge(hoursParked);
            }
            else
            {
                // If ParkingChargeStrategy is not set, return 0 as default charge
                return 0;
            }
        }

        // Operation to purge the parking record
        public void PurgeRecord()
        {
            // Logic to remove the parking record from the system
            // This could involve updating the MonthlyFinancialReport associated with this ParkingRecord.
            // For now, let's just set the attributes to default values.
            this.uniqueParkingNumber = null;
            this.entryDateTime = default(DateTime);
            this.exitDateTime = default(DateTime);
            this.vehicleType = null;
            this.seasonPassType = -1;
            this.amountCharged = 0;
        }

    }
}