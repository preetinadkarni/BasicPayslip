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

	private int incomeTax;

	public BasicPayslip()
	{
	}

	public double CalculateGrossIncome()
	{
		grossIncome = Math.Floor(Convert.ToDouble(AnnualSalary) / 12);
		return grossIncome;
	}

	public int CalculateIncomeTax()
	{
		double tax = 0;

		if ( AnnualSalary >= 18201 && AnnualSalary <= 37000 )
			tax = ( (AnnualSalary - 18200) * 0.19 ) / 12;
		else if ( AnnualSalary >= 37001 && AnnualSalary <= 87000 )
			tax = ( 3572 + ((AnnualSalary - 37000) * 0.325 ))/ 12;
		else if ( AnnualSalary >= 87001 && AnnualSalary <= 180000)
			tax = ( 19822 + ((AnnualSalary - 87000) * 0.37)) / 12;
		else if ( AnnualSalary >= 180000)
			tax = ( 54232 + ((AnnualSalary - 180000) * 0.45)) / 12;

		return (Int32)Math.Ceiling(tax);
	}
	public void GeneratePayslip()
	{
		Console.WriteLine("\nYour payslip has been generated:\n");
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
		this.CalculateGrossIncome();
		Console.WriteLine($"Gross Income: {grossIncome}");
		incomeTax = CalculateIncomeTax();
		Console.WriteLine($"Income Tax: {incomeTax}");
		Console.ReadKey();
	}

}
