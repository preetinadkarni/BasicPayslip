using System;

public class BasicPayslip
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public int AnnualSalary { get; set; }
	public int SuperRate { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }

	private double grossIncome;

	public BasicPayslip()
	{
	}

	public double CalculateGrossIncome()
	{
		grossIncome = Math.Floor(Convert.ToDouble(AnnualSalary) / 12);
		return grossIncome;
	}
	public void GeneratePayslip()
	{
		Console.WriteLine("\nYour payslip has been generated:\n");
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
		this.CalculateGrossIncome();
		Console.WriteLine($"Gross Income: {grossIncome}");
		Console.ReadKey();
	}

}
