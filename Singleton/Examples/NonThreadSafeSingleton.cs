namespace CSharp_DesignPatterns.Singleton
{
    // Bad code! Do not use!
    public sealed class NonThreadSafeSingleton
    {
        private static Singleton instance = null;

        private Singleton()
        { }

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
    }
}