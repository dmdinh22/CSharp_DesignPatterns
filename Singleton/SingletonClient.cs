using NUnit.Framework;

namespace CSharp_DesignPatterns.Sandbox
{
    [TestFixture]
    public class SingletonClient
    {
        [Test]
        public void UseSingleton()
        {
            Singleton.SayHi(); // still using the Singleton class
            Console.WriteLine("Start of test");
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Assert.AreSame(s1, s1);
        }
    }
}