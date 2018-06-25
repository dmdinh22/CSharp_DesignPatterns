using System;
using NodaTime;

namespace CSharp_DesignPatterns.Interfaces
{
    public class License
    {
        private readonly Instant expiry;
        private readonly IClock clock;

        public License(Instant expiry, IClock clock)
        {
            this.expiry = expiry;
            this.clock = clock;
        }

        public bool HasExpired
        {
            get { return clock.Now >= expiry; }
        }
    }
}