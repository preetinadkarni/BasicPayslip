using System;
using NUnit.Framework;

namespace BasicPayslipUnitTests
{
    [TestFixture]
    public class BasicPayslipUnitTests
    {
        //[TestCase(0, ExpectedResult = true)]
        //public bool GivenSuperRateIsNumber_WhenCheckSuperRateIsValidIsCalled_ThenItShouldCheckIfItIsBetween0And50(int superRate)
        //{
        //    return CheckSuperRateIsValid(superRate);
        //}

        [Test]
        public void GivenAnnualSalary_WhenCalculateGrossSalary_ThenCorrectGrossSalaryCalculated()
        {
            BasicPayslip bp = new BasicPayslip();
            bp.AnnualSalary = 60050;
            Assert.AreEqual(bp.CalculateGrossIncome(), 5004);
        }
    }
}
