using System;

namespace SE_Assignment
{
    public class CarPark
    {
        private int carParkNumber;
        private string location;
        private string description;
        private List<ParkingLot> parkingLots;
        private List<ParkingRecord> parkingRecords;

        // Constructor (creation of a CarPark) 
        public CarPark(int carParkNumber, string location, string description)
        {
            this.carParkNumber = carParkNumber;
            this.location = location;
            this.description = description;

            //Instantiate Empty ParkingLots & ParkingRecords
            parkingLots = new List<ParkingLot>();
            parkingRecords = new List<ParkingRecord>();
        }

        // Getters and Setters
        public int CarParkNumber
        {
            get { return carParkNumber; }
            set { carParkNumber = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Association with ParkingLot
        public void AddParkingLot(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        // Association with ParkingRecord
        public void AddParkingRecord(ParkingRecord parkingRecord)
        {
            parkingRecords.Add(parkingRecord);
        }

        public string GetCarParkInfo()
        {
            return $"Car Park Number: {carParkNumber}\nLocation: {location}\nDescription: {description}";
        }


    }
}
