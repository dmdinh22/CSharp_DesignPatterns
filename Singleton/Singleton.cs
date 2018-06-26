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
                    lock(mutex)
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
        public void DoSomething()
        {
            // This method needs to be thread-safe!
        }
    }
}

// Singleton article - http://csharpindepth.com/articles/general/singleton.aspx
/*

A single constructor, which is private and parameterless. This prevents other classes from instantiating it (which would be a violation of the pattern). Note that it also prevents subclassing - if a singleton can be subclassed once, it can be subclassed twice, and if each of those subclasses can create an instance, the pattern is violated. The factory pattern can be used if you need a single instance of a base type, but the exact type isn't known until runtime.
The class is sealed. This is unnecessary, strictly speaking, due to the above point, but may help the JIT to optimise things more.
A static variable which holds a reference to the single created instance, if any.
A public static means of getting the reference to the single created instance, creating one if necessary.
 */