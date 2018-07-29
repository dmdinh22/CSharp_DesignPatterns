using NUnit.Framework;

namespace CSharp_DesignPatterns.FactoryPattern
{
    // public class Point
    // {
    //     private readonly int x;
    //     private readonly int y;

    //     public int X { get { return x; } }
    //     public int Y { get { return y; } }

    //     public Point( int x, int y)
    //     {
    //         this.x = x;
    //         this.y = y;
    //     }
    // }

    public struct BadDuration
    {
        private readonly long ticks;

        public BadDuration(long ticks)
        {
            this.ticks = ticks;
        }

        public BadDuration(long milliseconds)
        {
            this.ticks = milliseconds * 10000;
        }

        public BadDuration(long seconds)
        {
            this.ticks = seconds * 10000 * 1000;
        }
    }

    [TestFixture]    
    public class SimpleImmutability
    {
        
    }
}