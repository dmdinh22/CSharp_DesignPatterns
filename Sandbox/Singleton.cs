namespace CSharp_DesignPatterns.Sandbox 
{
    // static is sealed and abstracted - no constructor
    public class Singleton 
    {
        private static Singleton instance;

        private Singleton()
        {
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }

        // Raison d'etre for the class
        public void DoSomething () 
        {
        }
    }
}