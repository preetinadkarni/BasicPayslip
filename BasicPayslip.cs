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

	public int CalculateGrossIncome()
	{
		double grossIncome;
		grossIncome = Math.Floor(Convert.ToDouble(AnnualSalary) / 12);
		return (Int32)grossIncome;
	}

	public int CalculateIncomeTax()
	{
		double tax = 0;

		const int TaxSlab1Max = 18200;
		const int TaxSlab2Min = 18201;
		const int TaxSlab2Max = 37000;
		const double Slab2Tax = 0.19;
		const int TaxSlab3Min = 37001;
		const int TaxSlab3Max = 87000;
		const double Slab3Tax = 0.325;
		const int TaxSlab4Min = 87001;
		const int TaxSlab4Max = 180000;
		const double Slab4Tax = 0.37;
		const int TaxSlab5Min = 180001;
		const double Slab5Tax = 0.45;

		if ( AnnualSalary >= TaxSlab2Min && AnnualSalary <= TaxSlab2Max)
			tax = ( (AnnualSalary - TaxSlab1Max) *  Slab2Tax) / 12;
		else if ( AnnualSalary >= TaxSlab3Min && AnnualSalary <= TaxSlab3Max)
			tax = ( 3572 + ((AnnualSalary - TaxSlab2Max) * Slab3Tax ))/ 12;
		else if ( AnnualSalary >= TaxSlab4Min && AnnualSalary <= TaxSlab4Max)
			tax = ( 19822 + ((AnnualSalary - TaxSlab3Max) * Slab4Tax)) / 12;
		else if ( AnnualSalary >= TaxSlab5Min)
			tax = ( 54232 + ((AnnualSalary - TaxSlab4Max) * Slab5Tax)) / 12;

		return (Int32)Math.Ceiling(tax);
	}

	public int CalculateNetIncome()
	{
		int netIncome = CalculateGrossIncome() - CalculateIncomeTax();
		return netIncome;
	}

	public int CalculateSuper()
	{
		double super = Math.Floor(Convert.ToDouble(CalculateGrossIncome() * SuperRate / 100));
		return (Int32)super;
	}
	public void GeneratePayslip()
	{
		Console.WriteLine("\nYour payslip has been generated:\n");
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.WriteLine($"Pay Period: {StartDate} - {EndDate}");
		int grossIncome = CalculateGrossIncome();
		Console.WriteLine($"Gross Income: {grossIncome}");
		int incomeTax = CalculateIncomeTax();
		Console.WriteLine($"Income Tax: {incomeTax}");
		int netIncome = CalculateNetIncome();
		Console.WriteLine($"Income Tax: {netIncome}");
		int super = CalculateSuper();
		Console.WriteLine($"Super : {super}");
		Console.WriteLine("\nThank you for using our payroll system!\n~~~");
		Console.ReadKey();
	}

}
