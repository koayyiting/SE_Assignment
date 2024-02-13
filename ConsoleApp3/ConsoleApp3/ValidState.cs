using System;
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
            if (pass.Status == "terminated" || pass.Status == "expired")
            {
                // System display No Season Pass to terminate. 
                Console.WriteLine("You do not have a Season Pass");

                // End Use Case
                return;
            }

            // System display user’s daily season pass
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

                    if (pass.Type == "daily")
                    {
                        // System display message daily pass to be terminated 
                        Console.WriteLine("Daily Pass to be terminated..");

                    }
                    else if (pass.Type == "monthly")
                    {
                        // System checks for the months left
                        int monthsLeft = ((pass.StartMonth.Year - DateTime.Now.Year) * 12) + pass.EndMonth.Month - DateTime.Now.Month;

                        // System calculates refund amount.
                        double refundAmt = monthsLeft * 50; // I need a monthly season price for this

                        // System refunds amount to ICTP User.
                        refundPayment(refundAmt);

                        // System display message daily pass to be terminated.
                        Console.WriteLine("Daily Pass to be terminated..");
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
                pass.Status = "terminated";
                pass.State = pass.TerminatedState;

                // End Use Case
                return;
            }
        }

        public void Transfer(SeasonParkingPass context, Vehicle v1, Vehicle v2)
        {
            // Implement transfer behavior for valid state
            Console.WriteLine("Cannot transfer a terminated season parking pass.");
        }

        public void Renew(SeasonParkingPass context)
        {
            //Have not implemented Use Case Desc alternate flow

            Console.WriteLine("Enter new end date: ");
            DateTime endMonth = Convert.ToDateTime(Console.ReadLine()); //Not sure how converting will work with the string given

            //Make Payment use case
            Console.WriteLine("Made paymnent?");
            bool paymentMade = Convert.ToBoolean(Console.ReadLine());
            while (!paymentMade)
            {
                if (paymentMade)
                {
                    Console.WriteLine("Payment Made.");
                }
                else
                {
                    Console.WriteLine("Payment Required.");
                }
            }

            pass.EndMonth = endMonth;

            Console.WriteLine("Renew successful!");
        }

        public void refundPayment(double refundAmt)
        {
            Console.WriteLine("Refunding Remaining Months Payment: $" + refundAmt);
        }
    }
}
