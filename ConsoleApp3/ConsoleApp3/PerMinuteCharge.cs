using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class PerMinuteCharge : ParkingChargeStrategy
    {
        public double calculateCharge(ParkingRecord record, double vehicleTypeRates)
        {
            // calculation of charge
            TimeSpan duration = record.ExitDateTime - record.EntryDateTime;
            int minutes = (int)Math.Ceiling(duration.TotalMinutes);

            double charge = minutes * vehicleTypeRates;
            // Display the breakdown of the calculation
            Console.WriteLine($"Parking charge: ${vehicleTypeRates} * {minutes} minutes = ${charge}");
            return charge;
        }
    }
}