using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, object>> applicants = new List<Dictionary<string, object>>();

            DateTime date1 = new DateTime(2012, 12, 25, 10, 30, 50);
            DateTime date2 = new DateTime(2012, 12, 25, 11, 45, 10);
            User student = new User("Terrence", "S10223166H", "Talan", "03012004", 98710557, date1, date2, "Student");
            SeasonParkingPass userPass = student.GetSeasonParkingPass();
            Vehicle vehicle = new Vehicle("SCA123B", "12345678", "Car");

            User user_monthly = new User("Yi Ting", "S10221765G", "password", "password", 90000000, new DateTime(2024, 2, 1), new DateTime(2024, 5, 1), "Student");
            SeasonParkingPass userSeasonPass_monthly = user_monthly.GetSeasonParkingPass();
            userSeasonPass_monthly.Price = 50;

            User user_daily = new User("Yi Ting", "S10221765G", "password", "password", 90000000, new DateTime(2024, 2, 1), new DateTime(2024, 5, 1), "Student");
            SeasonParkingPass userSeasonPass_daily = user_daily.GetSeasonParkingPass();
            userSeasonPass_daily.Type = SeasonParkingPass.PassType.Daily;

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
                    userPass.State.Renew(userPass);
                }
                else if (option == 4)
                {
                    userPass.AssociatedVehicle = vehicle;

                    userPass.State.Transfer(userPass);
                }
                else if (option == 5)
                {
                    Terminate(userSeasonPass_monthly, userSeasonPass_daily);
                }
                else if (option == 6)
                {
                    // sample records - [No pass: -1, Daily Pass: 0, Monthly Pass: 1]
                    while (true)
                    {
                        displayMenu_Charge();
                        int chargeOption;

                        Console.Write("Enter your option: ");
                        chargeOption = Convert.ToInt32(Console.ReadLine());

                        if (chargeOption == 1)
                        {
                            ParkingRecord record = new ParkingRecord("12345678", new DateTime(2024, 2, 13, 7, 30, 0), new DateTime(2024, 2, 13, 17, 30, 0), "Car", 1, 0);
                            parkingCharge(record);
                        }
                        else if (chargeOption == 2)
                        {
                            ParkingRecord record = new ParkingRecord("12345678", new DateTime(2024, 2, 13, 9, 30, 0), new DateTime(2024, 2, 13, 20, 30, 0), "Motorbike", 0, 0);
                            parkingCharge(record);
                        }
                        else if (chargeOption == 3)
                        {
                            ParkingRecord record = new ParkingRecord("12345678", new DateTime(2024, 2, 13, 15, 30, 0), new DateTime(2024, 2, 13, 21, 30, 0), "Truck", -1, 0);
                            parkingCharge(record);
                        }
                        else if (chargeOption == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input.");
                        }
                  
                    }

                }
                else if (option == 7)
                {
                    // sample data
                    date1 = new DateTime(2012, 12, 25, 10, 30, 50);
                    date2 = new DateTime(2012, 12, 25, 11, 45, 10);
                    ParkingRecord pr1 = new ParkingRecord("1234", date1, date2, "monster truck", -1, 30);
                    ParkingRecord pr2 = new ParkingRecord("1235", date1, date2, "monster truck", -1, 50);
                    ParkingRecord pr3 = new ParkingRecord("1236", date1, date2, "monster truck", -1, 60);
                    ParkingRecord pr4 = new ParkingRecord("1237", date1, date2, "monster truck", -1, 20);
                    ParkingRecord pr5 = new ParkingRecord("1238", date1, date2, "monster truck", -1, 52);
                    User staff = new User("Terrence", "S10223166H", "Talan", "03012004", 98710557, date1, date2, "Staff");
                    student = new User("Terrence", "S10223166H", "Talan", "03012004", 98710557, date1, date2, "Student");
                    User_ParkingRecord upr1 = new User_ParkingRecord(staff, pr1, date1, date2);
                    User_ParkingRecord upr2 = new User_ParkingRecord(student, pr2, date1, date2);
                    User_ParkingRecord upr3 = new User_ParkingRecord(staff, pr3, date1, date2);
                    User_ParkingRecord upr4 = new User_ParkingRecord(student, pr4, date1, date2);
                    User_ParkingRecord upr5 = new User_ParkingRecord(staff, pr5, date1, date2);
                    List<User_ParkingRecord> uprList = new List<User_ParkingRecord>();
                    List<ParkingRecord> prList = new List<ParkingRecord>();
                    // adding all user parking record to uprList
                    uprList.Add(upr1);
                    uprList.Add(upr2);
                    uprList.Add(upr3);
                    uprList.Add(upr4);
                    uprList.Add(upr5);
                    ConcreteAggregate ca = new ConcreteAggregate(uprList);

                    // call iterator function
                    GenerateReport(ca, uprList);
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

        // Option 5: Terminate Season Pass
        public static void displayMenu_Terminate()
        {
            Console.WriteLine("\n------------ Terminate Pass Type ------------");
            Console.WriteLine("[1] Monthly Season Pass");
            Console.WriteLine("[2] Daily Season Pass");
            Console.WriteLine("[0] Back");
            Console.WriteLine("---------------------------------------------");
        }

        public static void Terminate(SeasonParkingPass userSeasonPass_monthly, SeasonParkingPass userSeasonPass_daily)
        {
            while (true)
            {
                int option;

                displayMenu_Terminate();
                Console.Write("Enter your option: ");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    userSeasonPass_monthly.State.Terminate(userSeasonPass_monthly);
                }
                else if (option == 2)
                {
                    userSeasonPass_daily.State.Terminate(userSeasonPass_daily);
                }
                else if (option == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }

        // Option 6: Strategy Design Pattern - Parking Charges
        public static void displayMenu_Charge()
        {
            Console.WriteLine("\n---------- Strategy Design Pattern ----------");
            Console.WriteLine("[1] Monthly Season Pass Charge");
            Console.WriteLine("[2] Daily Season Pass Charge");
            Console.WriteLine("[3] Per Min Charge");
            Console.WriteLine("[0] Back");
            Console.WriteLine("---------------------------------------------");
        }

        public static double calculate(ParkingRecord record)
        {

            var vehicleCharges_minute = new Dictionary<string, double>
            {
                { "Car", 0.03 },
                { "Motorbike", 0.02 },
                { "Truck", 0.06 },
                { "Bus", 0.1 }
            };

            var vehicleCharges_limit = new Dictionary<string, double>
            {
                { "Car", 25 },
                { "Motorbike", 10 },
                { "Truck", 50 },
                { "Bus", 70 }
            };

            if (record.SeasonPassType == 1)
            {
                Season_Pass_Monthly monthlyStrategy = new Season_Pass_Monthly();
                ParkingCharge pc = new ParkingCharge(monthlyStrategy, 0);
                record.ParkingCharge = pc;
                return record.CaptureParkingRecord();
            }
            else if (record.SeasonPassType == 0)
            {
                double limit = vehicleCharges_limit[record.VehicleType];
                double rate = vehicleCharges_minute[record.VehicleType];

                Season_Pass_Daily dailyStrategy = new Season_Pass_Daily(limit);
                ParkingCharge pc = new ParkingCharge(dailyStrategy, rate);
                record.ParkingCharge = pc;
                return record.CaptureParkingRecord();
            }
            else if (record.SeasonPassType == -1)
            {
                double rate = vehicleCharges_minute[record.VehicleType];

                PerMinuteCharge perMinCharge = new PerMinuteCharge();
                ParkingCharge pc = new ParkingCharge(perMinCharge, rate);
                record.ParkingCharge = pc;
                return record.CaptureParkingRecord();
            }
            return -1;
                
        }

        public static void parkingCharge(ParkingRecord record)
        {
            Console.WriteLine("\nParking Record Details:");
            Console.WriteLine("Unique Pass Number: " + record.UniqueParkingNumber);
            Console.WriteLine("Entry Time: " + record.EntryDateTime);
            Console.WriteLine("Exit Time: " + record.ExitDateTime);
            Console.WriteLine("Vehicle Type: " + record.VehicleType);
            Console.WriteLine();
            double amt = calculate(record);
            if (amt == -1)
            {
                Console.WriteLine("Error in Calculate Parking Charge Function");
            }
            else
            {
                Console.WriteLine("Total Amount Charged upon exit from campus: $" + amt.ToString("F2"));
            }
        }

        // Option 7: Iterator Design Pattern - Financial Report
        static void GenerateReport(ConcreteAggregate ca, List<User_ParkingRecord> userParkingRecordList)
        {
            Console.WriteLine("\nMonthly Financial Report: ");
            Iterator Iterator = ca.createIterator(userParkingRecordList);
            Iterator staffIterator = ca.createStaffIterator(userParkingRecordList);
            Iterator studentIterator = ca.createStudentIterator(userParkingRecordList);
            double total = 0;
            double studentTotal = 0;
            double staffTotal = 0;

            while (Iterator.hasNext())
            {
                User_ParkingRecord pr = Iterator.next();
                total += pr.ParkingRecord.AmountCharged;
            }
            Console.Write("All Vehicles: $");
            Console.WriteLine(total);
            while (staffIterator.hasNext())
            {
                User_ParkingRecord pr = staffIterator.next();
                if (pr != null)
                {
                    staffTotal += pr.ParkingRecord.AmountCharged;
                }
            }
            Console.Write("Staff Vehicles: $");
            Console.WriteLine(staffTotal);
            while (studentIterator.hasNext())
            {
                User_ParkingRecord pr = studentIterator.next();
                if (pr != null)
                {
                    studentTotal += pr.ParkingRecord.AmountCharged;
                }
            }
            Console.Write("Student Vehicles: $");
            Console.WriteLine(studentTotal);
        }

        static string GenerateUniquePassNumber()
        {
            // This is a simplified method to generate a unique pass number
            // You can replace this with your own logic to generate unique numbers
            return Guid.NewGuid().ToString();
        }

        public static void displayMenu()
        {
            Console.WriteLine("\n------------------ M E N U ------------------");
            Console.WriteLine("[1] Process Season Pass");
            Console.WriteLine("[2] Apply Season Pass");
            Console.WriteLine("[3] Renew Season Pass");
            Console.WriteLine("[4] Transfer Season Pass");
            Console.WriteLine("[5] Terminate Season Pass");
            Console.WriteLine("[6] Strategy Design Pattern - Parking Charges");
            Console.WriteLine("[7] Iterator Design Pattern - Financial Report");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
