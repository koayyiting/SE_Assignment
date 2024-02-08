using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Season_Pass_Monthly : ParkingChargeStrategy
    {
        public double calculateCharge(ParkingRecord record, double vehicleTypeRates)
        {
            if (record.SeasonPassType != 0)
            {
                throw new InvalidOperationException("Invalid Season Pass type for Monthly Strategy");
            }
            return 0.0;
        }
    }
}
