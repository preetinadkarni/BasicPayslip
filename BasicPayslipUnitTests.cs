using System;
using NUnit.Framework;

namespace BasicPayslipUnitTests
{
    [TestFixture]
    public class BasicPayslipUnitTests
    {
        [Test]
        public void GivenAnnualSalary_WhenCalculateGrossSalary_ThenCorrectGrossSalaryCalculated()
        {
            BasicPayslip bp = new BasicPayslip();
            bp.AnnualSalary = 60050;
            Assert.AreEqual(bp.CalculateMonthlyGrossIncome(bp.AnnualSalary), 5004);
        }

        [TestCase(17000, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 1)]
        [TestCase(38000, ExpectedResult = 325)]
        [TestCase(60050, ExpectedResult = 922)]
        [TestCase(87000, ExpectedResult = 1652)]
        [TestCase(90000, ExpectedResult = 1745)]
        [TestCase(180001, ExpectedResult = 4520)]
        public int GivenAnnualSalary_WhenCalculateIncomeTax_ThenCorrectIncomeTaxCalculated(int annualSalary)
        {
            BasicPayslip bp = new BasicPayslip();
            bp.AnnualSalary = annualSalary;
            return bp.CalculateMonthlyIncomeTax(bp.AnnualSalary);
        }

        [TestCase(60050, ExpectedResult = 4082)]
        public int GivenAnnualSalary_WhenCalculateNetIncome_ThenCorrectNetIncomeCalculated(int annualSalary)
        {
            BasicPayslip bp = new BasicPayslip();
            bp.AnnualSalary = annualSalary;
            return bp.CalculateMonthlyNetIncome(bp.AnnualSalary);

        }

        [TestCase(60050,9, ExpectedResult = 450)]
        public int GivenAnnualSalary_WhenCalculateSuper_ThenCorrectSuperCalculated(int annualSalary, int superRate)
        {
            BasicPayslip bp = new BasicPayslip();
            bp.AnnualSalary = annualSalary;
            bp.SuperRate = superRate;
            return bp.CalculateSuper(bp.AnnualSalary, bp.SuperRate);

        }
    }
}
