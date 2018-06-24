namespace CSharp_DesignPatterns.Sandbox 
{
    // static is sealed and abstracted - no constructor
    public class Singleton 
    {
        private static readonly object mutex = new object();
        //volatile - field can be modified in the program by something such as the OS, hardware, or concurrently executing thread
        private static volatile Singleton instance;

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
                    // mutex - mutual exclusion object that allows multiple threads to synchronise access to a shared resource
                    lock (mutex)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }

                    }
                }
                return instance;
            }
        }

        // Raison d'etre for the class
        public void DoSomething () 
        {
            // This method needs to be thread-safe!
        }
    }
}

// Singleton article - http://csharpindepth.com/articles/general/singleton.aspx

// Why to NOT use a Singleton
/*

 */