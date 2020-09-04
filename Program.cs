using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SocialSecurityNumber_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string socialSecurityNumber;
            string firstName;
            string lastName;

            Console.Write("Please input your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Please input your last name: ");
            lastName = Console.ReadLine();

            // Input
            if (args.Length > 0)
            {
                // if input from terminal is already done
                Console.WriteLine($"You provided: {args[0]}");
                socialSecurityNumber = args[0];
            }
            else
            {   // Ask for input
                Console.WriteLine("Please input your Social security number YYYYMMDD-XXXX");
                socialSecurityNumber = Console.ReadLine();
            }

            // Gender
            string genderNumberString = socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1);
            int genderNumber = int.Parse(genderNumberString);
            string gender;

            if (genderNumber % 2 == 0) // True/false  (Boolean)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }

            // Age
            string birthDateString = socialSecurityNumber.Substring(0, 8);
            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyyyMMdd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;
             
            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day)
            {
                age = age - 1;
            }


            // Generation
            string generation = "Unknown";

            if (birthDate.Year < 1924)
            {
                generation = "G.I";
            } 
            else if (birthDate.Year < 1945)
            {
                generation = "Silent";
            }
            else if (birthDate.Year < 1964)
            {
                generation = "Baby boomer";
            }
            else if (birthDate.Year < 1979)
            {
                generation = "X";
            }
            else if (birthDate.Year < 1998)
            {
                generation = "Millenial";
            }
            else if (birthDate.Year < 2010)
            {
                generation = "Centennial";
            }

            // Result presentation
            Console.Clear();
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Social Security Number: {socialSecurityNumber}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Generation: {generation}");
        }
    }
}
