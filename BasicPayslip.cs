using System;

public class BasicPayslip
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public int AnnualSalary { get; set; }
	public int SuperRate { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }

	public BasicPayslip()
	{
	}

	public int CalculateMonthlyGrossIncome()
	{
		const int monthsInAYear = 12;

		decimal monthlyGrossIncome;
		monthlyGrossIncome = Math.Floor(Convert.ToDecimal(AnnualSalary) / monthsInAYear);
		return (Int32)monthlyGrossIncome;
	}

	public int CalculateMonthlyIncomeTax()
	{
		decimal monthlyTax = 0;

		const int TaxSlab1Max = 18200;
		const int TaxSlab2Min = 18201;
		const int TaxSlab2Max = 37000;
		const decimal Slab2Tax = 0.19M;
		const int TaxSlab3Min = 37001;
		const int TaxSlab3Max = 87000;
		const decimal Slab3Tax = 0.325M;
		const int TaxSlab4Min = 87001;
		const int TaxSlab4Max = 180000;
		const decimal Slab4Tax = 0.37M;
		const int TaxSlab5Min = 180001;
		const decimal Slab5Tax = 0.45M;
		const int monthsInAYear = 12;

		if ( AnnualSalary >= TaxSlab2Min && AnnualSalary <= TaxSlab2Max)
			monthlyTax = ( (AnnualSalary - TaxSlab1Max) *  Slab2Tax) / monthsInAYear;
		else if ( AnnualSalary >= TaxSlab3Min && AnnualSalary <= TaxSlab3Max)
			monthlyTax = ( 3572 + ((AnnualSalary - TaxSlab2Max) * Slab3Tax ))/ monthsInAYear;
		else if ( AnnualSalary >= TaxSlab4Min && AnnualSalary <= TaxSlab4Max)
			monthlyTax = ( 19822 + ((AnnualSalary - TaxSlab3Max) * Slab4Tax)) / monthsInAYear;
		else if ( AnnualSalary >= TaxSlab5Min)
			monthlyTax = ( 54232 + ((AnnualSalary - TaxSlab4Max) * Slab5Tax)) / monthsInAYear;

		return (Int32)Math.Ceiling(monthlyTax);
	}

	public int CalculateMonthlyNetIncome()
	{
		int monthlyNetIncome = CalculateMonthlyGrossIncome() - CalculateMonthlyIncomeTax();
		return monthlyNetIncome;
	}

	public int CalculateSuper()
	{
		decimal super = Math.Floor(Convert.ToDecimal(CalculateMonthlyGrossIncome() * SuperRate / 100));
		return (Int32)super;
	}
	public void GeneratePayslip()
	{
		Console.WriteLine("\nYour payslip has been generated:\n");
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
		int monthlyGrossIncome = CalculateMonthlyGrossIncome();
		Console.WriteLine($"Gross Income: {monthlyGrossIncome}");
		int monthlyIincomeTax = CalculateMonthlyIncomeTax();
		Console.WriteLine($"Income Tax: {monthlyIincomeTax}");
		int monthlyNetIncome = CalculateMonthlyNetIncome();
		Console.WriteLine($"Income Tax: {monthlyNetIncome}");
		int super = CalculateSuper();
		Console.WriteLine($"Super : {super}");
		Console.WriteLine("\nThank you for using our payroll system!\n~~~");
		Console.ReadKey();
	}

}
