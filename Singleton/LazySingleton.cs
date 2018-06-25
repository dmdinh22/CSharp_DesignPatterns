using System;

namespace CSharp_DesignPatterns.Sandbox 
{
    // for .NET 4
    public class LazySingleton 
    {
        private static readonly Lazy<Singleton> lazyInstance = new Lazy<Singleton>(() => new Singleton(), Lazy);

        private Singleton()
        {
            // stuff that must only happen once.
            Console.WriteLine("Singleton constructor");
        }

        public static Singleton Instance {get { return lazyInstance.Value; } }

        public static void SayHi()
        {
          Console.WriteLine("Hi There");
        }

        // Raison d'etre for the class
        public void DoSomething () 
        {
            // This method needs to be thread-safe!
        }
    }
}
