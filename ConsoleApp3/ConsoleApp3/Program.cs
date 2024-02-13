using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, object>> applicants = new List<Dictionary<string, object>>();

            while (true)
            {
                int option;

                displayMenu();
                Console.Write("Enter your option: ");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    ManageParkingApplications(applicants);
                }
                else if (option == 2)
                {
                    Apply();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Renew Season Pass");
                }
                else if (option == 4)
                {
                    Console.WriteLine("Transfer Season Pass");
                }
                else if (option == 5)
                {
                    Console.WriteLine("Terminate Season Pass");
                }
                else if (option == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input");
                }
            }
        }

        static void Apply()
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

        static void ManageParkingApplications(List<Dictionary<string, object>> applicants)
        {
            Console.WriteLine("Administrator Parking Management System");

            // Sample data for simulation
            applicants.Add(new Dictionary<string, object>()
            {
                {"Name", "John Doe"},
                {"Student/Staff ID", "S12345"},
                {"Username", "johndoe"},
                {"Password", "password123"},
                {"Mobile number", 1234567890},
                {"Start month", new DateTime(2024, 2, 1)},
                {"End month", new DateTime(2024, 3, 1)},
                {"Payment mode", "credit"},
                {"License plate number", "ABC123"},
                {"IU number", "IU456"},
                {"Vehicle Type", "Car"}
            });

            applicants.Add(new Dictionary<string, object>()
            {
                {"Name", "Guo Jun"},
                {"Student/Staff ID", "S10227742"},
                {"Username", "Guo Jun"},
                {"Password", "password123"},
                {"Mobile number", 1234567890},
                {"Start month", new DateTime(2024, 2, 1)},
                {"End month", new DateTime(2024, 3, 1)},
                {"Payment mode", "credit"},
                {"License plate number", "SPF123"},
                {"IU number", "IU456"},
                {"Vehicle Type", "Car"}
            });

            // Display list of applications
            Console.WriteLine("List of Applications:");
            for (int i = 0; i < applicants.Count; i++)
            {
                Console.WriteLine($"Application {i + 1}:");
                foreach (var kvp in applicants[i])
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
                Console.WriteLine();
            }

            // Prompt to choose an application
            Console.Write("Choose an application (enter application number): ");
            int appIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            // Admin approve the application
            Console.WriteLine("Application approved.");

            // Generate a unique season parking pass number
            string uniquePassNumber = GenerateUniquePassNumber();
            Console.WriteLine($"Unique Season Parking Pass Number: {uniquePassNumber}");

            // Update pass status to "valid" for the applied period
            // (Not implemented in this simplified version)

            Console.WriteLine("Use case end.");
        }

        static void SubmitApplication(string passType, string name, string studentOrStaffID, string username, string password, int mobileNumber, DateTime startMonth, DateTime endMonth, string paymentMode, string licensePlateNumber, string iuNumber, string vehicleType)
        {
            Console.WriteLine("\nSubmitting Application...");
            // Here you would typically submit the application details to a database or API

            // Additional processing can be done here, such as sending confirmation emails or messages
        }

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

        static string GenerateUniquePassNumber()
        {
            // This is a simplified method to generate a unique pass number
            // You can replace this with your own logic to generate unique numbers
            return Guid.NewGuid().ToString();
        }

        public static void displayMenu()
        {
            Console.WriteLine("\n---------------- M E N U --------------------");
            Console.WriteLine("[1] Process Season Pass");
            Console.WriteLine("[2] Apply Season Pass");
            Console.WriteLine("[3] Renew Season Pass");
            Console.WriteLine("[4] Transfer Season Pass");
            Console.WriteLine("[5] Terminate Season Pass");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
