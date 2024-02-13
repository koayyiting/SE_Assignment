using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class User_ParkingRecord
    {
        private User user;
        private ParkingRecord parkingRecord;
        private DateTime startTime;
        private DateTime endTime;

        // Constructor
        public User_ParkingRecord(User user, ParkingRecord parkingRecord, DateTime startTime, DateTime endTime)
        {
            this.user = user;
            this.parkingRecord = parkingRecord;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        // Properties
        public User User
        {
            get { return user; }
        }

        public ParkingRecord ParkingRecord
        {
            get { return parkingRecord; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
