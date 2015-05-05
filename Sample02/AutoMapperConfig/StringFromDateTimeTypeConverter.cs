using System;
using System.Globalization;
using AutoMapper;

namespace Sample02.AutoMapperConfig
{
    public class StringFromDateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(ResolutionContext context)
        {
            var objDateTime = context.SourceValue;
            return objDateTime == null ? string.Empty : ((DateTime)context.SourceValue).ToString("dd/mm/yyyy", CultureInfo.InvariantCulture);
        }
    }
}