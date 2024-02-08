using System;

namespace SE_Assignment
{
    public class User
    {
        //Attributes
        private string name;
        private string userID;
        private string username;
        private string password;
        private int mobileNumber;
        private DateTime startMonth;
        private DateTime endMonth;
        private string paymentMode = "credit";

        // Association
        private SeasonParkingPass seasonParkingPass;
        private bool inWaitlist;
        private List<User_ParkingRecord> user_parkingRecords;


        // Constructor
        public User(string name, string userID, string username, string password, int mobileNumber, DateTime startMonth, DateTime endMonth)
        {
            this.name = name;
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.mobileNumber = mobileNumber;
            this.startMonth = startMonth;
            this.endMonth = endMonth;
            this.user_parkingRecords = new List<User_ParkingRecord>();
        }

        // Association: One User may have 0 or more User_ParkingRecords
        public List<User_ParkingRecord> User_ParkingRecords
        {
            get { return user_parkingRecords; }
        }

        // Apply for a season parking pass
        public bool ApplyForSeasonParking()
        {
            // Logic to check if application is successful
            // For demonstration, returning a random value
            Random random = new Random();
            return random.Next(2) == 0; // 50% chance of success
        }

        // Check availability of monthly season pass
        public bool CheckMonthlySeasonPassAvailability()
        {
            // Logic to check availability
            // For demonstration, returning a random value
            Random random = new Random();
            return random.Next(2) == 0; // 50% chance of availability
        }

        // Apply for the waiting list
        public void ApplyWaitingList()
        {
            inWaitlist = true;
        }

        // Get season parking status
        public string GetSeasonParkingStatus()
        {
            if (seasonParkingPass != null)
            {
                return "Season parking pass active";
            }
            else if (inWaitlist)
            {
                return "In waiting list for season parking pass";
            }
            else
            {
                return "No season parking pass applied";
            }
        }

        // Terminate season parking
        public void TerminateSeasonParking()
        {
            seasonParkingPass = null;
            inWaitlist = false;
        }

        // Association: One User may have a SeasonParkingPass
        public SeasonParkingPass SeasonParkingPass
        {
            get { return seasonParkingPass; }
            set { seasonParkingPass = value; }
        }

    }
}
