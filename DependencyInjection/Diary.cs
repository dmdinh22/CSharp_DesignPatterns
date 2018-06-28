using NodaTime;
using NodaTime.Text;

namespace CSharp_DesignPatterns.DependencyInjection
{
    public class Diary
    {
        private static readonly LocalDatePattern OutputPattern = LocalDatePattern.CreateWithInvariantInfo("yyyy-MM-dd"); // dependency not injected
        private readonly IClock clock;

        private readonly CalendarSystem calendar;
        private readonly DateTimeZone timeZone;

        public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone) // 3 dependencies injected
        {
            this.clock = clock;
            this.calendar = calendar;
            this.timeZone = timeZone;
        }

        public void DisplayToday()
        {
            //DateTime today = DateTimeZone.Today;
            LocalDate date = clock.Now.InZone(timeZone, calendar).LocalDateTime.Date;
            Console.WriteLine(OutputPattern.Format(date));
        }
    }
}