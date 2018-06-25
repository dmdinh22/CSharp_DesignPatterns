using System;

namespace CSharp_DesignPatterns.Interfaces
{
    public class License
    {
        private readonly DateTime expiry;

        public License(DateTime expiry)
        {
            this.expiry = expiry;
        }

        public bool HasExpired
        {
            get { return DateTime.UtcNow > expiry; }
        }
    }
}