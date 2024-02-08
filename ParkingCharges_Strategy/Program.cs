using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace SE_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Yi Ting","1","yiting","password",12345678,new DateTime(2024,2,1), new DateTime(2024,7,25));
            Vehicle vehicle = new Vehicle("SQC123B", "12345678", "car");
            SeasonParkingPass pass = new SeasonParkingPass("1", new DateTime(2024, 2, 4), new DateTime(2024, 7, 25), "valid", "monthly", user, vehicle);


            while (true)
            {

                int option;

                displayMenu();
                Console.Write("Enter your option: ");
                option = Convert.ToInt32(Console.ReadLine());


                if (option == 1)
                {
                    Console.WriteLine(Convert.ToString(pass));
                    pass.State.Terminate(pass);
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

        public static void displayMenu()
        {
            Console.WriteLine("---------------- M E N U --------------------");
            Console.WriteLine("[1] Terminate Season Pass");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("---------------------------------------------");
        }

       
    }
}