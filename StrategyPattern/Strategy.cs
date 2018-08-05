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
                list.Sort(CompareByAge);
                list.Sort((x, y) => x.Age.CompareTo(y.Age));
                list.Sort(new AgeComparer());

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

            public class AgeComparer : IComparer<Person>
            {
                public int Compare(Person x, Person y)
                {
                    return x.Age.CompareTo(y.Age);
                }
            }
        }
    }
}