using System;

namespace RCM.Domain.Core.Extensions
{
    public static class StringExtensions
    {
        //Workaround for ASP.NET Core Culture Binding Error 
        //will be replaced later
        public static DateTime? ToDateTime(this string dateString)
        {
            if (dateString == null) return null;
            DateTime.TryParse(dateString, out DateTime date);

            return date;
        }

        public static DateTime? ToDate(this string dateString)
        {
            if (dateString == null) return null;
            DateTime.TryParse(dateString, out DateTime date);

            return DateTime.Parse(date.ToShortDateString());
        }

        public static decimal? ToDecimal(this string decimalString)
        {
            if (decimalString == null) return null;
            Decimal.TryParse(decimalString, out decimal value);

            return value;
        }
    }
}
