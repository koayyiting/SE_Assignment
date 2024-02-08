using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
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
            if (record.SeasonPassType != 1)
            {
                throw new InvalidOperationException("Invalid Season Pass type for Daily Strategy");
            }
            // calculation of charge
            TimeSpan duration = record.ExitTime - record.EntryTime;
            int minutes = (int)Math.Ceiling(duration.TotalMinutes);

            double charge = minutes * vehicleTypeRates;
            return Math.Min(charge, Limit);
        }
    }
}
