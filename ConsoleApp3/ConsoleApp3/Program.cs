using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //"Apply Season Pass" Use Case
            // Step 1: User clicks on “Apply Season Pass” section
            Console.WriteLine("Welcome to the Season Parking Pass Application!");

            // Step 2: System displays "Monthly" and "Daily" Season Parking Passes
            DisplaySeasonPassOptions();

            // Step 3: User selects type of Season Parking Pass
            string passType = SelectPassType();

            // Step 4: System prompts user to enter essential details
            Console.WriteLine("\nPlease enter your essential details:");

            // Step 5: User inputs essential details
            string name = GetValidInput("Name");
            string studentOrStaffID = GetValidInput("Student/Staff ID");
            string username = GetValidInput("Username");
            string password = GetValidInput("Password");
            int mobileNumber = GetValidIntegerInput("Mobile number");
            DateTime startMonth = GetValidDateTimeInput("Start month");
            DateTime endMonth = GetValidDateTimeInput("End month");
            string paymentMode = GetValidInput("Payment mode (credit/debit)");
            string licensePlateNumber = GetValidInput("License plate number");
            string iuNumber = GetValidInput("IU number");
            string vehicleType = GetValidInput("Vehicle Type");

            //Step 7: Verifies specific essential details provided is valid (happens concurrently) 
            //Step 8: Triggers “Make Payment” use case 
            MakePayment();
            Console.WriteLine("\nPayment process completed.");

            // Step 6: User/System submits application
            SubmitApplication(passType, name, studentOrStaffID, username, password, mobileNumber, startMonth, endMonth, paymentMode, licensePlateNumber, iuNumber, vehicleType);

            Console.WriteLine("\nThank you for your submission!");

        }

        // Functions
        static void DisplaySeasonPassOptions()
        {
            Console.WriteLine("Select your desired Season Parking Pass:");
            Console.WriteLine("1. Monthly Pass");
            Console.WriteLine("2. Daily Pass");
            // Additional pass options can be added here
        }

        static string SelectPassType()
        {
            Console.Write("Enter your choice (1) Monthly (2) Daily: ");
            string input = Console.ReadLine();
            return input == "1" ? "Monthly Pass" : "Daily Pass";
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }

        static void SubmitApplication(string passType, string name, string studentOrStaffID, string username, string password, int mobileNumber, DateTime startMonth, DateTime endMonth, string paymentMode, string licensePlateNumber, string iuNumber, string vehicleType)
        {
            Console.WriteLine("\nSubmitting Application...");
            // Here you would typically submit the application details to a database or API

            
            // Create user applying for season parking
            User user = new User(name, studentOrStaffID, username, password, mobileNumber, startMonth, endMonth);

            // Apply for Season Parking by calling User class 
            // Apply for season parking
            if (user.ApplyForSeasonParking() != "Failed" || user.ApplyForSeasonParking() != "Monthly Pass Unavaliable")
            {
                // If application is successful, print the unique pass number
                Console.WriteLine("Season Parking Pass Applied Successfully!");
                Console.WriteLine("Unique Pass Number: " + user.SeasonParkingPass.UniquePassNumber);
            }
            else
            {
                // If application is unsuccessful, print a message
                Console.WriteLine("Failed to apply for Season Parking Pass.");
            }

            Console.WriteLine("Application submitted successfully!");
            // Additional processing can be done here, such as sending confirmation emails or messages
        }

        // Make Payment use case (simple depiction of MakePayment use case, not exhaustive)
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

        // Front-end user input validation 
        static string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine($"Enter {prompt}:");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input)); // Validates for non-empty input
            return input;
        }

        static int GetValidIntegerInput(string prompt)
        {
            int result;
            string input;
            do
            {
                Console.WriteLine($"Enter {prompt}:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out result)); // Validates for integer input
            return result;
        }

        static DateTime GetValidDateTimeInput(string prompt)
        {
            DateTime result;
            string input;
            do
            {
                Console.WriteLine($"Enter {prompt} (YYYY-MM-DD):");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out result)); // Validates for DateTime input
            return result;
        }
    }
}
