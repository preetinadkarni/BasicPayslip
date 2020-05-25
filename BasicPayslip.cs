using System;

public class BasicPayslip
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public int AnnualSalary { get; set; }
	public int SuperRate { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }

	public const int MonthsInAYear = 12;

	public BasicPayslip()
	{
	}

	public int CalculateMonthlyGrossIncome(int AnnualSalary)
	{
		decimal monthlyGrossIncome;
		monthlyGrossIncome = Math.Floor(Convert.ToDecimal(AnnualSalary) / MonthsInAYear);
		return (Int32)monthlyGrossIncome;
	}

	public int CalculateMonthlyIncomeTax(int annualSalary)
	{
		decimal monthlyTax = 0;

		const int TaxSlab1Max = 18200;
		const int TaxSlab2Min = 18201;
		const int TaxSlab2Max = 37000;
		const decimal Slab2Tax = 0.19M;
		const int TaxSlab3Min = 37001;
		const int TaxSlab3Max = 87000;
		const decimal MinSalb3Tax = 3572M;
		const decimal Slab3Tax = 0.325M;
		const int TaxSlab4Min = 87001;
		const int TaxSlab4Max = 180000;
		const decimal MinSalb4Tax = 19822M;
		const decimal Slab4Tax = 0.37M;
		const int TaxSlab5Min = 180001;
		const decimal MinSalb5Tax = 54232M;
		const decimal Slab5Tax = 0.45M;


		if ( annualSalary >= TaxSlab2Min && annualSalary <= TaxSlab2Max)
			monthlyTax = ( (annualSalary - TaxSlab1Max) *  Slab2Tax) / MonthsInAYear;
		else if ( annualSalary >= TaxSlab3Min && annualSalary <= TaxSlab3Max)
			monthlyTax = ( MinSalb3Tax + ((annualSalary - TaxSlab2Max) * Slab3Tax ))/ MonthsInAYear;
		else if ( annualSalary >= TaxSlab4Min && annualSalary <= TaxSlab4Max)
			monthlyTax = ( MinSalb4Tax + ((annualSalary - TaxSlab3Max) * Slab4Tax)) / MonthsInAYear;
		else if ( annualSalary >= TaxSlab5Min)
			monthlyTax = ( MinSalb5Tax + ((annualSalary - TaxSlab4Max) * Slab5Tax)) / MonthsInAYear;

		return (Int32)Math.Ceiling(monthlyTax);
	}

	public int CalculateMonthlyNetIncome(int annualSalary)
	{
		int monthlyNetIncome = CalculateMonthlyGrossIncome(annualSalary) - CalculateMonthlyIncomeTax(annualSalary);
		return monthlyNetIncome;
	}

	public int CalculateSuper(int annualSalary, int superRate)
	{
		decimal super = Math.Floor(Convert.ToDecimal(CalculateMonthlyGrossIncome(annualSalary) * superRate / 100));
		return (Int32)super;
	}
	public void GeneratePayslip()
	{
		Console.WriteLine("\nYour payslip has been generated:\n");
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
		int monthlyGrossIncome = CalculateMonthlyGrossIncome(AnnualSalary);
		Console.WriteLine($"Gross Income: {monthlyGrossIncome}");
		int monthlyIincomeTax = CalculateMonthlyIncomeTax(AnnualSalary);
		Console.WriteLine($"Income Tax: {monthlyIincomeTax}");
		int monthlyNetIncome = CalculateMonthlyNetIncome(AnnualSalary);
		Console.WriteLine($"Income Tax: {monthlyNetIncome}");
		int super = CalculateSuper(AnnualSalary, SuperRate);
		Console.WriteLine($"Super : {super}");
		Console.WriteLine("\nThank you for using our payroll system!\n~~~");
		Console.ReadKey();
	}

}
