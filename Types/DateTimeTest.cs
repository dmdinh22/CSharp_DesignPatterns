using System;
using NodaTime;
using NUnit.Framework;

namespace CSharp_DesignPatterns.Types
{
    [TestFixture]
    public class DateTimeTest
    {
        [Test]
        public void Dates()
        {
            DateTime date = DateTime.Today;

            date = date.AddHours(5);
            TimeSpan time = date.TimeOfDay;

        }

        [Test]
        public void KindConfusion()
        {
            DateTime mystery = new DateTime(2012, 4, 25, 19, 41, 0);
            Assert.AreEqual(DateTimeKind.Unspecified, mystery.Kind);

            DateTime mysteryInUtc = mystery.ToUniversalTime();
            DateTime mysteryInLocal = mystery.ToLocalTime();
        }

        [Test]
        public void EqualOrNotEqual()
        {
            DateTime utc1 = new DateTime(2012, 10, 28, 0, 30, 0, DateTimeKind.Utc);
            DateTime utc2 = new DateTime(2012, 10, 28, 1, 30, 0, DateTimeKind.Utc);

            Assert.AreNotEqual(utc1, utc2);

            DateTime local1 = utc1.ToLocalTime();
            DateTime local2 = utc2.ToLocalTime();

            Assert.AreEqual(local1, local2);

            DateTime utc3 = local1.ToUniversalTime();
            DateTime utc4 = local2.ToUniversalTime();

            Assert.AreEqual(utc3, utc4);
        }
    }
}

// SRP - Single Responsibility Principle
// states that every class should be responsible for only one thing
// System.DateTime tries to do too much