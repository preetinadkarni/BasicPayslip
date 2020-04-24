using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPayslipKata
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            Console.Write("Please input your name: ");
            string name = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string surname = Console.ReadLine();
            Console.Write("Please enter your annual salary: ");
            string salary = Console.ReadLine();
            Console.Write("Please enter your super rate: ");
            string superRate = Console.ReadLine();
            Console.Write("Please enter your payment start date: ");
            string startDate = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string endDate = Console.ReadLine();

            BasicPayslip bp = new BasicPayslip();
            bp.Name = name;
            bp.Surname = surname;
            bp.Salary= Convert.ToInt32(salary);
            bp.SuperRate = Convert.ToInt32(superRate);
            bp.StartDate = startDate;
            bp.EndDate = endDate;

            bp.GeneratePayslip();
        }
    }
}
