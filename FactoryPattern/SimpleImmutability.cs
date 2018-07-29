using NUnit.Framework;

namespace CSharp_DesignPatterns.FactoryPattern
{
    public class Point
    {
        private readonly int x;
        private readonly int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Point( int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [TestFixture]    
    public class SimpleImmutability
    {
        
    }
}