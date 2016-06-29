using System;
using System.Globalization;
using AutoMapper;

namespace Sample02.AutoMapperConfig
{
    public class StringFromDateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
        {
            return source.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture);
        }
    }
}