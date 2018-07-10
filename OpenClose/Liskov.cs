using System;
using System.Collections.Generic;
using System.IO;
using NodaTime;

namespace CSharp_DesignPatterns.OpenClose
{
    class Liskov
    {

        public virtual string Foo()
        {
            return "hello";
        }

        public void ArraysBreakLiskov()
        {
            IList<string> strings = new string[5];
            strings.Add("Hi");
        }

        // EXTREME EXAMPLE
        public class Article
        {
            public string Tags { get; set; }
        }

        static List<Article> FindJon(IQueryable<Article> articles)
        {
            // ArticleTable
            // Tags
            // c#, java
            // bc#
            return articles
                .Where(article => articles.Tags.Contains("c#"))
                .ToList();
        }

        // Liskov Principle examples
        static void PrintSequence<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(items);
            }
        }

        static void PrintCurrentTime(IClock clock)
        {
            Instant now = clock.Now;
        }

        static void ReportSpy(Spy spy)
        {
            Person spyAsPerson = spy;
            string name = spyAsPerson.Name;
        }

        static void LeakyAbstraction(Stream stream)
        {
            if (stream.CanSeek)
            {
                // stream.Seek(0, SeekOrigin.Begin);
                stream.Position = 0;
            }
        }
    }
}