using System;
using System.Collections.Generic;

namespace SE_Assignment
{
    public class WaitList
    {
        // Attributes
        private int waitListID;
        private DateTime waitListStartDate;
        private List<int> userIDs; // List to store user IDs

        // Constructor
        public WaitList(int id)
        {
            waitListID = id;
            waitListStartDate = DateTime.Now;
            userIDs = new List<int>();
        }

        // Operations
        public void AddApplicant(int userID)
        {
            if (!userIDs.Contains(userID))
            {
                userIDs.Add(userID);
                Console.WriteLine($"User with ID {userID} added to waitlist {waitListID}");
            }
            else
            {
                Console.WriteLine($"User with ID {userID} is already in waitlist {waitListID}");
            }
        }

        public void RemoveApplicant(int userID)
        {
            if (userIDs.Contains(userID))
            {
                userIDs.Remove(userID);
                Console.WriteLine($"User with ID {userID} removed from waitlist {waitListID}");
            }
            else
            {
                Console.WriteLine($"User with ID {userID} is not in waitlist {waitListID}");
            }
        }
    }
}
