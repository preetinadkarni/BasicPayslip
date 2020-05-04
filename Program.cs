﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPayslipKata
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("~~~");
            Console.WriteLine("Welcome to the payslip generator!\n");
            bool isValidName = false;
            BasicPayslip bp = new BasicPayslip();
            while (!isValidName)
            {
                Console.Write("Please input your name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    isValidName = true;
                    bp.Name = name;
                }
            }

            bool isValidSurname = false;
            while (!isValidSurname)
            {
                Console.Write("Please input your surname: ");
                string surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname))
                {
                    isValidSurname = true;
                    bp.Surname = surname;
                }
            }

            bool isValidAnnualSalary = false;
            while (!isValidAnnualSalary)
            {
                Console.Write("Please enter your annual salary: ");
                string ansal = Console.ReadLine();
                int annualSalary;
                bool success = Int32.TryParse(ansal, out annualSalary);
                if (success && (annualSalary > 0))
                {
                    isValidAnnualSalary = true;
                    bp.AnnualSalary = annualSalary;

                }
                else
                    Console.WriteLine("Annual Salary should be positive integer");

            }

            bool isValidSuperRate = false;
            while(!isValidSuperRate)
            {
                Console.Write("Please enter your super rate: ");
                string sr = Console.ReadLine();
                int superRate;
                bool success = Int32.TryParse(sr, out superRate);
                if (success && CheckSuperRateIsValid(superRate))
                {
                    isValidSuperRate = true;
                    bp.SuperRate = superRate;
                }
                else
                    Console.WriteLine("Super Rate must be between 0% and 50% inclusive");

            }

            bool isValidStartDate = false;
            while (!isValidStartDate)
            {
                Console.Write("Please enter your payment start date: ");
                string startDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(startDate))
                {
                    isValidStartDate = true;
                    bp.StartDate = startDate;
                }
            }

            bool isValidEndDate = false;
            while (!isValidEndDate)
            {
                Console.Write("Please enter your payment end date: ");
                string endDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(endDate))
                {
                    isValidEndDate = true;
                    bp.EndDate = endDate;
                }
            }

            bp.GeneratePayslip();

        }

        public static bool CheckSuperRateIsValid(int superRate)
        {
            return (superRate >= 0 && superRate <= 50);
        }
    }
}
