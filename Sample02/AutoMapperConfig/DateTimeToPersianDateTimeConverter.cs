using System;
using System.Globalization;
using AutoMapper;

namespace Sample02.AutoMapperConfig
{
    public class DateTimeToPersianDateTimeConverter : ITypeConverter<DateTime, string>
    {
        private readonly bool _includeHourMinute;
        private readonly string _separator;

        public DateTimeToPersianDateTimeConverter(string separator = "/", bool includeHourMinute = true)
        {
            _separator = separator;
            _includeHourMinute = includeHourMinute;
        }

        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return toShamsiDateTime(source);
        }

        private string toShamsiDateTime(DateTime info)
        {
            var year = info.Year;
            var month = info.Month;
            var day = info.Day;
            var persianCalendar = new PersianCalendar();
            var pYear = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var pMonth = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var pDay = persianCalendar.GetDayOfMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return _includeHourMinute ?
                string.Format("{0}{1}{2}{1}{3} {4}:{5}", pYear, _separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture), info.Hour.ToString("00"), info.Minute.ToString("00"))
                : string.Format("{0}{1}{2}{1}{3}", pYear, _separator, pMonth.ToString("00", CultureInfo.InvariantCulture), pDay.ToString("00", CultureInfo.InvariantCulture));
        }
    }
}