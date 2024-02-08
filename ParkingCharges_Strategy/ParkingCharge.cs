using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class ParkingCharge
    {
        protected ParkingChargeStrategy pcs;
        private double vehicleTypeRates;

        //constructor
        public ParkingCharge(ParkingChargeStrategy pcs, double vehicleTypeRates)
        {
            this.pcs = pcs;
            this.vehicleTypeRates = vehicleTypeRates;
        }

        //method
        public double calculateCharge(ParkingRecord record)
        {
            // Calculate charge based on chosen strategy
            return pcs.calculateCharge(record, vehicleTypeRates);
        }
    }
}
