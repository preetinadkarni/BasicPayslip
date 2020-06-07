using System;
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
            BasicPayslip bp = new BasicPayslip();
            ShowWelcome();
            bp.Name = GetName();
            bp.Surname = GetSurname();
            bp.AnnualSalary = GetAnnualSalary();
            bp.SuperRate = GetSuperRate();
            bp.StartDate = GetStartDate();
            bp.EndDate = GetEndDate();
            bp.GeneratePayslip();
        }

        public static void ShowWelcome()
        {
            Console.WriteLine("~~~");
            Console.WriteLine("Welcome to the payslip generator!\n");
        }

        public static string GetName()
        {
            bool isValidName = false;
            string name;
            do
            {
                Console.Write("Please input your name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    isValidName = true;
            } while (!isValidName);
            return name;                  
        }

        public static  string GetSurname()
        {
            bool isValidSurname = false;
            string surname;
            do
            {
                Console.Write("Please input your surname: ");
                surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname))
                    isValidSurname = true;
            } while (!isValidSurname);
            return surname;
        }

        public static int GetAnnualSalary()
        {
           bool isValidAnnualSalary = false;
           int annualSalary;
           do
            {
                Console.Write("Please enter your annual salary: ");
                string ansal = Console.ReadLine();
                bool success = Int32.TryParse(ansal, out annualSalary);
                const int positiveAnnualSalary = 0;
                if (success && (annualSalary > positiveAnnualSalary))

                    isValidAnnualSalary = true;
                else
                    Console.WriteLine("Annual Salary should be positive integer");
            } while (!isValidAnnualSalary) ;
            return annualSalary;
        }

        public static int GetSuperRate()
        {
            bool isValidSuperRate = false;
            int superRate;
            do
            {
                Console.Write("Please enter your super rate: ");
                string sr = Console.ReadLine();
                bool success = Int32.TryParse(sr, out superRate);
                if (success && CheckSuperRateIsValid(superRate))
                    isValidSuperRate = true;
                else
                    Console.WriteLine("Super Rate must be between 0% and 50% inclusive");

            } while (!isValidSuperRate);
            return superRate;
        }

        public static string GetStartDate()
        {
            bool isValidStartDate = false;
            string startDate;
            do
            {
                Console.Write("Please enter your payment start date: ");
                startDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(startDate))
                    isValidStartDate = true;
            } while (!isValidStartDate);
            return startDate;
        }
        public static string GetEndDate()
        {
            bool isValidEndDate = false;
            string endDate;
            do
            {
                Console.Write("Please enter your payment end date: ");
                endDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(endDate))
                    isValidEndDate = true;
            } while (!isValidEndDate) ;
            return endDate;
        }
        public static bool CheckSuperRateIsValid(int superRate)
        {
            const int minSuperRate = 0;
            const int maxSuperRate = 50;
            return (superRate >= minSuperRate && superRate <= maxSuperRate);
        }
    }
}
