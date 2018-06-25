using NodaTime;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class Diary
    {
        private readonly LocalDatePattern outputPattern = LocalDatePattern =
            public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone)
            {
                this.clock = clock;
                this.calendar = calendar;
                this.timeZone = timeZone;
            }

        public string DisplayToday()
        {
            //DateTime today = DateTimeZone.Today;
            LocalDate date = clock.Now.InZone(timeZone, calendar).LocalDateTime.Date;
        }
    }
}