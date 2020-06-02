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
            InputPayslipDetails(bp);
            bp.GeneratePayslip();

        }
        static void InputPayslipDetails(BasicPayslip bp)
        {
            Console.WriteLine("~~~");
            Console.WriteLine("Welcome to the payslip generator!\n");
            bool isValidName = false;
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
                const int positiveAnnualSalary = 0;
                if (success && (annualSalary > positiveAnnualSalary))
                {
                    isValidAnnualSalary = true;
                    bp.AnnualSalary = annualSalary;

                }
                else
                    Console.WriteLine("Annual Salary should be positive integer");

            }

            bool isValidSuperRate = false;
            while (!isValidSuperRate)
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
        }
        public static bool CheckSuperRateIsValid(int superRate)
        {
            const int minSuperRate = 0;
            const int maxSuperRate = 50;
            return (superRate >= minSuperRate && superRate <= maxSuperRate);
        }
    }
}
