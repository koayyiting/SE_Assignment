using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ParkingCharge
    {
        // Attributes
        protected ParkingChargeStrategy parkingChargeStrategy;
        private double vehicleTypeRates;

        // Constructor
        public ParkingCharge(ParkingChargeStrategy parkingChargeStrategy, double vehicleTypeRates)
        {
            this.parkingChargeStrategy = parkingChargeStrategy;
            this.vehicleTypeRates = vehicleTypeRates;
        }

        // No association 
        // But aggregration where ParkingChargeStrategy can stand alone 
        // If ParkingChargeStrategy stands alone and does not have a strict ownership relationship with
        // ParkingRecord, you can remove the association from the ParkingChargeStrategy class and use it independently. 


        // Operations
        public double calculateCharge(ParkingRecord record)
        {
            return parkingChargeStrategy.calculateCharge(record, vehicleTypeRates);
        }
    }
}
