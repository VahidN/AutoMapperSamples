using System;
using System.Globalization;

namespace Sample03.AutoMapperConfig
{
    public static class PersianExtensions
    {
        public static string ToShamsiDateTime(this DateTime info, string separator = "/", bool includeHourMinute = true)
        {
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = persianCalendar.GetDayOfMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return includeHourMinute ?
                string.Format("{0}{1}{2}{1}{3} {4}:{5}", pYear, separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture), info.Hour.ToString("00"), info.Minute.ToString("00"))
                : string.Format("{0}{1}{2}{1}{3}", pYear, separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture));
        }
    }
}