using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class PerMinuteCharge : ParkingChargeStrategy
    {

        public double calculateCharge(ParkingRecord record, double vehicleTypeRates)
        {
            if (record.SeasonPassType != -1)
            {
                throw new InvalidOperationException("Invalid Season Pass type for PerMin Strategy");
            }
            // calculation of charge
            TimeSpan duration = record.ExitTime - record.EntryTime;
            int minutes = (int)Math.Ceiling(duration.TotalMinutes);

            double charge = minutes * vehicleTypeRates;
            return charge;
        }
    }
}
