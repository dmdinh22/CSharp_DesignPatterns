namespace CSharp_DesignPatterns.Singleton
{
    public sealed class ThreadSafeNoLockSingleton
    {
        private static readonly Singleton instance = new Singleton();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        { }

        private Singleton()
        { }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}