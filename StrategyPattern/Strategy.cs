namespace CSharp_DesignPatterns.StrategyPattern
{
    public class Strategy
    {
        [TestFixture]
        public class Strategy
        {
            public static readonly ReadOnlyCollection<Person> People = new List<Person>
            {
                new Person { Name = "Jon", Age = 35 },
                new Person { Name = "Rob", Age = 44 },
                new Person { Name = "Holly", Age = 36 },
                new Person { Name = "Tom", Age = 8 },
            }.AsReadOnly();

            [Test]
            public void SortingByAge()
            {

            }
        }
    }
}