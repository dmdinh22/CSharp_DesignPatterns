using NodaTime;
using NodaTime.Testing;
using NUnit.Framework;

namespace CSharp_DesignPatterns.DependencyInjection
{
    [TestFixture]
    public class DiaryTest
    {
        [Test]
        public void FormatToday_Iso_Utc()
        {
            var clock = new FakeClock(Instant.UnixEpoch);
            Diary diary = new Diary(clock, CalendarSystem.Iso, DateTimeZone.Utc);

            string today = diary.FormatToday();
            Assert.AreEqual("1970-01-01", today);
        }

        [Test]
        public void FormatToday_Iso_NegativeOffset()
        {
            var zone = DateTimeZone.ForOffset(Offset.FromHours(-8));
            var clock = new FakeClock(Instant.UnixEpoch);
            Diary diary = new Diary(clock, CalendarSystem.Iso, DateTimeZone.Utc);

            string today = diary.FormatToday();
            Assert.AreEqual("1969-12-31", today);
        }
    }
}