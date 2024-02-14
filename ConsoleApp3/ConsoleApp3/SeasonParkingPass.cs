using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class SeasonParkingPass
    {
        // Temporaily code <-- to be updated
        public enum PassStatus
        {
            Valid,
            Parked,
            Exited,
            Expired,
            Terminated
        }

        public enum PassType
        {
            Monthly,
            Daily
        }

        private string uniquePassNumber;
        private DateTime startMonth;
        private DateTime endMonth;
        private string status;
        private string type;
        private User associatedUser;
        private Vehicle associatedVehicle;
        private double price;

        // Attributes 
        public string UniquePassNumber { get; set; }
        public DateTime StartMonth { get; set; }
        public DateTime EndMonth { get; set; }
        public PassStatus Status { get; set; }
        public PassType Type { get; set; }
        public double Price { get; set; }
        public User AssociatedUser { get; set; }
        public Vehicle AssociatedVehicle { get; set; }

        // State Settings:
        private SPState validState, terminatedState, expiredState, exitedState, parkedState, state;
        public SPState ValidState { get; set; }
        public SPState TerminatedState { get; set; }
        public SPState ExpiredState { get; set; }
        public SPState ExitedState { get; set; }
        public SPState ParkedState { get; set; }
        public SPState State { get; set; }

        public SeasonParkingPass()
        {
            ValidState = new ValidState(this);
            ExpiredState = new ExpiredState(this);
            TerminatedState = new TerminatedState(this);
            ExitedState = new ExitedState(this);
            ParkedState = new ParkedState(this);

            State = ValidState;
        }

        public bool renewPass()
        {
            // Logic to renew pass
            return true; // Return true if renewed successfully, false otherwise
        }


        public void refundPayment(double refundAmt)
        {
            Console.WriteLine("Refunding Remaining Months Payment: $" + refundAmt);
        }
    }
}
