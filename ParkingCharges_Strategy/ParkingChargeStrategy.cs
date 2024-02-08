using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public interface ParkingChargeStrategy
    {
        double calculateCharge(ParkingRecord record, double vehicleTypeRates);
    }
}
