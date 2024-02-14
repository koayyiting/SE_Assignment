﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ValidState : SPState
    {
        private SeasonParkingPass pass;

        public ValidState(SeasonParkingPass p)
        {
            pass = p;
        }
        


        public void Terminate(SeasonParkingPass pass)
        {
            // System checking for user’s season pass
            Console.WriteLine("Checking for season pass");
            if (pass.Status == SeasonParkingPass.PassStatus.Terminated || pass.Status == SeasonParkingPass.PassStatus.Expired)
            {
                // System display No Season Pass to terminate. 
                Console.WriteLine("You do not have a Season Pass");

                // End Use Case
                return;
            }

            // System display user’s daily season pass
            Console.WriteLine("\nSeason Pass Details:");
            Console.WriteLine("Unique Pass Number: " + pass.UniquePassNumber);
            Console.WriteLine("Start Month: " + pass.StartMonth);
            Console.WriteLine("End Month: " + pass.EndMonth);
            Console.WriteLine("Status: " + pass.Status);
            Console.WriteLine("Type: " + pass.Type);

            // System prompt for termination
            while (true)
            {
                int terminate;
                Console.Write("Proceed to Terminate (1.Yes 2.No): ");
                if (!int.TryParse(Console.ReadLine(), out terminate))
                {
                    // Input is not a valid integer
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue; // Prompt again
                }

                if (terminate == 1)
                {
                    // Terminate the process

                    // System prompts for reason for termination
                    Console.Write("Reason for Termination: ");

                    // User enters termination reason
                    Console.ReadLine();

                    if (pass.Type == SeasonParkingPass.PassType.Daily)
                    {
                        // System display message daily pass to be terminated 
                        Console.WriteLine("Daily Pass to be terminated..");

                    }
                    else if (pass.Type == SeasonParkingPass.PassType.Monthly)
                    {
                        // System checks for the months left
                        int monthsLeft = ((pass.StartMonth.Year - DateTime.Now.Year) * 12) + pass.EndMonth.Month - DateTime.Now.Month;

                        // System calculates refund amount.
                        double refundAmt = monthsLeft * pass.Price; 

                        // System refunds amount to ICTP User.
                        pass.refundPayment(refundAmt);

                        // System display message daily pass to be terminated.
                        Console.WriteLine("Monthly Pass to be terminated..");
                    }
                }
                else if (terminate == 2)
                {
                    // End Use Case
                    return;
                }
                else
                {
                    // Invalid input, prompt again
                    Console.WriteLine("Invalid input. Please enter 1 for Yes or 2 for No.");
                }

                // System updates parking pass status to “terminated”
                pass.Status = SeasonParkingPass.PassStatus.Terminated;
                pass.State = pass.TerminatedState;

                // End Use Case
                return;
            }
        }

        public void Transfer(SeasonParkingPass userPass)
        {
            bool sameType = false;
            Console.Write("license plate number: ");
            string licensePlate = Console.ReadLine();
            Console.Write("IU number: ");
            string IU = Console.ReadLine();
            while (!sameType)
            {
                Console.Write("Vehicle Type: ");
                string vType = Console.ReadLine();
                if (vType == userPass.AssociatedVehicle.VehicleType)
                {
                    Console.WriteLine("Transfer Successful");
                    userPass.AssociatedVehicle.LicensePlateNumber = licensePlate;
                    userPass.AssociatedVehicle.IUNumber = IU;
                    sameType= true;
                }
                else
                {
                    Console.WriteLine("need to be same type");
                }
            }
        }

        public void Renew(SeasonParkingPass userPass)
        {
            //Have not implemented Use Case Desc alternate flow
            DateTime CurrentEndMonth = userPass.EndMonth;
            Console.WriteLine(CurrentEndMonth);

            //Step 3
            Console.WriteLine("Enter new end date: ");
            DateTime newEndMonth = Convert.ToDateTime(Console.ReadLine()); //Not sure how converting will work with the string given

            //Make Payment use case
            MakePayment();

            userPass.EndMonth = newEndMonth;

            Console.WriteLine("Renew successful!");
        }

        //Make Payment Use Case
        static void MakePayment()
        {
            string input;
            do
            {
                Console.WriteLine("\nDo you want to make payment? (yes/no):");
                input = Console.ReadLine().ToLower();
            } while (input != "yes" && input != "no");

            if (input == "yes")
            {
                Console.WriteLine("Payment successful!");
                // Additional payment processing logic can be added here
            }
            else
            {
                Console.WriteLine("Payment cancelled.");
            }
        }

    }
}
