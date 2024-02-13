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

        // Attributes 
        public string UniquePassNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PassStatus Status { get; set; }
        public PassType Type { get; set; }
        public User AssociatedUser { get; set; }
        public Vehicle AssociatedVehicle { get; set; }

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
