using System;
using NUnit.Framework;

namespace CSharp_DesignPatterns.Interfaces
{
    [TestFixture]
    public class InterfaceDemo
    {
        static void ExpiredLicense()
        {
            // UNTESTABLE
            License license = new License(new DateTime(2000, 1, 1, 0, 0, 0));
            Assert.IsTrue(license.HasExpired);
        }

        static void NonExpiredLicense()
        {
            // UNTESTABLE
            License license = new License(new DateTime(2020, 1, 1, 0, 0, 0));
            Assert.IsFalse(license.HasExpired);
        }
    }
}