using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class User
    {
        //Attributes
        public string Name { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }
        public DateTime StartMonth { get; set; }
        public DateTime EndMonth { get; set; }
        public string PaymentMode { get; set; }
        public string UserType { get; set; }

        // Association
        private SeasonParkingPass seasonParkingPass;
        private bool inWaitlist;
        private List<User_ParkingRecord> user_parkingRecords;


        // Constructor
        public User(string name, string userID, string username, string password, int mobileNumber, DateTime startMonth, DateTime endMonth, string userType)
        {
            this.Name = name;
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.MobileNumber = mobileNumber;
            this.StartMonth = startMonth;
            this.EndMonth = endMonth;
            this.UserType = userType;
            this.user_parkingRecords = new List<User_ParkingRecord>();
        }

        // Association: One User may have 0 or more User_ParkingRecords
        public List<User_ParkingRecord> User_ParkingRecords
        {
            get { return user_parkingRecords; }
        }

        // Apply for a season parking pass
        public string ApplyForSeasonParking()
        {
            // Check if the user already has an active season parking pass
            if (seasonParkingPass != null)
            {
                Console.WriteLine("You already have an active season parking pass.");
                return "Failed";
            }

            // Check if monthly pass is available
            if (!CheckMonthlySeasonPassAvailability())
            {
                Console.WriteLine("Monthly season parking pass is not available.");
                return "Monthly Pass Unavaliable";
            }

            // Generate a unique pass number
            string uniquePassNumber = "PASS-" + Guid.NewGuid().ToString().Substring(0, 6); // Generate a unique 6-character pass number

            // Create a new season parking pass for the user
            SeasonParkingPass newSeasonParkingPass = new SeasonParkingPass
            {
                UniquePassNumber = uniquePassNumber,
                StartMonth = StartMonth,
                EndMonth = EndMonth,
                Status = SeasonParkingPass.PassStatus.Valid,
                Type = SeasonParkingPass.PassType.Monthly,
                AssociatedUser = this
                // You may set other attributes of the season parking pass here
            };

            // Set the season parking pass for the user
            seasonParkingPass = newSeasonParkingPass;

            Console.WriteLine("Season parking pass applied successfully. Pass Number: " + uniquePassNumber);
            return uniquePassNumber;
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

        public SeasonParkingPass GetSeasonParkingPass()
        {
            // Generate a unique pass number
            string uniquePassNumber = "PASS-" + Guid.NewGuid().ToString().Substring(0, 6); // Generate a unique 6-character pass number

            // Create a new season parking pass for the user
            SeasonParkingPass userSeasonParkingPass = new SeasonParkingPass
            {
                UniquePassNumber = uniquePassNumber,
                StartMonth = StartMonth,
                EndMonth = EndMonth,
                Status = SeasonParkingPass.PassStatus.Valid,
                Type = SeasonParkingPass.PassType.Monthly,
                AssociatedUser = this
                // You may set other attributes of the season parking pass here
            };
            return userSeasonParkingPass;
        }

    }
}
