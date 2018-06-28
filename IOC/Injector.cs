using CSharp_DesignPatterns.Interfaces;
using NodaTime;

namespace CSharp_DesignPatterns.IOC
{
    // Inversion Of Control
    public class Injector
    {

        public void Bind<T>(T instance) { }
        public IClock CreateClock()
        {
            return SystemClock.Instance;
        }

        public License CreateLicense()
        {
            return new License(Instant.UnixEpoch, CreateClock());
        }

        public DateTimeZone CreateTimeZone()
        {
            return DateTimeZone.GetSystemDefault();
        }

        public CalendarSystem CreateCalendarSystem()
        {
            return CalendarSystem.Iso;
        }

        public Diary CreateDiary()
        {
            return new Diary(CreateClock(), CreateCalendarSystem(), CreateTimeZone());
        }

        public DiaryPresenter CreateDiaryPresenter()
        {
            return new DiaryPresenter(CreateDiary(), CreateLicense());
        }

    }
}