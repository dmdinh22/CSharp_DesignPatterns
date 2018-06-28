using System;
using CSharp_DesignPatterns.Interfaces;
using NodaTime;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class DiaryPresenter
    {
        private Diary diary;
        private License license;
        public DiaryPresenter(IClock clock, Diary diary, License license)
        {
            // TODO: Complete
            this.diary = diary;
            this.license = license;
        }

        internal void Start()
        {
            Console.WriteLine("Today is: {0}", diary.FormatToday());
            Console.WriteLine("License expired? {0}", license.HasExpired);
        }
    }
}