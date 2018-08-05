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

                // using nasty way - inheritancesucks
                list.Sort(new InheritanceSucksLoggingAgeComparer());

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
                // how do we know which methods to make virtual so it can
                // be overriden? this ex only has one method, but if we have many
                // there can be problems making everything virtual
                // this is why Jon does not like inheritance
                public virtual int Compare(Person x, Person y)
                {
                    return x.Age.CompareTo(y.Age);
                }
            }

            public class InheritanceSucksLoggingAgeComparer : AgeComparer
            {
                public override int Compare(Person x, Person y)
                {
                    int result = base.Compare(x, y);
                    Console.WriteLine("Compare({0}, {1}) == {2}", x, y, result);
                    return result;
                }
            }

            // little trick for decorator using type inference with method using its args
            public static class ReversingComparer
            {
                public static IComparer<T> For<T>(IComparer<T> comparer)
                {
                    return new ReversingComparer<T>(comparer);
                }
            }

            public sealed class ReversingComparer<T> : IComparer<T>
            {
                private readonly IComparer<T> comparer;

                public ReversingComparer(IComparer<T> comparer)
                {
                    this.comparer = comparer;
                }

                public int Compare(T x, T y)
                {
                    // int result = comparer.Compare(x, y);
                    // Console.WriteLine("Compare({0}, {1}) == {2}", x, y, result);
                    // return result;

                    // Comparer.Comare() returns:
                    // -1 if x < y
                    // 0 if x == y
                    // 1 if y > x
                    int originalResult = comparer.Compare(x, y);
                    return -originalResult;
                }
            }
        }
    }
}