using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            // Arrange
            var sut = new LoanTerm(1);

            // Act


            // Assert
            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number to years");
        }

        [Test]
        public void StoreYears()
        {
            // Arrrange
            var sut = new LoanTerm(1);

            // Act

            // Assert
            Assert.That(sut.Years, Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality()
        {
            // Arrrange
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            // Act

            // Assert
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RespectValueInequality()
        {
            // Arrrange
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            // Act

            // Assert
            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void ReferenceEqualityExample()
        {
            // Arrrange
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            // Act

            // Assert
            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));
        }

        [Test]
        public void Double()
        {
            // Arrrange
            double a = 1.0 / 3.0;

            // Act

            // Assert
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

        [Test]
        public void NotAllowZeroYears()
        {
            // Arrrange

            // Act

            // Assert
            Assert.That(()=> new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
