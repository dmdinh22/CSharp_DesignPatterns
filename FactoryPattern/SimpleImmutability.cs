using System;
using NodaTime;
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

        [Test]
        public void WithZone()
        {
            DateTimeZone london = DateTimeZone.ForId("Europe/London");
            DateTimeZone hawaii = DateTimeZone.ForId("Pacific/Honolulu");
            ZonedDateTime uk = new ZonedDateTime(SystemClock.Instance.Now, london);
            Console.WriteLine(uk);
            Console.WriteLine(uk.WithZone(hawaii));
        }

        [Test]
        public void BuilderPattern()
        {
            Period period = Period.FromHours(5);
            period = Period.FromHours(5) + Period.FromMinutes(3);

            Period built = new PeriodBuilder { Hours = 5, Minutes = 3 }.Build();

            Assert.AreEqual(0, built.Seconds);
            Assert.AreEqual(period, built);

            var shyPeriod = new ShyPeriod.Builder { }.Build();
        }
    }

    public sealed class EfficientFoo
    {
        private string name;

        private EfficientFoo()
        {

        }

        public sealed class Builder
        {
            private EfficientFoo foo;
            public string Name
            {
                get { return foo.name; }
                set { foo.name = value; }
            }

            public EfficientFoo Build()
            {
                EfficientFoo copy = foo;
                foo = new EfficientFoo();
                return copy;
            }
        }
    }

    public sealed class ShyPeriod
    {
        private readonly string name;

        public string Name { get { return name; } }

        private ShyPeriod(Builder builder)
        {
            this.name = builder.Name;
        }
        public sealed class Builder
        {
            public string Name { get; set; }
            public ShyPeriod Build()
            {
                return new ShyPeriod(this);
            }
        }
    }
}