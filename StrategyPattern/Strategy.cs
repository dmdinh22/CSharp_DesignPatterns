using System;
using NUnit.Framework;

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
                new Person { Name = "Jon", Age = 5 },
                new Person { Name = "Tom", Age = 8 },
            }.AsReadOnly();

            [Test]
            public void SortingByAge()
            {
                var list = People.ToList();
                // list.Sort(CompareByAge);
                // list.Sort((x, y) => x.Age.CompareTo(y.Age));
                // list.Sort(new AgeComparer());

                // LoggingComparer decorating sorting operation by adding logging 
                // right on top of strategy being used
                //list.Sort(new LoggingComparer<Person>(new AgeComparer()));

                // using a trick defined below with type inference
                list.Sort(LoggingComparer.For(new AgeComparer()));

                foreach (var person in list)
                {
                    Console.WriteLine(person);
                }
            }

            public class JonList<T>
            {
                public void Sort(Comparison<T> comparison)
                {

                }

                public void Sort(IComparer<T> comparison)
                {

                }
            }

            public delegate int Comparison<in T>(T x, T y);
            public interface IComparer<in T>
            {
                int Compare(T x, T y);
            }

            static int CompareByAge(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }

            static int CompareByName(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }

            public class AgeComparer : IComparer<Person>
            {
                public int Compare(Person x, Person y)
                {
                    return x.Age.CompareTo(y.Age);
                }
            }

            // little trick for decorator using type inference with method using its args
            public static class LoggingComparer
            {
                public static IComparer<T> For<T>(IComparer<T> comparer)
                {
                    return new LoggingComparer<T>(comparer);
                }
            }

            public sealed class LoggingComparer<T> : IComparer<T>
            {
                private readonly IComparer<T> comparer;

                public LoggingComparer(IComparer<T> comparer)
                {
                    this.comparer = comparer;
                }

                public int Compare(T x, T y)
                {
                    int result = comparer.Compare(x, y);
                    Console.WriteLine("Compare({0}, {1}) == {2}", x, y, result);
                    return result;
                }
            }
        }
    }
}