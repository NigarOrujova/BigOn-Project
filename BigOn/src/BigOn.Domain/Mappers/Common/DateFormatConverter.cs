using AutoMapper;
using System;

namespace BigOn.Domain.Mappers.Common
{
    public class DateFormatConverter : IValueConverter<DateTime?, string>
    {
        public string Convert(DateTime? sourceMember, ResolutionContext context)
        {
            if (context?.Items?.ContainsKey("dateFormat") == false)
                goto end;


            var format = context?.Items["dateFormat"]?.ToString();

            if (sourceMember == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(format))
            {
                return sourceMember?.ToString(format);
            }

        end:
            return sourceMember?.ToString();
        }
    }
}
