using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Season_Pass_Daily : ParkingChargeStrategy
    {
        private double limit;
        public double Limit { get; set; }

        public Season_Pass_Daily(double l)
        {
            Limit = l;
        }
        public double calculateCharge(ParkingRecord record, double vehicleTypeRates)
        {
            // calculation of charge
            TimeSpan duration = record.ExitDateTime - record.EntryDateTime;
            int minutes = (int)Math.Ceiling(duration.TotalMinutes);

            double charge = minutes * vehicleTypeRates;
            Console.WriteLine($"Parking charge: ${vehicleTypeRates} * {minutes} minutes = ${charge}");
            Console.WriteLine($"Limit: ${Limit}");
            return Math.Min(charge, Limit);
        }
    }
}