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

        public long Ticks { get { return ticks; } }

        // alternative for classes, not structs - can be immutable
        // as long as you don't mutate it anywhere in your class
        /* 
        public long Ticks { get; private set; }
        */
        
        private BadDuration(long ticks)
        {
            this.ticks = ticks;
        }

        public static BadDuration FromTicks(long ticks)
        {
            return new BadDuration(ticks);
        }

        public static BadDuration FromMilliseconds(long milliseconds)
        {
            return new BadDuration(milliseconds * 10000);
        }

        public static BadDuration FromSeconds(long seconds)
        {
            return new BadDuration(seconds * 10000 * 1000);
        }
    }

    [TestFixture]    
    public class SimpleImmutability
    {
        [Test]
        public void FromSeconds()
        {
            BadDuration duration = BadDuration.FromSeconds(5);
            Assert.AreEqual(50000000, duration.Ticks);
        }

        [Test]
        public void Ticks()
        {
            BadDuration duration = BadDuration.FromTicks(10);
            Assert.AreEqual(10, duration.Ticks);
        }
    }
}