using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class ProductComparerShould
    {
        private List<LoanProduct> products;
        private ProductComparer sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            products = new List<LoanProduct>
            {
                new LoanProduct (1, "a", 1),
                new LoanProduct (2, "b", 2),
                new LoanProduct (3, "c", 3)
            };
        }

        [SetUp]
        public void Setup()
        {
            sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }

        [TearDown]
        public void TearDown()
        {
            // Runs after each test executes
            // sut.Dispose();
        }

        [Test]
        public void ReturnCorrectNumberOfComparissons()
        {
            // Arrrange

            // Act
            var comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Assert
            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void NotReturnDuplicateComparissons()
        {
            // Arrrange
            
            // Act
            var comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Assert
            Assert.That(comparisons, Is.Unique);
        }

        [Test]
        public void RetunrComparissonForFirstProduct()
        {
            // Arrrange
            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            // Act
            var comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Assert
            Assert.That(comparisons, Does.Contain(expectedProduct));
        }

        [Test]
        public void RetunrComparissonForFirstProduct_WithPartialKnownExpectedValues()
        {
            // Arrrange
            
            // Act
            var comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Assert
            Assert.That(comparisons, Has.Exactly(1)
                .Property("ProductName").EqualTo("a")
                .And
                .Property("InterestRate").EqualTo(1));
        }
    }
}
