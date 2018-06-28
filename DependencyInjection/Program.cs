using CSharp_DesignPatterns.Interfaces;
using CSharp_DesignPatterns.IOC;
using NodaTime;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class Program
    {
        static void Main()
        {
            Injector injector = new Injector();
            injector.Bind<IClock, SystemClock>().InSingletonScope();
            injector.Bind<DateTimeZone>(DateTimeZone.GetSystemDefault());
            injector.Bind<Instant>(Instant.FromUtc(2000, 1, 1, 0, 0, 0));
            injector.Bind<CalendarSystem>(CalendarSystem.Iso);

            var presenter = injector.CreateDiaryPresenter()
            presenter.Start();
        }
    }
}