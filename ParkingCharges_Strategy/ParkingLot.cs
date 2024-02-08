using System;

namespace SE_Assignment
{
    public class ParkingLot
    {
        // Attributes
        private int lotNumber;
        private string lotType;
        private int lotLength;
        private int lotWidth;

        // Association
        private CarPark carPark; // One ParkingLot belongs to one CarPark

        // Constructor
        public ParkingLot(int lotNumber, string lotType, int lotLength, int lotWidth, CarPark carPark)
        {
            this.lotNumber = lotNumber;
            this.lotType = lotType;
            this.lotLength = lotLength;
            this.lotWidth = lotWidth;
            this.carPark = carPark;
        }

        // Operation: Get lot information
        public string GetLotInfo()
        {
            return $"Lot Number: {lotNumber}\nLot Type: {lotType}\nLot Length: {lotLength}\nLot Width: {lotWidth}";
        }

    }
}
