using System;
using NodaTime;

namespace CSharp_DesignPatterns.OpenClose
{
    // Violates Liskov's principle - violates type safety
    public class BrokenClock : IClock
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}