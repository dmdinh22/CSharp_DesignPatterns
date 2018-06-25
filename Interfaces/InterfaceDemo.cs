using System;
using NodaTime;
using NodaTime.Testing;
using NUnit.Framework;

namespace CSharp_DesignPatterns.Interfaces
{
    [TestFixture]
    public class InterfaceDemo
    {
        [Test]
        static void ExpiredLicense()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            StubClock clock = new StubClock(expiry + Duration.OneTick);
            License license = new License(expiry, clock);

            Assert.IsTrue(license.HasExpired);
        }

        [Test]
        static void ExpiryAtExactInstant()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            StubClock clock = new StubClock(expiry - Duration.OneTick);
            License license = new License(expiry, clock);

            Assert.IsTrue(license.HasExpired);
        }

        [Test]
        static void NonExpiredLicense()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            StubClock clock = new StubClock(expiry - Duration.OneTick);
            License license = new License(expiry, clock);

            Assert.IsFalse(license.HasExpired);
        }

        [Test]
        public void NonExpiredLicenseBecomesLicense()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            StubClock clock = new StubClock(expiry - Duration.OneTick);
            License license = new License(expiry, clock);

            Assert.IsFalse(license.HasExpired);
            clock.AdvanceTicks(1);
            Assert.IsTrue(license.HasExpired);
        }
    }
}