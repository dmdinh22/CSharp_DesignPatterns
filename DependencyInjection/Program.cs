using CSharp_DesignPatterns.Interfaces;
using NodaTime;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class Program
    {
        static void Main()
        {
            // Manual Dependency Injection
            IClock clock = SystemClock.Instance;
            License license = new License(Instant.UnixEpoch, clock);
            Diary diary = new Diary(clock, CalendarSystem.Iso, DateTimeZone.GetSystemDefault());
            DiaryPresenter presenter = new DiaryPresenter(diary, license);
        }
    }
}