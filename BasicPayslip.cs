using System;

public class BasicPayslip
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public int Salary { get; set; }
	public int SuperRate { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }

	public BasicPayslip()
	{
	}

	public void GeneratePayslip()
	{
		Console.WriteLine($"Name: {Name} {Surname}");
		Console.ReadKey();
	}

}
