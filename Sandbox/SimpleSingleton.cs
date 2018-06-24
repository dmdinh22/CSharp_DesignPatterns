namespace CSharp_DesignPatterns.Sandbox 
{
    // static is sealed and abstracted - no constructor
    public class SimpleSingleton 
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton()
        {
            // stuff that must only happen once.
        }

        public static Singleton Instance {get { return instance; } }

        // Raison d'etre for the class
        public void DoSomething () 
        {
            // This method needs to be thread-safe!
        }
    }
}
