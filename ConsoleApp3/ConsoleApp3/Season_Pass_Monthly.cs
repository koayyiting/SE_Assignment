using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Season_Pass_Monthly : ParkingChargeStrategy
    {
        public double calculateCharge(ParkingRecord record, double vehicleTypeRates)
        {
            Console.WriteLine("Monthly Season Pass can exit wihtout payment.");
            return 0.0;
        }
    }
}
