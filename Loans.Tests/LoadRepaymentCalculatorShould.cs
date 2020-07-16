using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class LoadRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyReparment(decimal principal, decimal interestRate, int termInYears,
            decimal expectedMontlyPayment)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }

        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyReparment_SimplifiedTestCase(decimal principal, decimal interestRate, int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CalculateCorrectMonthlyReparment_Centralized(decimal principal, decimal interestRate, int termInYears,
            decimal expectedMontlyPayment)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn), "TestCases")]
        public decimal CalculateCorrectMonthlyReparment_SimplifiedTestCase_CentralizedWithReturn(decimal principal, decimal interestRate, int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases", new object[] { "Data.csv" })]
        public void CalculateCorrectMonthlyReparment_Csv(decimal principal, decimal interestRate, int termInYears,
            decimal expectedMontlyPayment)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }

        [Test]
        public void CalculateCorrectMonthlyReparment_Combinatoria(
            [Values(100_000, 200_000, 500_000)]decimal principal, 
            [Values(6.5, 10, 20)]decimal interestRate, 
            [Values(10,20,30)]int termInYears)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
        }

        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyReparment_Sequential(
            [Values(200_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 10)] decimal interestRate,
            [Values(30, 30, 30)] int termInYears,
            [Values(1264.14, 1755.14, 4387.86)] decimal expectedMontlyPayment)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
            Assert.That(monthlyPayment, Is.EqualTo(expectedMontlyPayment));
        }

        [Test]
        public void CalculateCorrectMonthlyReparment_Range(
            [Range(50_000, 1_000_000, 50_000)] decimal principal,
            [Range(0.5, 20.00, 0.5)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears)
        {
            // Arrrange
            var sut = new LoanRepaymentCalculator();

            // Act
            var monthlyPayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate,
                new LoanTerm(termInYears));

            // Assert
        }
    }
}
