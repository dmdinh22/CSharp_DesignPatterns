namespace CSharp_DesignPatterns.Sandbox 
{
    // static is sealed and abstracted - no constructor
    public class Singleton 
    {
        private static Singleton instance;

        private Singleton()
        {
            // stuff that must only happen once.
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }

        }

        // Raison d'etre for the class
        public void DoSomething () 
        {
        }
    }
}