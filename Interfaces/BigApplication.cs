using NodaTime;

namespace CSharp_DesignPatterns.Interfaces
{
    public class BigApplication
    {
        static void Main()
        {
            License license = new License(Instant.FromUtc(2012, 4, 19, 0, 0),
                SystemClock.Instance);

            if (license.HasExpired)
            {
                Console.WriteLine("Pay me more money!");
                return;
            }
        }
    }
}