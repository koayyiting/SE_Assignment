using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class SeasonParkingPass
    {
        // Temporaily code <-- to be updated
        //public enum PassStatus
        //{
        //    Valid,
        //    Parked,
        //    Exited,
        //    Expired,
        //    Terminated
        //}

        //public enum PassType
        //{
        //    Monthly,
        //    Daily
        //}

        private string uniquePassNumber;
        private DateTime startMonth;
        private DateTime endMonth;
        private string status;
        private string type;
        private User associatedUser;
        private Vehicle associatedVehicle;

        // Attributes 
        public string UniquePassNumber { get; set; }
        public DateTime StartMonth { get; set; }
        public DateTime EndMonth { get; set; }
        public string Status { get; set; }
        //public PassStatus Status { get; set; }
        //public PassType Type { get; set; }
        public string Type { get; set; }
        public User AssociatedUser { get; set; }
        public Vehicle AssociatedVehicle { get; set; }

        // State Settings:
        private SPState validState, terminatedState, expiredState, state;
        public SPState ValidState { get; set; }
        public SPState TerminatedState { get; set; }
        public SPState ExpiredState { get; set; }
        public SPState State { get; set; }

        public SeasonParkingPass(string upn, DateTime sm, DateTime em, string s, string t, User u, Vehicle v)
        {
            UniquePassNumber = upn;
            StartMonth = sm;
            EndMonth = em;
            Status = s;
            Type = t;
            AssociatedUser = u;
            AssociatedVehicle = v;

            ValidState = new ValidState(this);
            ExpiredState = new ExpiredState(this);
            TerminatedState = new TerminatedState(this);

            State = ValidState;
        }

        public bool RenewPass()
        {
            // Logic to renew pass
            return true; // Return true if renewed successfully, false otherwise
        }

        public bool TransferPass(User newOwner)
        {
            // Logic to transfer pass to a new user
            return true; // Return true if transferred successfully, false otherwise
        }

        public void TerminatePass()
        {
            // Logic to terminate pass
        }

        public void RefundPayment()
        {
            // Logic to refund payment
        }
    }
}
