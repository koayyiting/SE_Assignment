using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface ParkingChargeStrategy
    {
        double calculateCharge(ParkingRecord record, double vehicleTypeRates);
    }
}
