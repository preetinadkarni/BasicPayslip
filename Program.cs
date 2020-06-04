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
            GetPayslipDetails(bp);
            bp.GeneratePayslip();

        }
        private static void GetPayslipDetails(BasicPayslip bp)
        {
            Console.WriteLine("~~~\nWelcome to the payslip generator!\n");
            bool[] isValidInput = { false, false, false, false, false, false };
            string[] inputMessages = { "name", "surname", "annual salary", "super rate", "payment start date", "payment end date" };
            string[] inputItems = new string[6];
            int i = 0;
            while (i < inputMessages.Length)
            {
                while (!isValidInput[i])
                {
                    Console.Write($"Please input your {inputMessages[i]}: ");
                    string consoleInput = Console.ReadLine();
                    if (ValidateInput(inputMessages[i], consoleInput))
                    {
                        isValidInput[i] = true;
                        inputItems[i] = consoleInput;
                    }                  
                }
                i++;
            }
            bp.Name = inputItems[0];
            bp.Surname = inputItems[1];
            bp.AnnualSalary = Convert.ToInt32(inputItems[2]);
            bp.SuperRate = Convert.ToInt32(inputItems[3]);
            bp.StartDate = inputItems[4];
            bp.EndDate = inputItems[5];

        }
        private static bool ValidateInput(string inputMessage, string consoleInput)
        {
            bool success;
            switch (inputMessage)
            {
                case "annual salary":
                    int annualSalary;
                    success = Int32.TryParse(consoleInput, out annualSalary);
                    const int positiveAnnualSalary = 0;
                    if (success && (annualSalary > positiveAnnualSalary))
                       return true;
                    else
                        Console.WriteLine("Annual Salary should be positive integer");
                    return false;
                case "super rate":
                    int superRate;
                    success = Int32.TryParse(consoleInput, out superRate);
                    if (success && CheckSuperRateIsValid(superRate))
                        return true;
                    else
                        Console.WriteLine("Super Rate must be between 0% and 50% inclusive");
                    return false;
                default:
                    return !string.IsNullOrEmpty(consoleInput);
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
