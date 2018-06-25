using System;

namespace CSharp_DesignPatterns.Sandbox 
{
    // static is sealed and abstracted - no constructor
    public class FullLazySingleton 
    {
      private static class SingletonHolder
      {
        internal static readonly Singleton instance = new Singleton();
        // empty static constructor - forces laziness! - executed only once, cannot have anything in there
        static SingletonHolder() {}
      }

        private Singleton()
        {
            // stuff that must only happen once.
            Console.WriteLine("Singleton constructor");
        }

        public static Singleton Instance {get { return SingletonHolder.instance; } }

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
